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
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7164/api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic tokenObj = JsonConvert.DeserializeObject(result);

                // Session'a token'ı kaydet
                HttpContext.Session.SetString("token", (string)tokenObj.token);

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Giriş bilgileri hatalı!";
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
    }
}
