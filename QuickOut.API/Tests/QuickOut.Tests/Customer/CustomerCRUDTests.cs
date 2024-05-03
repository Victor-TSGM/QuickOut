using FluentAssertions;
using NSubstitute;
using QuickOut.Application.Customers;
using QuickOut.Library;

namespace QuickOut.Tests
{
    public class CustomerCRUDTests
    {
        [Fact]
        public async void AddCustomerWhenCommandIsExecutes()
        {
            var configuration = new TestConfiguration();
            var context = configuration.Context;

            AddCustomerCommandHandler commandHandler = new AddCustomerCommandHandler(
                configuration.CustomerRepository,
                Substitute.For<IDomainEventManager>());

            Result<Guid> result = await commandHandler.Handle(new AddCustomerCommand(
                "Victor", 
                "46013907889", 
                "15996514274", 
                "victor@email.com", 
                "1234", 
                DateTime.Parse("28/07/1997"), 
                "Brasil",
                "São Paulo",
                "Rua Quinze",
                200,
                "185555"));

            result.Succeeded.Should().BeTrue();
            context.Customers.Should().HaveCount(1);
        }
    }
}