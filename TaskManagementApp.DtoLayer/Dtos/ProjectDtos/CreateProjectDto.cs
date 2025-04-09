namespace TaskManagementApp.DtoLayer.Dtos.ProjectDtos
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerUserId { get; set; }
    }
}
