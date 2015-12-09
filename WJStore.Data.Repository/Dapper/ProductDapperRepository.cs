using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository.ReadOnly;

namespace WJStore.Data.Repository.Dapper
{
    public class ProductDapperRepository : Common.Repository , IProductReadOnlyRepository
    {
        public Product Get(int id)
        {
            using (var cn = WJStoreConnection)
            {
                var product = cn.Query<Product, Owner, Category, Product>
                    ("SELECT * " +
                     "  FROM Product Al" +
                     "  JOIN Owner Ar ON Ar.OwnerId = Al.OwnerId" +
                     "  JOIN Category Ge ON Ge.CategoryId = Al.CategoryId" +
                     " WHERE Al.ProductId = @ProductId",
                        (al, ar, ge) =>
                        {
                            al.Owner = ar;
                            al.Category = ge;
                            return al;
                        },
                        new {ProductId = id}, splitOn: "ProductId, OwnerId, CategoryId").FirstOrDefault();
                return product;
            }
        }

        public IEnumerable<Product> All()
        {
            using (var cn = WJStoreConnection)
            {
                var albuns = cn.Query<Product, Owner, Category, Product>
                    ("SELECT * " +
                     "  FROM Product Al" +
                     "  JOIN Owner Ar ON Ar.OwnerId = Al.OwnerId" + 
                     "  JOIN Category Ge ON Ge.CategoryId = Al.CategoryId",
                        (al, ar, ge) =>
                        {
                            al.Owner = ar;
                            al.Category = ge;
                            return al;
                        },
                        splitOn: "ProductId, OwnerId, CategoryId");
                return albuns;
            }
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            using (var cn = WJStoreConnection)
            {
                var albuns = cn.GetList<Product>(predicate);
                return albuns;
            }
        }
    }
}
