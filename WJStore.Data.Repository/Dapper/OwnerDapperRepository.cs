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
    public class OwnerDapperRepository : Common.Repository , IOwnerReadOnlyRepository
    {
        public Owner Get(int id)
        {
            using (var cn = WJStoreConnection)
            {
                var owner = cn.Query<Owner>("SELECT * FROM Owner WHERE OwnerId = @OwnerId",
                    new { OwneriId = id }).FirstOrDefault();
                return owner;
            }
        }

        public IEnumerable<Owner> All()
        {
            using (var cn = WJStoreConnection)
            {
                var owner = cn.Query<Owner>("SELECT * FROM Owner");
                return owner;
            }
        }

        public IEnumerable<Owner> Find(Expression<Func<Owner, bool>> predicate)
        {
            using (var cn = WJStoreConnection)
            {
                var owner = cn.GetList<Owner>(predicate);
                return owner;
            }
        }
    }
}
