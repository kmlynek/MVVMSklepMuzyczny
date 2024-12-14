using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class SzczegolyZamowieniaForAllView
    {
        public int SzczegolyID { get; set; }
        public string ZamowieniaKlienciImie { get; set; }
        public string ZamowieniaKlienciNazwisko { get; set; }
        public string ZamowieniaKlienciEmail { get; set; }
        public string ZamowieniaKlienciTelefon { get; set; }
        public string ProduktyNazwa {  get; set; }
        public decimal? ProduktyCena { get; set; }
        public int? Ilosc {  get; set; }
    }
}
