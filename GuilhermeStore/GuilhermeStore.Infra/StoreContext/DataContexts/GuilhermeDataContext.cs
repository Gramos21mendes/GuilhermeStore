using System;
using System.Data;
using System.Data.SqlClient;
using GuilhermeStore.Shared;

namespace GuilhermeStore.Infra.StoreContext.DataContexts
{
    public class GuilhermeDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public GuilhermeDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}