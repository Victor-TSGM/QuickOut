using QuickOut.Infrastructure;
using QuickOut.Infrastructure.Common;
using QuickOut.Infrastructure.Common.Tests;

namespace QuickOut.Tests
{
    public class TestConfiguration
    {
        public QuickOutContext Context { get; set; }
        public UnitOfWork UnityOfWork { get => new UnitOfWork(Context); }
        public QueryDatabase Database { get => new QueryDatabase(Context); }

        public FakeCustomerRepository CustomerRepository { get => new FakeCustomerRepository(Context); }

        public TestConfiguration(string? databaseName = null)
        {
            Context = ContextFactory.CreateInMemoryContext(databaseName);
        }
    }
}