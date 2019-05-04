using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;

namespace Boutique.Applicacion
{
   public class UsuarioApp
    {
        private readonly IRepository<Usuario> repository;

        public UsuarioApp(IRepository<Usuario> repo)
        {
            repository = repo;
        }
        public void Delete(Usuario UsuarioId)
        {
            repository.Delete(UsuarioId);
        }
        public void Save(Usuario usuario)
        {
            repository.Save(usuario);
        }
        public IEnumerable<Usuario> ListarAll()
        {
            return repository.ListarAll();
        }
        public IEnumerable<Usuario> ListarByName(string name)
        {
            return repository.ListarByName(name);
        }
    }
}
