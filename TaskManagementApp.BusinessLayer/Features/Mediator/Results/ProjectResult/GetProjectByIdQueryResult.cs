using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult
{
    public class GetProjectByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public int OwnerUserId { get; set; }
    }
}
