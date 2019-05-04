using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
  public  class ClienteApp
    {
        private readonly IRepository<Cliente> repository;

        public ClienteApp(IRepository<Cliente> repo)
        {
            repository = repo;
        }
        public void Delete(Cliente ClienteId)
        {
            repository.Delete(ClienteId);
        }
        public void Save(Cliente cliente)
        {
            repository.Save(cliente);
        }

        public IEnumerable<Cliente> ListarAll()
        {
            return repository.ListarAll();
        }

        public IEnumerable<Cliente> ListarByName(string name)
        {
            return repository.ListarByName(name);
        }

       
    }
}
