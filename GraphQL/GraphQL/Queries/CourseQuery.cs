using MediatR;
using GraphQL.Application.Common.DTOs;
using GraphQL.Application.Features.Course.Queries;

namespace GraphQL.API.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CourseQuery
    {
        public async Task<IQueryable<CourseDTO>> GetCourses([Service] IMediator mediator, CancellationToken cancellationToken)
            => await mediator.Send(new GetCoursesQuery(), cancellationToken);
    }
}
