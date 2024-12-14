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
    public class WszystkieStanMagazynowyViewModel : WszystkieViewModel<StanMagazynowyForAllView>
    {
        #region Constructor
        public WszystkieStanMagazynowyViewModel()
            : base("Stan magazynowy")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<StanMagazynowyForAllView>
                (
                   from stanMagazynowy in sklepMuzycznyEntities.StanMagazynowy
                   select new StanMagazynowyForAllView
                   {
                       StanID = stanMagazynowy.StanID,
                       ProduktyNazwa = stanMagazynowy.Produkty.Nazwa,
                       ProduktyCena = stanMagazynowy.Produkty.Cena,
                       Ilosc = stanMagazynowy.Ilosc
                   }
                );
        }
        #endregion
    }
}
