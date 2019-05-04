using Boutique.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Applicacion
{
   public class  ClienteAppConstrutor
    {
        public static ClienteApp ClienteAppDO()
        {
            return new ClienteApp(new ClienteRepositoryADO());
        }
    }
}
