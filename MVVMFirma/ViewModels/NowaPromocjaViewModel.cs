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


namespace MVVMFirma.ViewModels
{
    public class NowaPromocjaViewModel : JedenViewModel<Promocje>, IDataErrorInfo
    {
        #region Constructor
        public NowaPromocjaViewModel()
            : base("Promocja")
        {
            item = new Promocje();
        }
        #endregion
        #region Pola
        //dla każdego pola na interface dodajemy properties

        public int? ProduktID
        {
            get
            {
                return item.ProduktID;
            }
            set
            {
                item.ProduktID = value;
                OnPropertyChanged(() => ProduktID);
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

        public decimal? Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                item.Rabat = value;
                OnPropertyChanged(() => Rabat);
            }
        }

        public DateTime? DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                item.DataRozpoczecia = value;
                OnPropertyChanged(() => DataRozpoczecia);
            }
        }

        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                item.DataZakonczenia = value;
                OnPropertyChanged(() => DataZakonczenia);
            }
        }

        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie

        public IQueryable<KeyAndValue> ProduktyItems
        {
            get
            {
                return new ProduktyB(sklepMuzycznyEntities).GetProduktyKeyAndValueItems();
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Promocje.Add(item);
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
                if (name == "Opis")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Opis);
                if (name == "Rabat")
                    komunikat = BiznesValidator.SprawdzRabat(this.Rabat);
                return komunikat;
            }
        }

        public override bool IsValid()  //Funkcja ta sprawdza czy rekord jest gotowy do zapisu
        {
            if (this["Opis"] == null && this["Rabat"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
