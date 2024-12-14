using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class StanMagazynowyForAllView
    {
        public int StanID { get; set; }
        public string ProduktyNazwa { get; set; }
        public decimal? ProduktyCena { get; set; }
        public int? Ilosc {  get; set; }
    }
}
