using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries
{
    public class GetProjectsByUserIdQuery : IRequest<List<GetProjectsByUserIdResult>>
    {
        public int UserId { get; set; }

        public GetProjectsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
