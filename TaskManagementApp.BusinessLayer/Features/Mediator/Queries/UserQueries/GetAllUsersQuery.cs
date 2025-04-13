using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersQueryResult>>
    {
    }
}
