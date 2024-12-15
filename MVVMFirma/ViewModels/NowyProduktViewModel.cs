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
    public class NowyProduktViewModel : JedenViewModel<Produkty>
    {
        #region Constructor
        public NowyProduktViewModel()
            : base("Produkt")
        {
            item = new Produkty();
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
    }
}
