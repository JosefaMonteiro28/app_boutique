using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.RepositoryADO;

namespace Boutique.Applicacion
{
   public class StockAppConstrutor
    {
        public static StockApp SctoAppADO()
        {
            return new StockApp(new StockRepositoryADO());
        }
    }
}
