﻿using GraphQL.Application.Common.Repositories;
using GraphQL.Infrastructure.Contexts;

namespace GraphQL.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _schoolDbContext;

        public UnitOfWork(SchoolDbContext schoolDbContext)
            => _schoolDbContext = schoolDbContext;

        public ICourseRepository CourseRepository => new CourseRepository(this._schoolDbContext);

        public IPersonRepository PersonRepository => new PersonRepository(this._schoolDbContext);

        public async Task<int> Complete()
            => await this._schoolDbContext.SaveChangesAsync();
    }
}
