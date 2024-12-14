using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieProduktyDostawcyViewModel : WszystkieViewModel<ProduktyDostawcyForAllView>
    {
        #region Constructor
        public WszystkieProduktyDostawcyViewModel()
            : base("Produkty Dostawcy")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<ProduktyDostawcyForAllView>
                (
                   from produktDostawcy in sklepMuzycznyEntities.ProduktyDostawcy
                   select new ProduktyDostawcyForAllView
                   {
                       ProduktDostawcaID = produktDostawcy.ProduktDostawcaID,
                       ProduktyNazwa = produktDostawcy.Produkty.Nazwa,
                       ProduktyCena = produktDostawcy.Produkty.Cena,
                       DostawcyNazwa = produktDostawcy.Dostawcy.Nazwa,
                       DostawcyKontakt = produktDostawcy.Dostawcy.Kontakt
                   }
                );
        }
        #endregion
    }
}
