using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
  public class CaixaApp
    {
        private readonly IRepository<Caixa> repository;

        public CaixaApp(IRepository<Caixa> repo)
        {
            repository = repo;
        }
        public void Delete(Caixa CaixaId)
        {
            repository.Delete(CaixaId);
        }

        public void Save(Caixa caixa)
        {
            repository.Save(caixa);
        }

        public IEnumerable<Caixa> ListarAll()
        {
            return repository.ListarAll();
        }

        public IEnumerable<Caixa> ListarByName(string name)
        {
            return repository.ListarByName(name);
        }

      

    }
}
