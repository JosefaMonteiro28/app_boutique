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
    public class VendaRepositoryADO : IRepository<Venda>
    {
        private Contexto contexto;
        public void Delete(Venda venda)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_venda Where VendaId={0}", venda.VendaId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }

        }

        private void Insert(Venda venda)
        {
            var query = "";
            query += "INSERT INTO tb_venda(DataVenda,TotalCobrar,TotalPago,DataAlteracao,ClienteId,UserId)";
            query += string.Format("VALUES({0},'{1}','{2}','{3}','{4}','{5}')", venda.DataVenda, venda.TotalCobrar, venda.TotalPago, venda.DataAlteracao, venda.ClienteId, venda.UserId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public IEnumerable<Venda> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT * FROM tb_venda ORDER BY Venda";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornarDataReader);
        }


        public IEnumerable<Venda> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = "SELECT * FROM tb_venda ORDER BY Venda";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornarDataReader);
        }

        public List<Venda> ListarObject(SqlDataReader reader)
        {
            var Venda = new List<Venda>();
            while (reader.Read())
            {
                var TemObj = new Venda()
                {
                    VendaId = Convert.ToInt32(reader["VendaId"].ToString()),
                    DataVenda = Convert.ToDateTime(reader["DataVenda"].ToString()),
                    TotalCobrar = (reader["TotalCobrar"].ToString()),
                    TotalPago = (reader["TotalPago"].ToString()),
                    DataAlteracao = Convert.ToDateTime(reader["DataAlteracao"].ToString()),
                    ClienteId = Convert.ToInt32(reader["ClienteId"].ToString()),
                    UserId = Convert.ToInt32(reader["UserId"].ToString()),
                };
                Venda.Add(TemObj);
            }
            return Venda;


        }
        public Venda ListarById(string id)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM tb_venda WHERE VendaId={0}", id);
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornarDataReader).FirstOrDefault();
        }

        private void Update(Venda venda)
        {
            var query = "";
            query += "UPDATE tb_venda SET";
            query += string.Format(" DataVenda ='{0}','", venda.DataVenda);
            query += string.Format(" TotalCobrar = '{0}',", venda.TotalCobrar);
            query += string.Format(" TotalPago = '{0}',", venda.TotalPago);
            query += string.Format(" DataAlteracao = '{0}',", venda.DataAlteracao);
            query += string.Format(" ClienteId = '{0}',", venda.ClienteId);
            query += string.Format(" UserId= '{0}'", venda.UserId);
            query += string.Format(" WHERE VendaId= {0}", venda.VendaId);


            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public void Save(Venda venda)
        {
            if (venda.VendaId > 0)
            {
                Update(venda);
            }
            else
            {
                Insert(venda);
            }
        }
    }
}
