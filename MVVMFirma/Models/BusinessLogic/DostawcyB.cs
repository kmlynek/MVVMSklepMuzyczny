using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DostawcyB : DataBaseClass
    {

        public DostawcyB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetDostawcyKeyAndValueItems()
        {
            return (
                from dostawca in db.Dostawcy
                select new KeyAndValue
                {
                    Key = dostawca.DostawcaID,
                    Value = dostawca.Nazwa + " ; " + dostawca.Kontakt
                }
                ).ToList().AsQueryable();
        }
    }
}
