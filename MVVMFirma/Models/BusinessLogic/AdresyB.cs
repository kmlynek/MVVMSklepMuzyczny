using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class AdresyB : DataBaseClass
    {

        public AdresyB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetAdresyKeyAndValueItems()
        {
            return (
                from adres in db.Adresy
                select new KeyAndValue
                {
                    Key = adres.AdresID,
                    Value = adres.Ulica + " ; " + adres.KodPocztowy + " ; " + adres.Miasto
                }
                ).ToList().AsQueryable();
        }
    }
}
