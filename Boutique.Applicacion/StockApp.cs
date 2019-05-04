using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
    public class StockApp
    {
        private readonly IRepository<Stock> repository;

        public StockApp(IRepository<Stock> repo)
        {
            repository = repo;
        }
        public void Delete(Stock StockId)
        {
            repository.Delete(StockId);
        }
        public void Save(Stock stock)
        {
            repository.Save(stock);
        }

        public IEnumerable<Stock> ListarAll()
        {
            return repository.ListarAll();
        }

       
    }
}
