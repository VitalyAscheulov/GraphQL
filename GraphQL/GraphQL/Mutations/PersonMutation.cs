using HotChocolate.Subscriptions;
using MediatR;
using GraphQL.Application.Common.DTOs;
using GraphQL.Application.Features.Person.Commands;
using GraphQL.Application.Features.Person.Queries;

namespace GraphQL.API.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PersonMutation
    {
        public async Task<int> AddPerson(
            [Service] IMediator mediator,
            [Service] ITopicEventSender topicEventSender,
            CancellationToken cancellationToken,
            PersonDTO input)
        {
            var result = await mediator.Send(new AddPersonCommand(input), cancellationToken);

            await topicEventSender.SendAsync("persons", await mediator.Send(new GetPersonQuery(result)));

            return result;
        }

        public async Task<int> UpdatePerson(
            [Service] IMediator mediator,
            [Service] ITopicEventSender topicEventSender,
            CancellationToken cancellationToken,
            PersonDTO input)
        {
            var result = await mediator.Send(new UpdatePersonCommand(input), cancellationToken);

            await topicEventSender.SendAsync("persons", await mediator.Send(new GetPersonQuery(result)));

            return result;
        }

        public async Task<int> DeletePerson([Service] IMediator mediator, CancellationToken cancellationToken, int input)
            => await mediator.Send(new DeletePersonCommand(input), cancellationToken);
    }
}
