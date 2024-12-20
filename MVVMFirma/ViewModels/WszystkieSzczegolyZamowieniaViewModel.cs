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
