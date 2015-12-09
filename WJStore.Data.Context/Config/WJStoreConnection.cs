using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WJStore.Data.Context.Config
{
    public class WJStoreConnection : DbConnection
    {
        private readonly SqlConnection _connection;
        public WJStoreConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _connection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            _connection.Close();
        }

        public override void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public override void Open()
        {
            _connection.Open();
        }

        public override string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }

        public override string Database
        {
            get { return _connection.Database; }
        }

        public override ConnectionState State
        {
            get { return _connection.State; }
        }

        public override string DataSource
        {
            get { return _connection.DataSource; }
        }

        public override string ServerVersion
        {
            get { return _connection.ServerVersion; }
        }

        protected override DbCommand CreateDbCommand()
        {
            return _connection.CreateCommand();
        }
    }
}
