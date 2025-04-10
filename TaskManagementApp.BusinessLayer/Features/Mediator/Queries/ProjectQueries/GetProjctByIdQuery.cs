using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries
{
    public class GetProjctByIdQuery : IRequest<GetProjectByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProjctByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
