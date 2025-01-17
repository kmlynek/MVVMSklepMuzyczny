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
    public class NoweZamowienieViewModel : JedenViewModel<Zamowienia>
    {
        #region Constructor
        public NoweZamowienieViewModel()
            : base("Zamowienie")
        {
            item = new Zamowienia();
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

        public DateTime? DataZamowienia
        {
            get
            {
                return item.DataZamowienia;
            }
            set
            {
                item.DataZamowienia = value;
                OnPropertyChanged(() => DataZamowienia);
            }
        }
        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        public decimal? KwotaLaczna
        {
            get
            {
                return item.KwotaLaczna;
            }
            set
            {
                item.KwotaLaczna = value;
                OnPropertyChanged(() => KwotaLaczna);
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
            sklepMuzycznyEntities.Zamowienia.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
