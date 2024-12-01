using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adresy> // bo wszystkie zakładki dziedziczą po WVM
    {   
        #region Constructor
        public NowyAdresViewModel()
            :base("Adres")
        {
            item = new Adresy();
        }
        #endregion
        #region Properties
        //dla kazdego pola na interface tworzymy properties
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                item.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                item.Kraj = value;
                OnPropertyChanged(() => Kraj);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Adresy.Add(item); //dodaje do lokalnej kolekcji
            sklepMuzycznyEntities.SaveChanges(); //zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
