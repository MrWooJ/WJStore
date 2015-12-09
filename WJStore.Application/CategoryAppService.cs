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
    public class CategoryAppService : AppService<WJStoreContext>, ICategoryAppService
    {
        private readonly ICategoryService _service;

        public CategoryAppService(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        public ValidationResult Create(Category category)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(category));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Category category)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(category));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Category category)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(category));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Category Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public Category GetWithProducts(string categoryName)
        {
            return _service.GetWithProducts(categoryName);
        }

        public IEnumerable<Category> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}