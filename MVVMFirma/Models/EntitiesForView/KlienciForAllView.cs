using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KlienciForAllView
    {
        public int KlientID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string AdresyUlica{ get; set; }
        public string AdresyMiasto { get; set; }
        public string AdresyKodPocztowy {get; set; }
    }
}
