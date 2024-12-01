using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : WorkspaceViewModel // bo wszystkie zakładki dziedziczą po WVM
    {
        #region DB
        private SklepMuzycznyEntities sklepMuzycznyEntities;
        #endregion
        #region Item
        private Adresy adres;
        #endregion
        #region Command
        //to jest komenda któa zostanie podpięta pod przycisk zapisz i zamknij, wywola funkcja save and close
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Constructor
        public NowyAdresViewModel()
        {
            base.DisplayName = "Adres";
            sklepMuzycznyEntities = new SklepMuzycznyEntities();
            adres = new Adresy();
        }
        #endregion
        #region Properties
        //dla kazdego pola na interface tworzymy properties
        public string Ulica
        {
            get
            {
                return adres.Ulica;
            }
            set
            {
                adres.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string Miasto
        {
            get
            {
                return adres.Miasto;
            }
            set
            {
                adres.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return adres.KodPocztowy;
            }
            set
            {
                adres.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Kraj
        {
            get
            {
                return adres.Kraj;
            }
            set
            {
                adres.Kraj = value;
                OnPropertyChanged(() => Kraj);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            sklepMuzycznyEntities.Adresy.Add(adres); //dodaje do lokalnej kolekcji
            sklepMuzycznyEntities.SaveChanges(); //zapisuje zmiany do bazy danych
        }
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zamkniecie zakladki
        }
        #endregion
    }
}
