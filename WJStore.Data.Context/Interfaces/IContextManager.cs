﻿namespace WJStore.Data.Context.Interfaces
{
    public interface IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        IDbContext GetContext();
        void Finish();
    }
}