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
