using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowieniaForAllView>
    {
        #region Constructor
        public WszystkieZamowieniaViewModel()
            : base("Zamowienia")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "status", "kwota laczna" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "status")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.Status));
            if (SortField == "kwota laczna")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.KwotaLaczna));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "status", "kwota laczna", "email" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "kwota laczna")
                List = new ObservableCollection<ZamowieniaForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => item.KwotaLaczna.HasValue && // Sprawdzamy, czy Ilosc nie jest null
                               item.KwotaLaczna.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "status")
                List = new ObservableCollection<ZamowieniaForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Status) &&
                                       item.Status.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );

            if (FindField == "email")
                List = new ObservableCollection<ZamowieniaForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.KlienciEmail) &&
                                       item.KlienciEmail.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaForAllView>
                (
                   from zamowienie in sklepMuzycznyEntities.Zamowienia
                   select new ZamowieniaForAllView
                   {
                       ZamowienieID = zamowienie.ZamowienieID,
                       KlienciEmail = zamowienie.Klienci.Email,
                       KlienciTelefon = zamowienie.Klienci.Telefon,
                       DataZamowienia = zamowienie.DataZamowienia,
                       Status = zamowienie.Status,
                       KwotaLaczna = zamowienie.KwotaLaczna

                   }
                );
        }
        #endregion
    }
}
