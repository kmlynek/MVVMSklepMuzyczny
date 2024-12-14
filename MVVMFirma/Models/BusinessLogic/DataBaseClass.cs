using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DataBaseClass
    {
        public SklepMuzycznyEntities db { get; set; }

        public DataBaseClass(SklepMuzycznyEntities db)
        {
            this.db = db;
        }
    }
}