using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
    public class ProdutoApp
    {
        private readonly IRepository<Produto> repository;

        public ProdutoApp(IRepository<Produto> repo)
        {
            repository = repo;
        }
        public void Delete(Produto ProdutoId)
        {
            repository.Delete(ProdutoId);
        }
        public void Save(Produto produto)
        {
            repository.Save(produto);
        }
        public IEnumerable<Produto> ListarAll()
        {
            return repository.ListarAll();
        }
    }
}
