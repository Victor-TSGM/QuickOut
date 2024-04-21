using Fazsoft.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickOut.Application.Common;
using QuickOut.Application.Customers;
using QuickOut.Domain.Estabilishments;
using QuickOut.Domain.Orders;
using QuickOut.Domain.Products;
using QuickOut.Domain.Customers;
using QuickOut.Infrastructure.Common;
using QuickOut.Infrastructure.Estabilishments;
using QuickOut.Infrastructure.Orders;
using QuickOut.Infrastructure.Products;
using QuickOut.Infrastructure.Customers;
using QuickOut.Intrastructure.Common;
using QuickOut.Library;
using QuickOut.Infrastructure.Users;
using QuickOut.Domain.Users;
using QuickOut.Application.Users.Commands;

namespace QuickOut.Infrastructure
{
    public static class Startup
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheStore,  CacheStore>();

            string? connectionString = configuration.GetConnectionString("Default");

            serviceCollection.AddDbContext<QuickOutContext>(op =>
                op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                ServiceLifetime.Scoped
            );

            serviceCollection.AddScoped<ICustomerDbContext>(op => op.GetRequiredService<QuickOutContext>());
            serviceCollection.AddScoped<IEstabilishmentDbContext>(op => op.GetRequiredService<QuickOutContext>());
            serviceCollection.AddScoped<IProductDbContext>(op => op.GetRequiredService<QuickOutContext>());
            serviceCollection.AddScoped<IOrderDbContext>(op => op.GetRequiredService<QuickOutContext>());
            serviceCollection.AddScoped<IUserDbContext>(op => op.GetRequiredService<QuickOutContext>());

            serviceCollection.AddMassTransit(x =>
            {
                x.AddEntityFrameworkOutbox<QuickOutContext>(op =>
                {
                    op.UseMySql();
                    op.UseBusOutbox();
                });

                x.AddPublishMessageScheduler();

                RegisterIntegrationEventHandlers(x);
                RegisterEventualConsistencyDomainEventHandlers(x);

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConsumeFilter(typeof(UnitOfWorkConsumeFilter<>), context);
                    cfg.UsePublishMessageScheduler();

                    cfg.ConfigureEndpoints(context);
                });
            });

            serviceCollection.AddScoped<JwtTokenManager>();
            serviceCollection.AddScoped<UnitOfWork>();
            serviceCollection.AddScoped<IVicthorEventBus, EventBus>();
            serviceCollection.AddScoped<IDomainEventManager, DomainEventManager>();
            serviceCollection.AddScoped<IQueryDatabase, QueryDatabase>();

            VicthorMediatorConfiguration? mediatorConfiguration = new VicthorMediatorConfiguration(serviceCollection);

            RegisterDomainsCommands(mediatorConfiguration);
            RegisterTransactionalDomainEventHandlers(mediatorConfiguration);

            serviceCollection.AddSingleton(mediatorConfiguration);
            serviceCollection.AddScoped<VicthotMediator>();

            RegisterDomainsQueries(serviceCollection);
            RegisterDomainsRepositories(serviceCollection);
        }

        public static void RegisterDomainsCommands(VicthorMediatorConfiguration configuration)
        {
            configuration.Register<AddCustomerCommand>(typeof(AddCustomerCommandHandler));

            configuration.Register<AddUserCommand>(typeof(AddUserCommandHandler));
            configuration.Register<LoginCommand>(typeof(LoginCommandHandler));
        }

        public static void RegisterDomainsQueries(IServiceCollection serviceCollection)
        {

        }

        public static void RegisterDomainsRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<IEstabilishmentRepository, EstabilishmentRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterTransactionalDomainEventHandlers(VicthorMediatorConfiguration configuration)
        {

        }

        public static void RegisterIntegrationEventHandlers(IBusRegistrationConfigurator busConfiguration)
        {

        }

        public static void RegisterEventualConsistencyDomainEventHandlers(IBusRegistrationConfigurator busConfiguration)
        {

        }
    }
}
