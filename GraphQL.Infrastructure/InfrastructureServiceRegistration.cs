using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Application.Common.Repositories;
using GraphQL.Infrastructure.Contexts;
using GraphQL.Infrastructure.Repositories;

namespace GraphQL.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GraphQLDataBase")), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
