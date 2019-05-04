using Boutique.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Applicacion
{
   public class CategoriaAppConstutor
    {
        public static CategoriaApp CategoriaAppDO()
        {
            return new CategoriaApp(new CategoriaRepositoryADO());
        }
    }
}
