﻿using MVVMFirma.Models.Entities;
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
    public class WszystkieSzczegolyZamowieniaViewModel : WszystkieViewModel<SzczegolyZamowieniaForAllView>
    {
        #region Constructor
        public WszystkieSzczegolyZamowieniaViewModel()
            : base("Szczegoly Zamowienia")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ilosc", "nazwa", "nazwisko" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "ilosc")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(List.OrderBy(item => item.Ilosc));
            if (SortField == "nazwa")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(List.OrderBy(item => item.ProduktyNazwa));
            if (SortField == "nazwisko")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(List.OrderBy(item => item.ZamowieniaKlienciNazwisko));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ilosc", "nazwa", "nazwisko" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "ilosc")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => item.Ilosc.HasValue && // Sprawdzamy, czy Ilosc nie jest null
                               item.Ilosc.Value.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "nazwa")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.ProduktyNazwa) &&
                                       item.ProduktyNazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );

            if (FindField == "nazwisko")
                List = new ObservableCollection<SzczegolyZamowieniaForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.ZamowieniaKlienciNazwisko) &&
                                       item.ZamowieniaKlienciNazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<SzczegolyZamowieniaForAllView>
                (
                   from szczegolZamowienia in sklepMuzycznyEntities.SzczegolyZamowienia
                   select new SzczegolyZamowieniaForAllView
                   {
                       SzczegolyID = szczegolZamowienia.SzczegolyID,
                       ZamowieniaKlienciImie = szczegolZamowienia.Zamowienia.Klienci.Imie,
                       ZamowieniaKlienciNazwisko = szczegolZamowienia.Zamowienia.Klienci.Nazwisko,
                       ZamowieniaKlienciTelefon = szczegolZamowienia.Zamowienia.Klienci.Telefon,
                       ZamowieniaKlienciEmail = szczegolZamowienia.Zamowienia.Klienci.Email,
                       ProduktyNazwa = szczegolZamowienia.Produkty.Nazwa,
                       ProduktyCena = szczegolZamowienia.Produkty.Cena,
                       Ilosc = szczegolZamowienia.Ilosc
                   }
                );
        }
        #endregion
    }
}
