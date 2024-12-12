using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DostawcyForAllView
    {
        public int DostawcaID { get; set; }
        public string Nazwa {  get; set; }
        public string Kontakt {  get; set; }
        public string AdresyUlica { get; set; }
        public string AdresyMiasto { get; set; }
        public string AdresyKodPocztowy { get; set; }
    }
}
