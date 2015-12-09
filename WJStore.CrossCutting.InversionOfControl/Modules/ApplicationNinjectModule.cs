using WJStore.Application;
using WJStore.Application.Interfaces;
using Ninject.Modules;

namespace WJStore.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryAppService>().To<CategoryAppService>();
            Bind<IOwnerAppService>().To<OwnerAppService>();
            Bind<IProductAppService>().To<ProductAppService>();
            Bind<ICartAppService>().To<CartAppService>();
            Bind<IOrderAppService>().To<OrderAppService>();
            Bind<IOrderDetailAppService>().To<OrderDetailAppService>();
        }
    }
}
