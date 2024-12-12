using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PlatnosciForAllView
    {
        public int PlatnoscID { get; set; }
        public DateTime? DataPlatnosci { get; set; }
        public decimal? Kwota { get; set; }
        public string MetodaPlatnosci { get; set; }
        public string ZamowieniaStatus { get; set; }

    }
}
