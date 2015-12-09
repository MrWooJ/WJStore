using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WJStore.Application.Interfaces;
using WJStore.Data.Context;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Validation;

namespace WJStore.Application
{
    public class ProductAppService : AppService<WJStoreContext>, IProductAppService
    {
        private readonly IProductService _service;

        public ProductAppService(IProductService productService)
        {
            _service = productService;
        }

        public ValidationResult Create(Product orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Product orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Product orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Product Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Product> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Product> GetTopSellingProducts(int count)
        {
            // Group the order details by product and return
            // the products with the highest count
            return _service.All()
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}