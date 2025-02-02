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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownicyForAllView>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
            : base("Pracownicy")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "imie", "nazwisko", "stanowisko" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "stanowisko")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Stanowisko));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwisko", "email", "stanowisko" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "nazwisko")
                List = new ObservableCollection<PracownicyForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.Nazwisko) &&
                                       item.Nazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "email")
                List = new ObservableCollection<PracownicyForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Email) &&
                                       item.Email.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
            if (FindField == "stanowisko")
                List = new ObservableCollection<PracownicyForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Stanowisko) &&
                                       item.Stanowisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<PracownicyForAllView>
                (
                   from pracownik in sklepMuzycznyEntities.Pracownicy
                   select new PracownicyForAllView
                   {
                       PracownikID = pracownik.PracownikID,
                       Imie = pracownik.Imie,
                       Nazwisko = pracownik.Nazwisko,
                       Email = pracownik.Email,
                       Stanowisko = pracownik.Stanowisko,
                       Wynagrodzenie = pracownik.Wynagrodzenie,
                       AdresyUlica = pracownik.Adresy.Ulica,
                       AdresyMiasto = pracownik.Adresy.Miasto,
                       AdresyKodPocztowy = pracownik.Adresy.KodPocztowy
                   }
                );
        }
        #endregion
    }
}
