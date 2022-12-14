using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.Application;
using GraphQL.Infrastructure;

namespace GraphQL.API
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddInfrastructure(configuration);
            services.AddApplication();
            services.AddInMemorySubscriptions();
            services.AddGraphQLServer()
                .AddQueryType()
                .AddTypeExtension<CourseQuery>()
                .AddTypeExtension<PersonQuery>()
                .AddMutationType()
                .AddTypeExtension<PersonMutation>()
                .AddSubscriptionType()
                .AddTypeExtension<PersonSubscription>();
        }

        public static void Configure(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseWebSockets();

            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}
