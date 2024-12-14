using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ZamowieniaB:DataBaseClass
    {

        public ZamowieniaB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetZamowieniaKeyAndValueItems()
        {
            return (
                from zamowienie in db.Zamowienia
                select new KeyAndValue
                {
                    Key = zamowienie.ZamowienieID,
                    Value = zamowienie.Klienci.Nazwisko + " ; " + zamowienie.Klienci.Email + " ; " + zamowienie.KwotaLaczna
                }
                ).ToList().AsQueryable();
        }
    }
}
