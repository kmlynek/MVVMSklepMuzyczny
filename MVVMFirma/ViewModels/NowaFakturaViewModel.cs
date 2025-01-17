using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Constructor
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item = new Faktury();
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
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
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
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Faktury.Add(item);
            sklepMuzycznyEntities.SaveChanges();
        }
        #endregion
        #region Validation
        
        #endregion
    }
}
