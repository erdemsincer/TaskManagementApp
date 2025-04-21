using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TaskManagementApp.DtoLayer.Dtos.UserDtos;

namespace TaskManagementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            // Login isteği
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7164/api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic tokenObj = JsonConvert.DeserializeObject(result);
                string token = tokenObj.token;

                // Token'ı session'a kaydet
                HttpContext.Session.SetString("token", token);

                // Token'dan kullanıcı ID'sini çek
                var payload = token.Split('.')[1];
                var base64 = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '='); // padding
                var jsonBytes = Convert.FromBase64String(base64.Replace('-', '+').Replace('_', '/'));
                var json = Encoding.UTF8.GetString(jsonBytes);
                var claims = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                var userId = claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"].ToString();

                // API'den kullanıcı bilgilerini ID ile çek
                var userResponse = await client.GetAsync($"https://localhost:7164/api/User/{userId}");
                if (userResponse.IsSuccessStatusCode)
                {
                    var userJson = await userResponse.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<ResultUserDto>(userJson);

                    HttpContext.Session.SetString("name", user.FullName);
                    HttpContext.Session.SetInt32("userId", int.Parse(userId));

                }

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "E-posta veya şifre hatalı!";
            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7164/api/Auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Error = "Kayıt sırasında bir hata oluştu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login", "Account");
        }

    }
}
