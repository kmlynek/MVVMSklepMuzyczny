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
    public class NowyElementKoszykaViewModel : JedenViewModel<ElementyKoszyka>
    {
        #region Constructor
        public NowyElementKoszykaViewModel()
            : base("Element Koszyka")
        {
            item = new ElementyKoszyka();
        }
        #endregion
        #region Pola
        //dla każdego pola na interface dodajemy properties
        public int? KoszykID
        {
            get
            {
                return item.KoszykID;
            }
            set
            {
                item.KoszykID = value;
                OnPropertyChanged(() => KoszykID);
            }
        }
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

        public int? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }


        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie
        public IQueryable<KeyAndValue> KoszykiZakupoweItems
        {
            get
            {
                return new KoszykiZakupoweB(sklepMuzycznyEntities).GetKoszykiZakupoweKeyAndValueItems();
            }
        }
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
            sklepMuzycznyEntities.ElementyKoszyka.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
