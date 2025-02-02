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
            return null;
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {

        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return null;
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {

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
