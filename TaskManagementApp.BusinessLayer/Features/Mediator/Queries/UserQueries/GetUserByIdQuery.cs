using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries
{
    public class GetUserByIdQuery: IRequest<GetUserByIdQueryResult>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
