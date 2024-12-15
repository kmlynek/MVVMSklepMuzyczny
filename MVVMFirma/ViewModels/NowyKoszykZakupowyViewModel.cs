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
    public class NowyKoszykZakupowyViewModel : JedenViewModel<KoszykiZakupowe>
    {
        #region Constructor
        public NowyKoszykZakupowyViewModel()
            : base("Koszyk zakupowy")
        {
            item = new KoszykiZakupowe();
        }
        #endregion
        #region Pola
        //dla każdego pola na interface dodajemy properties
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
        public DateTime? DataUtworzenia
        {
            get
            {
                return item.DataUtworzenia;
            }
            set
            {
                item.DataUtworzenia = value;
                OnPropertyChanged(() => DataUtworzenia);
            }
        }

        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie
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
            sklepMuzycznyEntities.KoszykiZakupowe.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
