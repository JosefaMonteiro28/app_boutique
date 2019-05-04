using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Boutique.RepositoryADO
{
    class Contexto : IDisposable
    {
        private readonly SqlConnection Connect;
        String StrConnect = Properties.Settings.Default.Boutique;
        public Contexto()
        {
            Connect = new SqlConnection(StrConnect);
            Connect.Open();
        }
        public void Exe(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = System.Data.CommandType.Text,
                Connection = Connect
            };
            cmd.ExecuteNonQuery();

        }

        public SqlDataReader ExeWithRetorno(string query)
        {
            var cmd = new SqlCommand(query, Connect);
            return cmd.ExecuteReader();
        }
        public void Dispose()
        {
            if (Connect.State == System.Data.ConnectionState.Open)
            {
                Connect.Close();
            }
        }
    }
}
