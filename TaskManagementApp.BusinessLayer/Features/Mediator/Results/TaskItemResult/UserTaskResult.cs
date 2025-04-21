namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult
{
    public class UserTaskResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }           // Görev açıklaması
        public string Status { get; set; }                // ToDo, InProgress, Done
        public string Priority { get; set; }              // Low, Medium, High
        public DateTime? Deadline { get; set; }           // Opsiyonel
        public DateTime CreatedDate { get; set; }         // Oluşturulma tarihi
        public string? AssignedToUser { get; set; }
        public int ProjectId { get; set; }                // Hangi projeye ait
        public string? ProjectTitle { get; set; }         // Proje başlığı
    }
}
