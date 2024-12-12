using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ElementyKoszykaForAllView
    {
        public int ElementID { get; set; }
        public int? Ilosc {  get; set; }
        public string ProduktyNazwa { get; set; }
        public decimal? ProduktyCena { get; set; }


    }
}
