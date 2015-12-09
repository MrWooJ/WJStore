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
    public class CartDapperRepository : Common.Repository , ICartReadOnlyRepository
    {
        public Cart Get(int id)
        {
            using (var cn = WJStoreConnection)
            {
                var cart = cn.Query<Cart, Product, Cart>
                    ("SELECT * " +
                     "  FROM Cart C" +
                     "  JOIN Product A ON A.ProductId = C.ProductId" +
                     " WHERE C.CartId = @CartId",
                        (c, a) =>
                        {
                            c.Product = a;
                            return c;
                        },
                        new { CartId = id }, splitOn: "CartId,ProductId")
                    .FirstOrDefault();
                return cart;
            }
        }

        public IEnumerable<Cart> All()
        {
            using (var cn = WJStoreConnection)
            {
                var carts = cn.Query<Cart, Product, Cart>
                    ("SELECT * " +
                     "  FROM Cart C" +
                     "  JOIN Product A ON A.ProductId = C.ProductId",
                        (c, a) =>
                        {
                            c.Product = a;
                            return c;
                        },
                        null, splitOn: "CartId,ProductId")
                    .ToList();
                return carts;
            }
        }

        public IEnumerable<Cart> Find(Expression<Func<Cart, bool>> predicate)
        {
            using (var cn = WJStoreConnection)
            {
                var carts = cn.GetList<Cart>(predicate);
                return carts;
            }
        }
    }
}
