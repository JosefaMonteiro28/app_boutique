using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Domain
{
   public class Caixa
    {
        public int CaixaId { get; set; }
        public string ValorInicial { get; set; }
        public string ValorActual { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFecho { get; set; }
       
        public int UserId { get; set; }
    }



    public class viewCaixa
    {
        public string Nome { get; set; }
        public int CaixaId { get; set; }
        public string ValorInicial { get; set; }
        public string ValorActual { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFecho { get; set; }  
    }
}
