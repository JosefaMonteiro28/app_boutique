using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Domain
{
   public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public string Imagem { get; set; }

    }


    public class ViewProduto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }

    }
}
