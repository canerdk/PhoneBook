using EventBus.Messages.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Infrastructure.Persistence;
using PhoneBook.Infrastructure.Repositories;

namespace PhoneBook.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PhoneBookConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonContactRepository, PersonContactRepository>();
            services.AddMasstransitWithRabbitMQ(configuration);

            return services;
        }
    }
}
