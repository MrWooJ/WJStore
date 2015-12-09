using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Interfaces.Service.Common;
using WJStore.Domain.Services;
using WJStore.Domain.Services.Common;
using Ninject.Modules;

namespace WJStore.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IService<>)).To(typeof (Service<>));

            Bind<ICategoryService>().To<CategoryService>();
            Bind<IOwnerService>().To<OwnerService>();
            Bind<IProductService>().To<ProductService>();
            Bind<ICartService>().To<CartService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IOrderDetailService>().To<OrderDetailService>();
        }
    }
}
