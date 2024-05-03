using MassTransit;
using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Common;
using QuickOut.Domain.Estabilishments;
using QuickOut.Domain.Orders;
using QuickOut.Domain.Products;
using QuickOut.Domain.Customers;
using QuickOut.Infrastructure.Estabilishments;
using QuickOut.Infrastructure.Orders;
using QuickOut.Infrastructure.Products;
using QuickOut.Infrastructure.Customers;
using QuickOut.Infrastructure.Users;
using QuickOut.Domain.Users;

namespace QuickOut.Infrastructure.Common
{
    public class QuickOutContext : DbContext, 
        ICustomerDbContext, IEstabilishmentDbContext, IProductDbContext, IOrderDbContext, IUserDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Estabilishment> Estabilishments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<User> Users { get; set; }

        public QuickOutContext(DbContextOptions<QuickOutContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstabilishmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            // ### Entities Type Configurations

            base.OnModelCreating(modelBuilder);

            // Padrão de Projeto Outbox, sendo implementado com a biblioteca MassTransit
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
