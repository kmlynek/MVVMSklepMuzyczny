using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MVVMFirma.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klienci>,IDataErrorInfo
    {
        #region Constructor
        public NowyKlientViewModel()
            : base("Klient")
        {
            item = new Klienci();
            //to jest Messenger, który oczekuje na Adres z widoku z wszystkimi adresami
            // jak złapiemy, to jest wywoływana metoda getWybranyAdres
            Messenger.Default.Register<Adresy>(this, getWybranyAdres);
        }
        #endregion
        #region Command
        private BaseCommand _ShowAdresy; // komenda wywola funkcje ShowAdresy, wywołującą funkcję wyświetlenia Adresów, podpięta pod przycisk ...

        public ICommand ShowAdresy
        {
            get
            {
                if (_ShowAdresy == null)
                    _ShowAdresy = new BaseCommand(() => showAdresy());
                return _ShowAdresy;
            }
        }
        private void showAdresy()
        {
            Messenger.Default.Send<string>("AdresyAll");
        }
        #endregion
        #region Pola
        //dla każdego pola na interface dodajemy properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }
        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }

        public int? AdresID
        {
            get
            {
                return item.AdresID;
            }
            set
            {
                item.AdresID = value;
                OnPropertyChanged(() => AdresID);
            }
        }

        public string AdresNazwa { get; set; }
        public string AdresUlica { get; set; }
        public string AdresKodPocztowy { get; set; }
        public string AdresKraj { get; set; }
        private void getWybranyAdres(Adresy adres)
        {
            AdresID = adres.AdresID;
            AdresUlica = adres.Ulica;
            AdresKodPocztowy = adres.KodPocztowy;
            AdresKraj = adres.Kraj;
        }
          

        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie
        public IQueryable<KeyAndValue> AdresyItems
        {
            get
            {
                return new AdresyB(sklepMuzycznyEntities).GetAdresyKeyAndValueItems();
            }
        }

        #endregion
        #region Helpers
        //to ejst funkcja, która wywoła się po przesłaniu adresu z okna wszysctkie adresy
 
        public override void Save()
        {
            sklepMuzycznyEntities.Klienci.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Imie")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Imie);
                if (name == "Nazwisko")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwisko);
                if (name == "Email")
                    komunikat = StringValidator.SprawdzCzyZawieraAt(this.Email);
                if (name == "Telefon")
                    komunikat = BiznesValidator.SprawdzNumerTelefonu(this.Telefon);
                return komunikat;
            }
        }

        public override bool IsValid()  //Funkcja ta sprawdza czy rekord jest gotowy do zapisu
        {
            if (this["Imie"] == null && this["Nazwisko"] == null && this["Email"] == null && this["Telefon"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
