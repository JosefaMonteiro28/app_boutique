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
    public class CaixaRepositoryADO : IRepository<Caixa>
    {
        private Contexto contexto;
        private void Insert(Caixa caixa)
        {
            var dataAbertura = caixa.HoraAbertura.Year + "/" + caixa.HoraAbertura.Month + "/" + caixa.HoraAbertura.Day + " " + caixa.HoraAbertura.ToLongTimeString();
            var dataFechadura = caixa.HoraAbertura.Year + "/" + caixa.HoraAbertura.Month + "/" + caixa.HoraAbertura.Day + " " + caixa.HoraAbertura.ToLongTimeString();
            var query = "";
            query += "INSERT INTO tb_caix (HoraAbertura,HoraFecho,ValorInicial,ValorActual,UserId) ";
            query += string.Format("VALUES('{0}','{1}',{2},{3},{4})", dataAbertura, dataFechadura, caixa.ValorInicial, caixa.ValorActual, caixa.UserId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }
        public void Delete(Caixa caixa)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_caix Where CaixaId ={0}", caixa.CaixaId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }     
        public void Save(Caixa caixa)
        {
            if (caixa.CaixaId > 0)
            {
                Update(caixa);
            }
            else
            {
                Insert(caixa);
            }
        }
        public IEnumerable<Caixa> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_caix ORDER BY CaixaId";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornarDataReader);
        }
        public IEnumerable<Caixa> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_caix ORDER BY CaixaId";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornarDataReader);
        }
        private List<Caixa> ListarObjec(SqlDataReader reader)
        {
            var Usuario = new List<Caixa>();
            while (reader.Read())
            {
                var TemObje = new Caixa()
                {
                    CaixaId = Convert.ToInt32(reader["CaixaId"].ToString()),
                    HoraAbertura = Convert.ToDateTime(reader["HoraAbertura"].ToString()),
                    HoraFecho = Convert.ToDateTime(reader["HoraFecho"].ToString()),
                    ValorInicial = (reader["ValorInicial"].ToString()),
                    ValorActual = (reader["ValorActual"].ToString()),
                    UserId = Convert.ToInt32(reader["UserId"].ToString()),

                };
                Usuario.Add(TemObje);
            }
            return Usuario;
        }
        
        private void Update(Caixa caixa)
        {
            var dataAbertura = caixa.HoraAbertura.Year + "/" + caixa.HoraAbertura.Month + "/" + caixa.HoraAbertura.Day + " " + caixa.HoraAbertura.ToLongTimeString();
            var dataFechadura = caixa.HoraAbertura.Year + "/" + caixa.HoraAbertura.Month + "/" + caixa.HoraAbertura.Day + " " + caixa.HoraAbertura.ToLongTimeString();
            var query = "";
            query += "UPDATE tb_caix SET";
            query += string.Format(" HoraAbertura = '{0}',", dataAbertura);
            query += string.Format(" HoraFecho = '{0}',", dataFechadura);
            query += string.Format(" ValorInicial = {0},", caixa.ValorInicial);
            query += string.Format(" ValorActual = {0},", caixa.ValorActual);
            query += string.Format(" UserId = {0}", caixa.UserId);
            query += string.Format(" WHERE CaixaId = {0}", caixa.CaixaId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        /*LISTAR COM VIEWS*/
        private List<viewCaixa> ListarView(SqlDataReader reader)
        {
            var Usuario = new List<viewCaixa>();
            while (reader.Read())
            {
                var TemObje = new viewCaixa()
                {
                    Nome = reader["Nome"].ToString(),
                    CaixaId = Convert.ToInt32(reader["CaixaId"].ToString()),
                    HoraAbertura = Convert.ToDateTime(reader["HoraAbertura"].ToString()),
                    HoraFecho = Convert.ToDateTime(reader["HoraFecho"].ToString()),
                    ValorInicial = (reader["ValorInicial"].ToString()),
                    ValorActual = (reader["ValorActual"].ToString()),
                };
                Usuario.Add(TemObje);
            }
            return Usuario;
        }
        public IEnumerable<viewCaixa> GetAll()
        {
            contexto = new Contexto();
            var query = "SELECT * FROM View_Caixa ORDER BY CaixaId";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornarDataReader);
        }
        public IEnumerable<viewCaixa> GetByName(string name)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM View_Caixa WHERE Nome Like '%{0}%' ORDER BY Nome",name);
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornarDataReader);
        }


    }
}
