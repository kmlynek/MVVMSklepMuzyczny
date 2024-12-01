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
