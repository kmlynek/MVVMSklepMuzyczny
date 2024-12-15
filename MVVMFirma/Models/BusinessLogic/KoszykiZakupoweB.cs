using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KoszykiZakupoweB : DataBaseClass
    {

        public KoszykiZakupoweB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetKoszykiZakupoweKeyAndValueItems()
        {
            return (
                from koszykZakupowy in db.KoszykiZakupowe
                select new KeyAndValue
                {
                    Key = koszykZakupowy.KoszykID,
                    Value = koszykZakupowy.Klienci.Email + " ; " + koszykZakupowy.Klienci.Telefon + " ; " + koszykZakupowy.Klienci.Imie + " ; " + koszykZakupowy.Klienci.Nazwisko
                }
                ).ToList().AsQueryable();
        }
    }
}
