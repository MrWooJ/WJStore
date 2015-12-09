using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WJStore.Application.Interfaces;
using WJStore.Data.Context;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Helpers;
using WJStore.Domain.Validation;

namespace WJStore.Application
{
    public class CartAppService : AppService<WJStoreContext>, ICartAppService
    {
        private readonly ICartService _service;

        public CartAppService(ICartService cartService)
        {
            _service = cartService;
        }

        public ValidationResult Create(Cart cart)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(cart));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Cart cart)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(cart));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(IEnumerable<Cart> carts)
        {
            BeginTransaction();
            carts.ForEach(cart => ValidationResult.Add(_service.Update(cart)));
            if(ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Cart cart)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(cart));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(IEnumerable<Cart> carts)
        {
            BeginTransaction();
            carts.ForEach(cart => ValidationResult.Add(_service.Delete(cart)));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Cart Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Cart> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Cart> Find(Expression<Func<Cart, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}