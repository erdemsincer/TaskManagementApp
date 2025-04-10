using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
