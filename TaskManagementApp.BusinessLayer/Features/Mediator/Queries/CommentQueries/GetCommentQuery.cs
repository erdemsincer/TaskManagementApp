using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentQuery : IRequest<List<GetCommentQueryResult>> { }

}
