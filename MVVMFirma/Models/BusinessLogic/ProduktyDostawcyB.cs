using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ProduktyDostawcyB : DataBaseClass
    {
        #region Konstruktor
        public ProduktyDostawcyB(SklepMuzycznyEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //dodajemy funkcje, która będzie zwracała id Zamówień itd. oraz nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetProduktyKeyAndValueItems()
        {
            return (
                from produktDostawcy in db.ProduktyDostawcy
                select new KeyAndValue
                {
                    Key = produktDostawcy.ProduktDostawcaID,
                    Value = produktDostawcy.Produkty.Nazwa + " ; " + produktDostawcy.Dostawcy.Nazwa + " ; "
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
