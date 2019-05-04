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
    public class StockRepositoryADO : IRepository<Stock>
    {
        private Contexto contexto;
        public void Delete(Stock stock)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_stock Where StockId={0}", stock.StockId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        private void Insert(Stock stock)
        {
            var dataFormatada = stock.DataCriacao.Year + "/" + stock.DataCriacao.Month + "/" + stock.DataCriacao.Day + " " + stock.DataCriacao.ToLongTimeString();
            var query = "";
            query += "INSERT INTO tb_stock (QtdEncomendada,QtdExistente,QtdMinima,DataCriacao,PrecoCompra,PrecoVenda,ProdutoId)";
            query += string.Format("VALUES({0},{1},{2},'{3}',{4},{5},{6})", stock.QtdEncomendada, stock.QtdExistente, stock.QtdMinima, dataFormatada, stock.PrecoCompra, stock.PrecoVenda, stock.ProdutoId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public IEnumerable<Stock> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_stock ORDER BY DataCriacao";
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornoDataReader);
        }


        public IEnumerable<Stock> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_stock ORDER BY DataCriacao";
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornoDataReader);
        }

        public List<Stock> ListarObject(SqlDataReader reader)
        {
            var Stock = new List<Stock>();
            while (reader.Read())
            {
                var TemObj = new Stock()
                {
                    StockId = Convert.ToInt32(reader["StockId"].ToString()),
                    QtdEncomendada = Convert.ToInt32(reader["QtdEncomendada"].ToString()),
                    QtdExistente = Convert.ToInt32(reader["QtdExistente"].ToString()),
                    QtdMinima = Convert.ToInt32(reader["QtdMinima"].ToString()),
                    DataCriacao = Convert.ToDateTime(reader["DataCriacao"].ToString()),
                    PrecoCompra = (reader["PrecoCompra"].ToString()),
                    PrecoVenda = (reader["PrecoVenda"].ToString()),
                    ProdutoId = Convert.ToInt32(reader["ProdutoId"].ToString()),
                };
                Stock.Add(TemObj);
            }
            return Stock;
        }

        public Stock ListarById(string id)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT *FROM tb_stock WHERE StockId={0}", id);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarObject(RetornoDataReader).FirstOrDefault();
        }


        #region LISTAR COM VIEW ===

        public List<ViewStock> ListarView(SqlDataReader reader)
        {
            var Stock = new List<ViewStock>();
            while (reader.Read())
            {
                var TemObj = new ViewStock()
                {
                    Produto = reader["Descricao"].ToString(),
                    StockId = Convert.ToInt32(reader["StockId"].ToString()),
                    QtdEncomendada = Convert.ToInt32(reader["QtdEncomendada"].ToString()),
                    QtdExistente = Convert.ToInt32(reader["QtdExistente"].ToString()),
                    QtdMinima = Convert.ToInt32(reader["QtdMinima"].ToString()),
                    DataCriacao = Convert.ToDateTime(reader["DataCriacao"].ToString()),
                    PrecoCompra = (reader["PrecoCompra"].ToString()),
                    PrecoVenda = (reader["PrecoVenda"].ToString()),      
                };
                Stock.Add(TemObj);
            }
            return Stock;
        }

        public IEnumerable<ViewStock> GetAll()
        {
            contexto = new Contexto();
            var query = "SELECT * FROM viewStock  ORDER BY DataCriacao";
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornoDataReader);
        }

        public IEnumerable<ViewStock> GetByName(string name)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM viewStock WHERE Descricao LIKE '%{0}%' OR QtdEncomendada LIKE '%{0}%' OR QtdExistente LIKE '%{0}%' OR QtdMinima LIKE '%{0}%' ORDER BY DataCriacao", name);
            var RetornoDataReader = contexto.ExeWithRetorno(query);
            return ListarView(RetornoDataReader);
        }



        #endregion

        private void Update(Stock stock)
        {
            var dataFormatada = stock.DataCriacao.Year + "/" + stock.DataCriacao.Month + "/" + stock.DataCriacao.Day + " " + stock.DataCriacao.ToLongTimeString();
            var query = "";
            query += "UPDATE tb_stock SET";
            query += string.Format(" QtdEncomendada = {0},", stock.QtdEncomendada);
            query += string.Format(" QtdExistente = {0},", stock.QtdExistente);
            query += string.Format(" QtdMinima = {0},", stock.QtdMinima);
            query += string.Format(" DataCriacao = '{0}',", dataFormatada);
            query += string.Format(" PrecoCompra = {0},", stock.PrecoCompra);
            query += string.Format(" PrecoVenda = {0},", stock.PrecoVenda);
            query += string.Format(" ProdutoId = {0}", stock.ProdutoId);
            query += string.Format(" WHERE StockId= {0}", stock.StockId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public void Save(Stock stock)
        {
            if (stock.StockId > 0)
            {
                Update(stock);
            }
            else
            {
                Insert(stock);
            }
        }
    }
}
