using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;
using System.Data.SqlClient;

namespace Boutique.RepositoryADO
{
    public class ClienteRepositoryADO : IRepository<Cliente>
    {
        private Contexto contexto;

        public void Delete(Cliente cliente)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_cliente WHERE ClienteId={0}", cliente.ClienteId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        private void Insert(Cliente cliente)
        {
            var query = "";
            query += "INSERT INTO tb_cliente(NomeCliente,Bi,Email,DataNascimento,Morada) ";
            query += string.Format("VALUES ('{0}','{1}','{2}','{3}','{4}')", cliente.NomeCliente, cliente.Bi, cliente.Email, cliente.DataNascimento, cliente.Morada);
           
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public IEnumerable<Cliente> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT * FROM tb_cliente ORDER BY NomeCliente";
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornoDataReader);
        }

      

        public IEnumerable<Cliente> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM tb_cliente WHERE NomeCliente LIKE '%{0}%' ORDER BY NomeCliente", name);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornoDataReader);
        }

        public List<Cliente> ListarObjec(SqlDataReader reader)
        {
            var Cliente = new List<Cliente>();

            while (reader.Read())
            {
                var TemObj = new Cliente()
                {
                    ClienteId = Convert.ToInt32(reader["ClienteId"].ToString()),
                    NomeCliente = (reader["NomeCliente"].ToString()),
                    Bi = (reader["Bi"].ToString()),
                    Email = (reader["Email"].ToString()),
                    DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString()).ToShortDateString(),
                    Morada = (reader["Morada"].ToString()),
                };
                Cliente.Add(TemObj);
            }
            return Cliente;
        }

     

        private void Update(Cliente cliente)
        {
            var query = "";
            query += "UPDATE tb_cliente SET";
            query += string.Format(" NomeCliente = '{0}',", cliente.NomeCliente);
            query += string.Format(" Bi = '{0}',", cliente.Bi);
            query += string.Format(" Email = '{0}',", cliente.Email);
            query += string.Format(" DataNascimento = '{0}',", cliente.DataNascimento);
            query += string.Format(" Morada = '{0}'", cliente.Morada);
            query += string.Format(" WHERE ClienteId = {0} ", cliente.ClienteId);

         
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }
        public void Save(Cliente cliente)
        {
            if (cliente.ClienteId > 0)
            {
                Update(cliente);
            }
            else
            {
                Insert(cliente);
            }
        }

        public Cliente ListarById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
