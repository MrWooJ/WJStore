using Microsoft.Practices.ServiceLocation;
using WJStore.Application.Interfaces.Common;
using WJStore.Data.Context.Interfaces;
using WJStore.Domain.Validation;

namespace WJStore.Application
{
    public class AppService<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public AppService()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }

}
