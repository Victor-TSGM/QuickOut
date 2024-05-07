using Fazsoft.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickOut.Application.Common;
using QuickOut.Application.Customers;
using QuickOut.Application.Products.Commands;
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
using QuickOut.DomainEvents;
using QuickOut.Application.Users;
using QuickOut.Application.Orders.Commands;
using QuickOut.Application.Customers.Queries;
using QuickOut.Application.Estabilishments;
using QuickOut.Application.Estabilishments.EventHandlers;
using QuickOut.Application.Customers.EventHandlers;
using QuickOut.Application.Estabilishments.Queries;
using QuickOut.Application.Products.Queries;

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
            configuration.Register<AuthenticateCustomerCommand>(typeof(AuthenticateCustomerCommandHandler));
            configuration.Register<StartSectionCommand>(typeof(StartSectionCommandHandler));


            configuration.Register<AddEstabilishmentCommand>(typeof(AddEstabilishmentCommandHandler));
            configuration.Register<AuthenticateEstabilishmentCommand>(typeof(AuthenticateEstabilishmentCommandHandler));


            configuration.Register<AddUserCommand>(typeof(AddUserCommandHandler));
            configuration.Register<LoginCommand>(typeof(LoginCommandHandler));
            
            configuration.Register<AddProductCommand>(typeof(AddProductCommandHandler));

            configuration.Register<AddOrderCommand>(typeof(AddOrderCommandHandler));
        }

        public static void RegisterDomainsQueries(IServiceCollection serviceCollection)
        {
            //Customer
            serviceCollection.AddScoped<GetCustomerByIdQueryHanndler>();
            
            //Estabilishment
            serviceCollection.AddScoped<ReadEstabilishmentsQueryHandler>();
            
            //Product
            serviceCollection.AddScoped<ReadProductsQueryHandler>();
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
            configuration.RegisterTransactionalDomainEventHandler<CustomerCreatedEvent>(typeof(CustomerCreatedEventHandler));
            configuration.RegisterTransactionalDomainEventHandler<AuthenticateEstabilishmentEvent>(typeof(AuthenticateEstabelishmentEventHandler));
            configuration.RegisterTransactionalDomainEventHandler<AuthenticateCustomerEvent>(typeof(AuthenticateCustomerEventHandler));

        }

        public static void RegisterIntegrationEventHandlers(IBusRegistrationConfigurator busConfiguration)
        {

        }

        public static void RegisterEventualConsistencyDomainEventHandlers(IBusRegistrationConfigurator busConfiguration)
        {

        }
    }
}
