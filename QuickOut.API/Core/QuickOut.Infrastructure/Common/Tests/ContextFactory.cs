using Microsoft.EntityFrameworkCore;

namespace QuickOut.Infrastructure.Common.Tests
{
    public static class ContextFactory
    {
        public static QuickOutContext CreateInMemoryContext(string? name = null)
        {
            QuickOutContext context = new QuickOutContext(InMemoryOptions(name));
            EnsureNewDatabase(context);
            return context;
        }

        public static DbContextOptions<QuickOutContext> InMemoryOptions(string? name)
        {
            var builder = new DbContextOptionsBuilder<QuickOutContext>();
            builder.UseInMemoryDatabase(databaseName: GetDbName(name));
            return builder.Options;
        }

        public static string GetDbName(string? name)
        {
            return "DbInMemory - " +
                (name ?? "") +
                Thread.CurrentThread.ManagedThreadId;
        }

        public static void EnsureNewDatabase(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static T Create<T>(string name = null) where T : DbContext
        {
            var context = (T)Activator.CreateInstance(typeof(T), InMemoryOptions(name));
            if (context == null) throw new Exception("Error creating In Memory DbContext of type " + typeof(T).FullName);
            EnsureNewDatabase(context);
            return context;
        }
    }
}