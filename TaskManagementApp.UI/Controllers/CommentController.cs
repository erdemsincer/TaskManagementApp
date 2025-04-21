using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TaskManagementApp.DtoLayer.Dtos.CommentDtos;

namespace TaskManagementApp.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");

            if (string.IsNullOrEmpty(token))
            {
                // Giriş yapılmamışsa login'e yönlendir
                return RedirectToAction("Login", "Auth");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // 🔐 Token'dan UserId çözümleme
            var payload = token.Split('.')[1];
            var base64 = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            var jsonBytes = Convert.FromBase64String(base64.Replace('-', '+').Replace('_', '/'));
            var json = Encoding.UTF8.GetString(jsonBytes);
            var claims = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            var userId = int.Parse(claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"].ToString());

            dto.UserId = userId;
            dto.CreatedDate = DateTime.UtcNow;

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7164/api/Comment", content);

            // 🌀 Başarılıysa proje detayına dön
            return RedirectToAction("Detail", "Project", new { id = dto.ProjectId });
        }


    }
}
