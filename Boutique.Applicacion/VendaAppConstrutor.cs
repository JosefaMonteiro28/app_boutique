using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;
using Boutique.RepositoryADO;

namespace Boutique.Applicacion
{
   public class VendaAppConstrutor
    {
        public static VendaApp VendaAppDO()
        {
            return new VendaApp(new VendaRepositoryADO());
        }
    }
}
