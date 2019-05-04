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
    public class ProdutoRepositoryADO : IRepository<Produto>
    {
        private Contexto contexto;
        private void Insert(Produto produto)
        {
            var query = "";
            query += "INSERT INTO tb_produto(Descricao,CategoriaId,Imagem)";
            query += string.Format("VALUES('{0}','{1}','{2}')", produto.Descricao, produto.CategoriaId, produto.Imagem);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }
        public Produto ListarById(string id)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT *FROM tb_produto WHERE ProdutoId ={0}", id);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornoDataReader).FirstOrDefault();

        }
        public void Update(Produto produto)
        {
            var query = "";
            if (produto.Imagem == null)
            {
                query += "UPDATE tb_produto SET";
                query += string.Format(" Descricao= '{0}',", produto.Descricao);
                query += string.Format(" CategoriaId = {0},", produto.CategoriaId);
                query += string.Format(" WHERE ProdutoId= {0}", produto.ProdutoId);

                using (contexto = new Contexto())
                {
                    contexto.Exe(query);
                }
            }
            else
            {
                query += "UPDATE tb_produto SET";
                query += string.Format(" Descricao= '{0}',", produto.Descricao);
                query += string.Format(" CategoriaId = {0},", produto.CategoriaId);
                query += string.Format(" Imagem= '{0}'", produto.Imagem);
                query += string.Format(" WHERE ProdutoId= {0}", produto.ProdutoId);

                using (contexto = new Contexto())
                {
                    contexto.Exe(query);
                }
            }
        }
        public void Save(Produto produto)
        {
            if (produto.ProdutoId > 0)
            {
                Update(produto);
            }
            else
            {
                Insert(produto);
            }
        }
        public void Delete(Produto produto)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_produto WHERE ProdutoId={0}", produto.ProdutoId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }
        public IEnumerable<Produto> ListarAll()
        {
            contexto = new Contexto();
            var query = "";
            query = "SELECT * FROM tb_produto ORDER BY Descricao";
            var RetornoDaterReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornoDaterReader);
        }
        public IEnumerable<Produto> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = "";
            query = string.Format("SELECT * FROM tb_produto WHERE Descricao = '{0}' ORDER BY Descricao", name);
            var RetornoDaterReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornoDaterReader);
        }
        public List<Produto> ListarObjec(SqlDataReader reader)
        {
            var Produto = new List<Produto>();
            while (reader.Read())
            {
                var Temobj = new Produto()
                {
                    ProdutoId = Convert.ToInt32(reader["ProdutoId".ToString()]),
                    Descricao = (reader["Descricao"].ToString()),
                    CategoriaId = Convert.ToInt32(reader["CategoriaId"].ToString()),
                    Imagem = (reader["Imagem"].ToString()),
                };
                Produto.Add(Temobj);

            }
            return Produto;


        }


        /*LISTA COM VIEW*/
        public IEnumerable<ViewProduto> GetAll()
        {
            contexto = new Contexto();
            var query = "";
            query = "SELECT * FROM View_produto ORDER BY Descricao";
            var RetornoDaterReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornoDaterReader);
        }
        public IEnumerable<ViewProduto> GetByName(string name)
        {
            contexto = new Contexto();
            var query = "";
            query = string.Format("SELECT * FROM View_produto WHERE Descricao LIKE '%{0}%' ORDER BY Descricao", name);
            var RetornoDaterReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornoDaterReader);
        }
        public List<ViewProduto> ListarView(SqlDataReader reader)
        {
            var Produto = new List<ViewProduto>();
            while (reader.Read())
            {
                var Temobj = new ViewProduto()
                {
                    ProdutoId = Convert.ToInt32(reader["ProdutoId"].ToString()),
                    Nome = reader["Descricao"].ToString(),
                    Categoria = reader["DescricaoCategoria"].ToString(),
                    Imagem = reader["Imagem"].ToString(),
                };
                Produto.Add(Temobj);

            }
            return Produto;


        }


    }
}
