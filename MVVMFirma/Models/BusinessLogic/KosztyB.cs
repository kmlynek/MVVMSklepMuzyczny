using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KosztyB : DataBaseClass // zawiera model danych
    {
        #region Konstruktor
        public KosztyB(SklepMuzycznyEntities db)
            :base(db) // Wypełnia dostęp do bazy danych
        {

        }
        #endregion
        #region Funkcje biznesowe  
        //ta funkcja oblicza utarg danego towaru w danym okresie od i do 
        public IQueryable<KeyAndValue> GetKosztyKeyAndValueItems()
        {
            return (
                from produkt in db.Produkty
                select new KeyAndValue
                {
                    Key = produkt.ProduktID,
                    Value = produkt.Nazwa
                }
                ).ToList().AsQueryable();
        }

        public decimal? KosztOkresDostawca(int ProduktID)

        //public decimal? KosztOkresDostawca(int ProduktID, DateTime dataOd, DateTime dataDo)  -- tabela bez dat
        {
            return
                (
                from pozycja in db.ProduktyDostawcy
                where
                pozycja.ProduktDostawcaID == ProduktID 
                select pozycja.Produkty.Cena
                ).Sum();
        }
        #endregion
    }
}
