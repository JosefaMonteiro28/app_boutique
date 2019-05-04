using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Domain
{
   public class Cliente
    {
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Bi { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Morada { get; set; }
    }

}
