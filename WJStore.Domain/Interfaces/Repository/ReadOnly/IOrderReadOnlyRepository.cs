﻿using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository.Common;

namespace WJStore.Domain.Interfaces.Repository.ReadOnly
{
    public interface IOrderReadOnlyRepository : IReadOnlyRepository<Order>
    {
         
    }
}