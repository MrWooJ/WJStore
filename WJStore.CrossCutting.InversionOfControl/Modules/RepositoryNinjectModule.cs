using WJStore.Data.Repository.Dapper;
using WJStore.Data.Repository.EntityFramework;
using WJStore.Data.Repository.EntityFramework.Common;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.Common;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using Ninject.Modules;

namespace WJStore.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepository<>)).To(typeof (Repository<>));

            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICategoryReadOnlyRepository>().To<CategoryDapperRepository>();
            Bind<IReadOnlyRepository<Category>>().To<CategoryDapperRepository>();

            Bind<IOwnerRepository>().To<OwnerRepository>();
            Bind<IOwnerReadOnlyRepository>().To<OwnerDapperRepository>();
            Bind<IReadOnlyRepository<Owner>>().To<OwnerDapperRepository>();

            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IProductReadOnlyRepository>().To<ProductDapperRepository>();
            Bind<IReadOnlyRepository<Product>>().To<ProductDapperRepository>();

            Bind<ICartRepository>().To<CartRepository>();
            Bind<ICartReadOnlyRepository>().To<CartDapperRepository>();
            Bind<IReadOnlyRepository<Cart>>().To<CartDapperRepository>();

            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IOrderReadOnlyRepository>().To<OrderDapperRepository>();
            Bind<IReadOnlyRepository<Order>>().To<OrderDapperRepository>();

            Bind<IOrderDetailRepository>().To<OrderDetailRepository>();
            Bind<IOrderDetailReadOnlyRepository>().To<OrderDetailDapperRepository>();
            Bind<IReadOnlyRepository<OrderDetail>>().To<OrderDetailDapperRepository>();
        }
    }
}
