using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
  public  class VendaApp
    {
        private readonly IRepository<Venda> repository;

        public VendaApp(IRepository<Venda> repo)
        {
            repository = repo;
        }
        public void Delete(Venda VendaId)
        {
            repository.Delete(VendaId);
        }
        public void Save(Venda venda)
        {
            repository.Save(venda);
        }
        public IEnumerable<Venda> ListarAll()
        {
            return repository.ListarAll();
        }
    }
}
