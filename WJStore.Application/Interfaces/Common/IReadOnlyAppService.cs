﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WJStore.Application.Interfaces.Common
{
    public interface IReadOnlyAppService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}