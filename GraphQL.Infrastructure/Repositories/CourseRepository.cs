using GraphQL.Application.Common.Repositories;
using GraphQL.Domain.Entities;
using GraphQL.Infrastructure.Contexts;

namespace GraphQL.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CourseRepository(SchoolDbContext schoolDbContext)
            => this._schoolDbContext = schoolDbContext;

        public IQueryable<Course> GetCourses()
            => this._schoolDbContext.Courses;
    }
}
