using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries
{
    public class GetUserActivitySummaryQuery : IRequest<GetUserActivitySummaryResult>
    {
        public int Id { get; set; }

        public GetUserActivitySummaryQuery(int id)
        {
            Id = id;
        }
    }
}
