using Boutique.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Applicacion
{
   public class UsuarioAppConstrutor
    {
        public static UsuarioApp UsuarioAppDO()
        {
            return new UsuarioApp(new UsuarioRepositoryADO());
        }
    }
}
