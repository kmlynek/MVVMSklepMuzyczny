using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace MVVMFirma.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klienci>
    {
        #region Constructor
        public NowyKlientViewModel()
            : base("Klient")
        {
            item = new Klienci();
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
            sklepMuzycznyEntities.Klienci.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
