using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieProduktyViewModel : WszystkieViewModel<ProduktyForAllView>
    {
        #region Constructor
        public WszystkieProduktyViewModel()
            : base("Produkty")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "cena", "nazwa" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "cena")
                List = new ObservableCollection<ProduktyForAllView>(List.OrderBy(item => item.Cena));
            if (SortField == "nazwa")
                List = new ObservableCollection<ProduktyForAllView>(List.OrderBy(item => item.Nazwa));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "cena", "nazwa" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "cena")
                List = new ObservableCollection<ProduktyForAllView>(
                    List.Where(item => item.Cena.HasValue && // Sprawdzamy, czy Kwota nie jest null
                                       item.Cena.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                ); //Konwertuje decimal na string, usuwając zbędne zera.

            if (FindField == "nazwa")
                List = new ObservableCollection<ProduktyForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Nazwa) &&
                                       item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<ProduktyForAllView>
                (
                   from produkt in sklepMuzycznyEntities.Produkty
                   select new ProduktyForAllView
                   {
                       ProduktID = produkt.ProduktID,
                       Nazwa = produkt.Nazwa,
                       Opis = produkt.Opis,
                       Cena = produkt.Cena,
                       KategorieNazwa = produkt.Kategorie.Nazwa,
                       KategorieOpis = produkt.Kategorie.Opis
                   }
                );
        }
        #endregion
    }
}
