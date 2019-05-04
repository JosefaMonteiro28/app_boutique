using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Domain
{
   public class Venda
    {
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public string TotalCobrar { get; set; }
        public string TotalPago { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int ClienteId { get; set; }
        public int UserId { get; set; }
    }
}
