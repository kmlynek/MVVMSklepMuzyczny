using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKategorieViewModel : WszystkieViewModel<Kategorie>
    {
        #region Constructor
        public WszystkieKategorieViewModel()
            : base("Kategorie")
        {
        }
        #endregion
        #region Properties
        private Kategorie _WybranaKategoria;
        public Kategorie WybranaKategoria
        {
            get
            {
                return _WybranaKategoria;
            }
            set
            {
                _WybranaKategoria = value;
                //Messengerem wysyłamy wybraną Kategorię do okna Produkt
                Messenger.Default.Send(_WybranaKategoria);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "opis"};
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<Kategorie>(List.OrderBy(item => item.Nazwa));
            if (SortField == "opis")
                List = new ObservableCollection<Kategorie>(List.OrderBy(item => item.Opis));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "opis" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "nazwa")
                List = new ObservableCollection<Kategorie>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.Nazwa) &&
                                       item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "opis")
                List = new ObservableCollection<Kategorie>(
                    List.Where(item => !string.IsNullOrEmpty(item.Opis) &&
                                       item.Opis.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<Kategorie>
                (
                    sklepMuzycznyEntities.Kategorie.ToList()
                //z bazy danych, pobieram Adres i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion

    }
}
