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
