using GraphQL.Domain.Entities;

namespace GraphQL.Application.Common.Repositories
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetPersons();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Task<Person> GetPerson(int id);
    }
}
