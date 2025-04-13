namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult
{
    public class GetUserByIdQueryResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } // Include ile Role.Name alacağız
        public DateTime CreatedDate { get; set; }
    }
}
