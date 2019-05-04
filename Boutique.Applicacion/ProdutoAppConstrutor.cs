using Boutique.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Applicacion
{
   public class ProdutoAppConstrutor
    {
        public static ProdutoApp ProdutoAppDO()
        {
            return new ProdutoApp(new ProdutoRepositoryADO());
        }
    }
}
