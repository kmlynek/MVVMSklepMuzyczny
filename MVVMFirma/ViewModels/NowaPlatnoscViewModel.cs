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
    public class NowaPlatnoscViewModel : JedenViewModel<Platnosci>
    {
        #region Constructor
        public NowaPlatnoscViewModel()
            : base("Platnosc")
        {
            item = new Platnosci();
        }
        #endregion
        #region Pola
        //dla każdego pola na interface dodajemy properties
        public int? ZamowienieID
        {
            get
            {
                return item.ZamowienieID;
            }
            set
            {
                item.ZamowienieID = value;
                OnPropertyChanged(() => ZamowienieID);
            }
        }
        public DateTime? DataPlatnosci
        {
            get
            {
                return item.DataPlatnosci;
            }
            set
            {
                item.DataPlatnosci = value;
                OnPropertyChanged(() => DataPlatnosci);
            }
        }

        #endregion
        #region Właściwości dla Combobox
        //properties, który uzuepełni wszystkie Faktury w comboboxie
        public IQueryable<KeyAndValue> ZamowieniaItems
        {
            get
            {
                return new ZamowieniaB(sklepMuzycznyEntities).GetZamowieniaKeyAndValueItems();
            }
        }
        public decimal? Kwota
        {
            get
            {
                return item.Kwota;
            }
            set
            {
                item.Kwota = value;
                OnPropertyChanged(() => Kwota);
            }
        }

        public string MetodaPlatnosci
        {
            get
            {
                return item.MetodaPlatnosci;
            }
            set
            {
                item.MetodaPlatnosci = value;
                OnPropertyChanged(() => MetodaPlatnosci);
            }
        }


        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Platnosci.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
    }
}
