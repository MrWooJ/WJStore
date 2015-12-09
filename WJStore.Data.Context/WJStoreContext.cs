using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WJStore.Data.Context.Config;
using WJStore.Data.Context.Mapping;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context
{
    public class WJStoreContext : BaseDbContext
    {
        static WJStoreContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public WJStoreContext()
            : base("WJStoreEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OwnerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CartMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
        }
  
        #region DbSet

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}