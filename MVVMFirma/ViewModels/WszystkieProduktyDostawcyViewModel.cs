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
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa dostawcy", "cena" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "nazwa dostawcy")
                List = new ObservableCollection<ProduktyDostawcyForAllView>(List.OrderBy(item => item.DostawcyNazwa));
            if (SortField == "cena")
                List = new ObservableCollection<ProduktyDostawcyForAllView>(List.OrderBy(item => item.ProduktyCena));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa dostawcy", "cena" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "nazwa dostawcy")
                List = new ObservableCollection<ProduktyDostawcyForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.DostawcyNazwa) &&
                                       item.DostawcyNazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "cena")
                List = new ObservableCollection<ProduktyDostawcyForAllView>(
                    List.Where(item => item.ProduktyCena.HasValue && // Sprawdzamy, czy cena nie jest null
                                       item.ProduktyCena.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
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
