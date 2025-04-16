using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskManagementApp.DtoLayer.Dtos.CommentDtos;
using TaskManagementApp.DtoLayer.Dtos.ProjectDtos;

namespace TaskManagementApp.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:7164/api/Project/GetAllWithOwner");
            if (!response.IsSuccessStatusCode)
                return View(new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            return View(values);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7164/api/Project/GetWithTasks/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<ResultProjectWithTasksDto>(json);

            return View(project);
        }

        



    }


}
