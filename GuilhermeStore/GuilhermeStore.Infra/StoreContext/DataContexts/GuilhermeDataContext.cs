using System;
using System.Data;
using System.Data.SqlClient;
using GuilhermeStore.Shared;

namespace GuilhermeStore.Infra.StoreContext.DataContexts
{
    public class GuilhermeDataContext 
    {
        public SqlConnection Connection { get; set; }

        public GuilhermeDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        // internal IDbConnection NewConnection()
        // {
        //     var connection = new SqlConnection(Settings.ConnectionString);
        //     connection.Open();
        //     return connection;
        // }
    }
}