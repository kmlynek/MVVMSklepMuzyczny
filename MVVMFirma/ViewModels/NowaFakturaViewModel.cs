using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace MVVMFirma.ViewModels
{
    internal class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Constructor
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item=new Faktury();
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
        public IQueryable<KeyAndValue> FakturyItems
        {
            get
            {
                
            }
        #endregion
    }
}
