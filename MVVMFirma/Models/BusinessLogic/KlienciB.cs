using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KlienciB : DataBaseClass
    {

        public KlienciB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetKlienciKeyAndValueItems()
        {
            return (
                from klient in db.Klienci
                select new KeyAndValue
                {
                    Key = klient.KlientID,
                    Value = klient.Imie + " ; " + klient.Nazwisko + " ; " + klient.Email + " ; " + klient.Telefon
                }
                ).ToList().AsQueryable();
        }
    }
}
