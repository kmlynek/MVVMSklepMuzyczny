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
    public class NowaKategoriaViewModel : JedenViewModel<Kategorie> // bo wszystkie zakładki dziedziczą po WVM
    {
        #region Constructor
        public NowaKategoriaViewModel()
            : base("Kategoria")
        {
            item = new Kategorie();
        }
        #endregion
        #region Properties
        //dla kazdego pola na interface tworzymy properties
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
       
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepMuzycznyEntities.Kategorie.Add(item); //dodaje do lokalnej kolekcji
            sklepMuzycznyEntities.SaveChanges(); //zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
