using System;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace WJStore.Data.Repository.Dapper.Common
{
    public class Repository : IDisposable
    {
        public IDbConnection WJStoreConnection
        {
            get { return new SqlCeConnection(ConfigurationManager.ConnectionStrings["WJStoreEntities"].ConnectionString); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
