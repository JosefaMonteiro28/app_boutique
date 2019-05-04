using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.RepositoryADO.Contrato
{
    public interface IRepository<T> where T : class
    {
        void Save(T entidade);
        void Delete(T entidade);
        IEnumerable<T> ListarAll();
        IEnumerable<T> ListarByName(string name);
       

    }
}
