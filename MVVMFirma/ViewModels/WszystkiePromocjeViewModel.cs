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
    public class WszystkiePromocjeViewModel : WszystkieViewModel<PromocjeForAllView>
    {
        #region Constructor
        public WszystkiePromocjeViewModel()
            : base("Promocje")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "rabat", "opis" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "rabat")
                List = new ObservableCollection<PromocjeForAllView>(List.OrderBy(item => item.Rabat));
            if (SortField == "opis")
                List = new ObservableCollection<PromocjeForAllView>(List.OrderBy(item => item.Opis));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "rabat", "opis" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "rabat")
                List = new ObservableCollection<PromocjeForAllView>(
                    List.Where(item => item.Rabat.HasValue && // Sprawdzamy, czy Kwota nie jest null
                                       item.Rabat.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                ); //Konwertuje decimal na string, usuwając zbędne zera.

            if (FindField == "opis")
                List = new ObservableCollection<PromocjeForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Opis) &&
                                       item.Opis.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<PromocjeForAllView>
                (
                   from promocja in sklepMuzycznyEntities.Promocje
                   select new PromocjeForAllView
                   {
                       PromocjaID = promocja.PromocjaID,
                       ProduktyNazwa = promocja.Produkty.Nazwa,
                       ProduktyCena = promocja.Produkty.Cena,
                       Opis = promocja.Opis,
                       Rabat = promocja.Rabat,
                       DataRozpoczecia = promocja.DataRozpoczecia,
                       DataZakonczenia = promocja.DataZakonczenia
                   }
                );
        }
        #endregion
    }
}
