namespace TaskManagementApp.DtoLayer.Dtos.ProjectDtos
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
