using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SprzedazB : DataBaseClass // zawiera model danych
    {
        #region Konstruktor
        public SprzedazB(SklepMuzycznyEntities db)
            : base(db) // Wypełnia dostęp do bazy danych
        {

        }
        #endregion
        #region Funkcje biznesowe  
        //ta funkcja oblicza utarg danego towaru w danym okresie od i do 
        public IQueryable<KeyAndValue> GetSprzedazKeyAndValueItems()
        {
            return (
                from kwota in db.Zamowienia
                select new KeyAndValue
                {
                    Key = kwota.ZamowienieID,
                    NumericValue = kwota.KwotaLaczna,
                    Value = kwota.Klienci.Email,
                }
                ).ToList().AsQueryable();
        }

        public decimal? SprzedazOkresZamowienie(int ZamowienieID, DateTime DataOd, DateTime DataDo)
        {
            return
                (
                from pozycja in db.Zamowienia
                  where
                  pozycja.ZamowienieID == ZamowienieID && //sprawdzamy czy ta pozycja dotyczy tego produktu
                  pozycja.DataZamowienia>= DataOd &&
                  pozycja.DataZamowienia<= DataDo
                  select pozycja.KwotaLaczna
                ).Sum();
        }
        #endregion
    }
}
