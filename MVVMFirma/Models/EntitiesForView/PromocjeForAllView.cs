using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PromocjeForAllView
    {
        public int PromocjaID { get; set; }
        public string ProduktyNazwa { get; set; }

        public decimal? ProduktyCena {  get; set; }
        public string Opis {  get; set; }
        public decimal? Rabat {  get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }

    }
}
