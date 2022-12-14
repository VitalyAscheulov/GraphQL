using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using GraphQL.Application.Common.DTOs;

namespace GraphQL.API.GraphQL.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class PersonSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<PersonDTO>> OnPersonsChanges([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken)
            => await topicEventReceiver.SubscribeAsync<string, PersonDTO>("persons", cancellationToken);
    }
}
