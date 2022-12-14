using MediatR;
using GraphQL.Application.Common.DTOs;
using GraphQL.Application.Features.Person.Queries;

namespace GraphQL.API.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class PersonQuery
    {
        public async Task<IQueryable<PersonDTO>> GetPersons([Service] IMediator mediator, CancellationToken cancellationToken)
            => await mediator.Send(new GetPersonsQuery(), cancellationToken);
    }
}
