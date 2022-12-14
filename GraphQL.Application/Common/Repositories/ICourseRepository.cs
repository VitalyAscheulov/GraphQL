using GraphQL.Domain.Entities;

namespace GraphQL.Application.Common.Repositories
{
    public interface ICourseRepository
    {
        IQueryable<Course> GetCourses();
    }
}
