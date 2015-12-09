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
    public class OrderDetailDapperRepository : Common.Repository , IOrderDetailReadOnlyRepository
    {
        public OrderDetail Get(int id)
        {
            using (var cn = WJStoreConnection)
            {
                var orderDetail = cn.Query<OrderDetail, Order, Product, OrderDetail>
                    ("SELECT * " +
                     "  FROM OrderDetail OD" +
                     "  JOIN Order O ON O.OrderId = OD.OrderId" +
                     "  JOIN Product A ON A.ProductId = OD.ProductId" +
                     " WHERE C.OrderDetailId = @OrderDetailId",
                        (od, o, a) =>
                        {
                            od.Order = o;
                            od.Product = a;
                            return od;
                        },
                        new { OrderDetailId = id }, splitOn: "OrderDetailId,OrderId,ProductId")
                    .FirstOrDefault();
                return orderDetail;
            }
        }

        public IEnumerable<OrderDetail> All()
        {
            using (var cn = WJStoreConnection)
            {
                var orderDetails = cn.Query<OrderDetail, Order, Product, OrderDetail>
                    ("SELECT * " +
                     "  FROM OrderDetail OD" +
                     "  JOIN Order O ON O.OrderId = OD.OrderId" +
                     "  JOIN Product A ON A.ProductId = OD.ProductId",
                        (od, o, a) =>
                        {
                            od.Order = o;
                            od.Product = a;
                            return od;
                        },
                        splitOn: "OrderDetailId,OrderId,ProductId")
                    .ToList();
                return orderDetails;
            }
        }

        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> predicate)
        {
            using (var cn = WJStoreConnection)
            {
                var orderDetails = cn.GetList<OrderDetail>(predicate);
                return orderDetails;
            }
        }
    }
}
