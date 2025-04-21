using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TaskManagementApp.DtoLayer.Dtos.CommentDtos;

namespace TaskManagementApp.UI.ViewComponents
{
    public class CommentByTaskItemIdViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentByTaskItemIdViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int taskItemId, int projectId)
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("token");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            ViewBag.TaskItemId = taskItemId;
            ViewBag.ProjectId = projectId;

            var response = await client.GetAsync($"https://localhost:7164/api/Comment/GetByTaskItem/{taskItemId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultCommentDto>());

            var json = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(json);

            return View(comments);
        }

    }
}
