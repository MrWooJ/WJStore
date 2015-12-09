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
    public class CategoryDapperRepository : Common.Repository, ICategoryReadOnlyRepository
    {
        public Category Get(int id)
        {
            using (var cn = WJStoreConnection)
            {
                var categories = cn.Query<Category>("SELECT * FROM Category WHERE CategoryId = @CategoryId",
                    new {CategoryId = id}).FirstOrDefault();
                return categories;
            }
        }

        public Category GetWithProducts(string categoryName)
        {
            using (var cn = WJStoreConnection)
            {
                var dr = cn.ExecuteReader(
                    "SELECT * " +
                    "  FROM Category G" +
                    "  JOIN Product A ON A.CategoryId = G.CategoryId" +
                    " WHERE G.Name = @Name", new {Name = categoryName});

                Category category = null;
                while (dr.Read())
                {
                    if (category == null)
                    {
                        category = new Category
                        {
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString()
                        };
                    }

                    category.Products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Title = dr["Title"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        ProductArtUrl = dr["ProductArtUrl"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        Category = category
                    });
                }
                return category;
            }
        }

        public IEnumerable<Category> All()
        {
            using (var cn = WJStoreConnection)
            {
                var category = cn.Query<Category>("SELECT * FROM Category");
                return category;
            }
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            using (var cn = WJStoreConnection)
            {
                var categories = cn.GetList<Category>(predicate);
                return categories;
            }
        }
    }
}
