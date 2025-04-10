namespace TaskManagementApp.DtoLayer.Dtos.ProjectDtos
{
    public class UpdateProjectDto
    {
        public int Id { get; set; } // Güncellenecek ID
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
