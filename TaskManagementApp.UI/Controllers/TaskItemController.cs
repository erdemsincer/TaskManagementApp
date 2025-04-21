using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TaskManagementApp.DtoLayer.Dtos.TaskItemDtos;

namespace TaskManagementApp.UI.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TaskItemController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // 🔹 Kullanıcının kendi görevleri
        public async Task<IActionResult> MyTasks()
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");
            var userId = HttpContext.Session.GetInt32("userId"); // Token'dan çözülmüş ID olmalı

            if (userId == null)
                return RedirectToAction("Login", "Account");

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7164/api/TaskItem/GetByUser/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultTaskItemDto>());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ResultTaskItemDto>>(json);

            return View(data);
        }

        // 🔹 Görev detay sayfası (yorumları da içerir)
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7164/api/TaskItem/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<ResultTaskItemDto>(json);

            return View(task);
        }
      
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UpdateTaskItemStatusDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7164/api/TaskItem/UpdateStatus", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MyTasks");
            }

            TempData["Error"] = "Görev durumu güncellenemedi.";
            return RedirectToAction("MyTasks");
        }


    }
}
