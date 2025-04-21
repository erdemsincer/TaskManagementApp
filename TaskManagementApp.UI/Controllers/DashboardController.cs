using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TaskManagementApp.DtoLayer.Dtos.ProjectDtos;
using TaskManagementApp.DtoLayer.Dtos.TaskItemDtos;

namespace TaskManagementApp.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("token");
            var userId = await GetUserIdFromToken(token);

            ViewBag.Name = HttpContext.Session.GetString("name");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // 📁 Proje Sayısı
            var projectResponse = await client.GetAsync($"https://localhost:7164/api/Project/GetByUser/{userId}");
            var projectCount = 0;
            if (projectResponse.IsSuccessStatusCode)
            {
                var json = await projectResponse.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);
                projectCount = projects.Count;
            }

            // ✅ Görev Sayısı
            var taskResponse = await client.GetAsync($"https://localhost:7164/api/TaskItem/GetByUser/{userId}");
            var taskCount = 0;
            var todayCount = 0;

            if (taskResponse.IsSuccessStatusCode)
            {
                var json = await taskResponse.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<ResultTaskItemDto>>(json);
                taskCount = tasks.Count;
                todayCount = tasks.Count(t => t.Deadline?.Date == DateTime.Today);
            }

            ViewBag.ProjectCount = projectCount;
            ViewBag.TaskCount = taskCount;
            ViewBag.TodayTaskCount = todayCount;

            return View();
        }

        private async Task<string> GetUserIdFromToken(string token)
        {
            var payload = token.Split('.')[1];
            var jsonBytes = Convert.FromBase64String(payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '='));
            var json = Encoding.UTF8.GetString(jsonBytes);
            var claims = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            var userIdClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
            return claims[userIdClaim].ToString();
        }
    }
}
