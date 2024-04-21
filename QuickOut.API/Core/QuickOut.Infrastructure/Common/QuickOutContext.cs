using MassTransit;
using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Common;
using QuickOut.Domain.Estabilishments;
using QuickOut.Domain.Orders;
using QuickOut.Domain.Products;
using QuickOut.Domain.Users;
using QuickOut.Infrastructure.Estabilishments;
using QuickOut.Infrastructure.Orders;
using QuickOut.Infrastructure.Products;
using QuickOut.Infrastructure.Users;

namespace QuickOut.Infrastructure.Common
{
    public class QuickOutContext : DbContext, IUserDbContext, IEstabilishmentDbContext, IProductDbContext, IOrderDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Estabilishment> Estabilishments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; }


        public QuickOutContext(DbContextOptions<QuickOutContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstabilishmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            // ### Entities Type Configurations

            base.OnModelCreating(modelBuilder);

            // Padrão de Projeto Outbox, sendo implementado com a biblioteca MassTransit
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
