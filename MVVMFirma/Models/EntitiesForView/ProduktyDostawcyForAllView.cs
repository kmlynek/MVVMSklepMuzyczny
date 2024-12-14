using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ProduktyDostawcyForAllView
    {
        public int ProduktDostawcaID { get; set; }
        public string ProduktyNazwa {  get; set; }
        public decimal? ProduktyCena {get; set; }
        public string DostawcyNazwa { get; set; }
        public string DostawcyKontakt { get; set; } 
    }
}
