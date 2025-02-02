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
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ilosc", "nazwa" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "ilosc")
                List = new ObservableCollection<StanMagazynowyForAllView>(List.OrderBy(item => item.Ilosc));
            if (SortField == "nazwa")
                List = new ObservableCollection<StanMagazynowyForAllView>(List.OrderBy(item => item.ProduktyNazwa));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ilosc", "nazwa" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "ilosc")
                List = new ObservableCollection<StanMagazynowyForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => item.Ilosc.HasValue && // Sprawdzamy, czy Ilosc nie jest null
                               item.Ilosc.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "nazwa")
                List = new ObservableCollection<StanMagazynowyForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.ProduktyNazwa) &&
                                       item.ProduktyNazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
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
