using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries
{
    public class GetProjectWithTasksQuery : IRequest<GetProjectWithTasksResult>
    {
        public int Id { get; set; }

        public GetProjectWithTasksQuery(int id)
        {
            Id = id;
        }
    }
}
