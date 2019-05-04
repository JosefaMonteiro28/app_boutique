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
    public class CategoriaRepositoryADO : IRepository<Categoria>
    {
        private Contexto contexto;

        public void Delete(Categoria categoria)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_categoria WHERE CategoriaId = {0}", categoria.CategoriaId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        private void Insert(Categoria categoria)
        {

            var query = "";
            query += "INSERT INTO tb_categoria(DescricaoCategoria)";
            query += string.Format("VALUES('{0}')", categoria.DescricaoCategoria);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }


        public IEnumerable<Categoria> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT * FROM tb_categoria ORDER BY DescricaoCategoria";
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListObjec(RetornoDataReader);
        }

        public IEnumerable<Categoria> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM tb_categoria WHERE DescricaoCategoria = '{0}' ORDER BY DescricaoCategoria", name);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListObjec(RetornoDataReader);
        }

        public Categoria ListarById(string id)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT *FROM tb_Categoria WHERE CategoriaId= '{0}'", id);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListObjec(RetornoDataReader).FirstOrDefault();
        }

        private List<Categoria> ListObjec(SqlDataReader reader)
        {
            var Categoria = new List<Categoria>();
            while (reader.Read())
            {
                var TemObj = new Categoria()

                {
                    CategoriaId = Convert.ToInt32(reader["CategoriaId"].ToString()),
                    DescricaoCategoria = (reader["DescricaoCategoria"].ToString()),

                };

                Categoria.Add(TemObj);
            }
            return Categoria;
        }

        private void Update(Categoria categoria)
        {
            var query = "";
            query += "UPDATE tb_categoria SET";
            query += string.Format(" DescricaoCategoria = '{0}'", categoria.DescricaoCategoria);
            query += string.Format(" WHERE CategoriaId= {0}", categoria.CategoriaId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }


        public void Save(Categoria categoria)
        {
            if (categoria.CategoriaId > 0)
            {
                Update(categoria);
            }
            else
            {
                Insert(categoria);
            }
        }
    }
}
