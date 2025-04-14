using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries
{
    public class GetUserWithTasksQuery : IRequest<GetUserWithTasksResult>
    {
        public int Id { get; set; }

        public GetUserWithTasksQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
