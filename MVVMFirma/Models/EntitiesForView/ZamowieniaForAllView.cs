using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ZamowieniaForAllView
    {
        public int ZamowienieID { get; set; }
        public string KlienciEmail { get; set; }
        public string KlienciTelefon { get; set; }
        public DateTime? DataZamowienia {  get; set; }
        public string Status { get; set; }
        public decimal? KwotaLaczna { get; set; }


    }
}
