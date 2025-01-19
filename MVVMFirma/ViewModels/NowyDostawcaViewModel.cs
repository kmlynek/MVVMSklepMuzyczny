using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MVVMFirma.ViewModels
{
    public class NowyDostawcaViewModel : JedenViewModel<Dostawcy>
    {
        #region Constructor
        public NowyDostawcaViewModel()
            : base("Dostawca")
        {
            item = new Dostawcy();
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
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public string Kontakt
        {
            get
            {
                return item.Kontakt;
            }
            set
            {
                item.Kontakt = value;
                OnPropertyChanged(() => Kontakt);
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
        public override void Save()
        {
            sklepMuzycznyEntities.Dostawcy.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
