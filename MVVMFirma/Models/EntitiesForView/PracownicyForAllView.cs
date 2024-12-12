using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PracownicyForAllView
    {
        public int PracownikID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Stanowisko { get; set; }
        public decimal? Wynagrodzenie { get; set; }
        public string AdresyUlica { get; set; }
        public string AdresyMiasto { get; set; }
        public string AdresyKodPocztowy { get; set; }

    }
}
