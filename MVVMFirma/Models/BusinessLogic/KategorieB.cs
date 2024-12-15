using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KategorieB : DataBaseClass
    {

        public KategorieB(SklepMuzycznyEntities db)
            : base(db) { }

        //dodajemy funkcje, która będzie zwracała id Zamówień itd.
        public IQueryable<KeyAndValue> GetKategorieKeyAndValueItems()
        {
            return (
                from kategoria in db.Kategorie
                select new KeyAndValue
                {
                    Key = kategoria.KategoriaID,
                    Value = kategoria.Nazwa + " ; " + kategoria.Opis
                }
                ).ToList().AsQueryable();
        }
    }
}
