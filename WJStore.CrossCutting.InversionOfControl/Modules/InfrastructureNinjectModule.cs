using WJStore.Data.Context;
using WJStore.Data.Context.Interfaces;
using Ninject.Modules;

namespace WJStore.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<WJStoreContext>();
            Bind(typeof (IContextManager<>)).To(typeof (ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));
        }
    }
}
