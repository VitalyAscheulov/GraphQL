using Microsoft.EntityFrameworkCore;
using GraphQL.Application.Common.Repositories;
using GraphQL.Domain.Entities;
using GraphQL.Infrastructure.Contexts;

namespace GraphQL.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public PersonRepository(SchoolDbContext schoolDbContext)
            => this._schoolDbContext = schoolDbContext;

        public void AddPerson(Person person)
            => this._schoolDbContext.People.Add(person);

        public void DeletePerson(Person person)
            => this._schoolDbContext.People.Remove(person);

        public async Task<Person> GetPerson(int id)
            => await this._schoolDbContext.People.FirstOrDefaultAsync(x => x.PersonId == id);

        public IQueryable<Person> GetPersons()
            => this._schoolDbContext.People;

        public void UpdatePerson(Person person)
            => this._schoolDbContext.People.Attach(person).State = EntityState.Modified;
    }
}
