using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RecenzjeForAllView
    {
        public int RecenzjaID { get; set; }
        public string ProduktyNazwa {  get; set; }
        public string KlienciImie {get; set; }
        public int? Ocena { get; set; }
        public string Komentarz { get; set; }
        public DateTime? DataRecenzji { get; set; }
    }
}
