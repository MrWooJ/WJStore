﻿using WJStore.Data.Repository.EntityFramework.Common;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;

namespace WJStore.Data.Repository.EntityFramework
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
    }
}
