﻿using MVVMFirma.Models.Entities;
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
