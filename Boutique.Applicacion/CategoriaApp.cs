using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.RepositoryADO;
using Boutique.RepositoryADO.Contrato;
using Boutique.Domain;

namespace Boutique.Applicacion
{
   public class CategoriaApp
    {
        private readonly IRepository<Categoria> repository;

        public CategoriaApp(IRepository<Categoria> repo)
        {
            repository = repo;
        }
        public void Delete(Categoria CategoriaId)
        {
            repository.Delete(CategoriaId);
        }
        public void Save(Categoria categoria)
        {
            repository.Save(categoria);
        }

        public IEnumerable<Categoria> ListarAll()
        {
            return repository.ListarAll();
        }

     
    }
}
