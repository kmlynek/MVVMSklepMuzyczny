using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DataBaseClass  //Odpowiada za połączenie z bazą danych
    {
        #region Context
        public SklepMuzycznyEntities db { get; set; }
        #endregion
        #region Konstruktor
        public DataBaseClass(SklepMuzycznyEntities db)
        {
            this.db = db;
        }
        #endregion
    }
}