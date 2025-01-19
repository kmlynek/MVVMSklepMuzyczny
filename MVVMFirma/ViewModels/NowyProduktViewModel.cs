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
    public class NowyProduktViewModel : JedenViewModel<Produkty>, IDataErrorInfo
    {
        #region Constructor
        public NowyProduktViewModel()
            : base("Produkt")
        {
            item = new Produkty();
            Messenger.Default.Register<Kategorie>(this, getWybranaKategoria);
        }
        #region Command
        private BaseCommand _ShowKategorie; // komenda wywola funkcje ShowAdresy, wywołującą funkcję wyświetlenia Adresów, podpięta pod przycisk ...

        public ICommand ShowKategorie
        {
            get
            {
                if (_ShowKategorie == null)
                    _ShowKategorie = new BaseCommand(() => showKategorie());
                return _ShowKategorie;
            }
        }
        private void showKategorie()
        {
            Messenger.Default.Send<string>("KategorieAll");
        }
        #endregion
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
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                item.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }

        public int? KategoriaID
        {
            get
            {
                return item.KategoriaID;
            }
            set
            {
                item.KategoriaID = value;
                OnPropertyChanged(() => KategoriaID);
            }
        }

        public string KategoriaNazwa { get; set; }
        public string KategoriaOpis { get; set; }
        private void getWybranaKategoria(Kategorie kategoria)
        {
            KategoriaID = kategoria.KategoriaID;
            KategoriaNazwa = kategoria.Nazwa;
            KategoriaOpis = kategoria.Opis;
        }

        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie
        public IQueryable<KeyAndValue> KategorieItems
        {
            get
            {
                return new KategorieB(sklepMuzycznyEntities).GetKategorieKeyAndValueItems();
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Produkty.Add(item);
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
                if (name == "Nazwa")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                if (name == "Cena")
                    komunikat = BiznesValidator.SprawdzCene(this.Cena);
                return komunikat;
            }
        }

            public override bool IsValid()  //Funkcja ta sprawdza czy rekord jest gotowy do zapisu
        {
            if (this["Nazwa"] == null && this["Cena"] == null)
                return true;
            return false;
        }
            #endregion
        }
    }

