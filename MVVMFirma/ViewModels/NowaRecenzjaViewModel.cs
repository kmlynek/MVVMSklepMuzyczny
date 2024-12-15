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
    public class NowaRecenzjaViewModel : JedenViewModel<Recenzje>
    {
        #region Constructor
        public NowaRecenzjaViewModel()
            : base("Recenzja")
        {
            item = new Recenzje();
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
        public int? KlientID
        {
            get
            {
                return item.KlientID;
            }
            set
            {
                item.KlientID = value;
                OnPropertyChanged(() => KlientID);
            }
        }
        public int? Ocena
        {
            get
            {
                return item.Ocena;
            }
            set
            {
                item.Ocena = value;
                OnPropertyChanged(() => Ocena);
            }
        }
        public string Komentarz
        {
            get
            {
                return item.Komentarz;
            }
            set
            {
                item.Komentarz = value;
                OnPropertyChanged(() => Komentarz);
            }
        }

        public DateTime? DataRecenzji
        {
            get
            {
                return item.DataRecenzji;
            }
            set
            {
                item.DataRecenzji = value;
                OnPropertyChanged(() => DataRecenzji);
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

        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlienciB(sklepMuzycznyEntities).GetKlienciKeyAndValueItems();
            }
        }
     
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Recenzje.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
