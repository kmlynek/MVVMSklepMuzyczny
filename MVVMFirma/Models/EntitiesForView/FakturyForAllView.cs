using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    //ta klasa jest wzorowana na klasie Faktura, tylko zamiast kluczy obcych ma czytelne dla Klienta pola (klucze obce będą zastąpione czytelnymi dla zwykłego człowieka danymi
    public class FakturyForAllView
    {
        public int FakturaID { get; set; }
        public string KlienciZamowieniaImie { get; set; }
        public string KlienciZamowieniaNazwisko { get; set; }
        public string KlienciZamowieniaEmail { get; set; }
        public string KlienciZamowieniaTelefon { get; set; }
        public DateTime? ZamowieniaDataZamowienia { get; set; }

        public string ZamowieniaStatus { get; set; }
        public decimal? ZamowieniaKwotaLaczna { get; set; }

    }
}
