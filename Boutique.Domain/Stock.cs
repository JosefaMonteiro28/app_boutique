using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Domain
{
   public class Stock
    {
        public int StockId { get; set; }
        public int QtdEncomendada { get; set; }
        public int QtdExistente { get; set; }
        public int QtdMinima { get; set; }
        public DateTime DataCriacao { get; set; }
        public string PrecoCompra { get; set; }
        public string PrecoVenda { get; set; }
        public int ProdutoId { get; set; }
    }


    public class ViewStock
    {
        public string Produto { get; set; }
        public int StockId { get; set; }
        public int QtdEncomendada { get; set; }
        public int QtdExistente { get; set; }
        public int QtdMinima { get; set; }
        public string PrecoCompra { get; set; }
        public string PrecoVenda { get; set; }
        public DateTime DataCriacao { get; set; }

     
    }
}
