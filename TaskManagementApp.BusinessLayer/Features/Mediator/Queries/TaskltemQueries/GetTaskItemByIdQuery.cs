using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries
{
    public class GetTaskItemByIdQuery:IRequest<GetTaskItemByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTaskItemByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
    
}
