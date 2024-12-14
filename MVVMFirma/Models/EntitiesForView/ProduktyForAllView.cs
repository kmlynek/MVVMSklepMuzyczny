using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ProduktyForAllView
    {
        public int ProduktID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal? Cena { get; set; }
        public string KategorieNazwa { get; set; }
        public string KategorieOpis { get; set; }
    }
}
