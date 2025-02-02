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
    public class WszystkiePlatnosciViewModel : WszystkieViewModel<PlatnosciForAllView>
    {
        #region Constructor
        public WszystkiePlatnosciViewModel()
            : base("Płatności")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "kwota", "metoda platnosci" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "kwota")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.Kwota));
            if (SortField == "metoda platnosci")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.MetodaPlatnosci));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "kwota", "metoda platnosci" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "kwota")
                List = new ObservableCollection<PlatnosciForAllView>(
                    List.Where(item => item.Kwota.HasValue && // Sprawdzamy, czy Kwota nie jest null
                                       item.Kwota.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                ); //Konwertuje decimal na string, usuwając zbędne zera.

            if (FindField == "metoda platnosci")
                List = new ObservableCollection<PlatnosciForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.MetodaPlatnosci) &&
                                       item.MetodaPlatnosci.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>
                (
                   from platnosc in sklepMuzycznyEntities.Platnosci
                   select new PlatnosciForAllView
                   {
                       PlatnoscID = platnosc.PlatnoscID,
                       DataPlatnosci = platnosc.DataPlatnosci,
                       Kwota = platnosc.Kwota,
                       MetodaPlatnosci = platnosc.MetodaPlatnosci,
                       ZamowieniaStatus = platnosc.Zamowienia.Status
                   }
                );
        }
        #endregion
    }
}
