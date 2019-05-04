using Boutique.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Applicacion
{
  public class CaixaAppConstrutor
    {
        public static CaixaApp CaixaAppDO()
        {
            return new CaixaApp(new CaixaRepositoryADO());
        }
    }
}
