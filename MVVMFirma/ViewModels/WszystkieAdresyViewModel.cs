using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adresy>
    {        
        #region Constructor
        public WszystkieAdresyViewModel()
            :base("Adresy")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"kraj", "miasto", "ulica"} ;
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "kraj")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.Kraj));
            if (SortField == "miasto")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.Miasto));
            if (SortField == "ulica")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.Ulica));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "kraj", "miasto" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return; 

            if (FindField == "kraj")
                List = new ObservableCollection<Adresy>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.Kraj) &&       
                                       item.Kraj.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "miasto")
                List = new ObservableCollection<Adresy>(
                    List.Where(item => !string.IsNullOrEmpty(item.Miasto) &&         
                                       item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Properties
        // do tego propertiesa zostanie przypisany Adres klikniety na liscie
        private Adresy _WybranyAdres;
        public Adresy WybranyAdres
        {
            get
            {
                return _WybranyAdres;

            }
            set
            {
                _WybranyAdres = value;
                //Messengerem wysyłamy wybrany Adres do okna z Klient
                Messenger.Default.Send(_WybranyAdres);
                //Zamykamy po wybraniu
                OnRequestClose();
            }
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<Adresy>
                (
                    sklepMuzycznyEntities.Adresy.ToList()
                    //z bazy danych, pobieram Adres i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion

    }
}
