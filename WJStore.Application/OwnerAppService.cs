using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WJStore.Application.Interfaces;
using WJStore.Data.Context;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Validation;

namespace WJStore.Application
{
    public class OwnerAppService : AppService<WJStoreContext>, IOwnerAppService
    {
        private readonly IOwnerService _service;

        public OwnerAppService(IOwnerService ownerService)
        {
            _service = ownerService;
        }

        public ValidationResult Create(Owner owner)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(owner));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Owner owner)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(owner));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Owner owner)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(owner));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Owner Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Owner> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Owner> Find(Expression<Func<Owner, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}