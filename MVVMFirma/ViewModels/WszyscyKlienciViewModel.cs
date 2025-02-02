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
    public class WszyscyKlienciViewModel : WszystkieViewModel<KlienciForAllView>
    {
        #region Constructor
        public WszyscyKlienciViewModel()
            : base("Klienci")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "imie", "nazwisko" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Nazwisko));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwisko", "email", "telefon" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "nazwisko")
                List = new ObservableCollection<KlienciForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.Nazwisko) &&
                                       item.Nazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "email")
                List = new ObservableCollection<KlienciForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Email) &&
                                       item.Email.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
            if (FindField == "telefon")
                List = new ObservableCollection<KlienciForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Telefon) &&
                                       item.Telefon.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<KlienciForAllView>
                (
                   from klient in sklepMuzycznyEntities.Klienci
                   select new KlienciForAllView
                   {
                       KlientID = klient.KlientID,
                       Imie = klient.Imie,
                       Nazwisko = klient.Nazwisko,
                       Email = klient.Email,
                       Telefon = klient.Telefon,
                       AdresyUlica = klient.Adresy.Ulica,
                       AdresyMiasto = klient.Adresy.Miasto,
                       AdresyKodPocztowy = klient.Adresy.KodPocztowy,
                   }
                );
        }
        #endregion
    }
}
