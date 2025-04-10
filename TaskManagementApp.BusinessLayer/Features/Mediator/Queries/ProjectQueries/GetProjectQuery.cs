using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries
{
    public class GetProjectQuery:IRequest<List<GetProjectQueryResult>>
    {
    }
}
