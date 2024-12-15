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
    public class NowyProduktDostawcyViewModel : JedenViewModel<ProduktyDostawcy>
    {
        #region Constructor
        public NowyProduktDostawcyViewModel()
            : base("Produkt dostawcy")
        {
            item = new ProduktyDostawcy();
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
        public int? DostawcaID
        {
            get
            {
                return item.DostawcaID;
            }
            set
            {
                item.DostawcaID = value;
                OnPropertyChanged(() => DostawcaID);
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
        public IQueryable<KeyAndValue> DostawcyItems
        {
            get
            {
                return new DostawcyB(sklepMuzycznyEntities).GetDostawcyKeyAndValueItems();
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.ProduktyDostawcy.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
