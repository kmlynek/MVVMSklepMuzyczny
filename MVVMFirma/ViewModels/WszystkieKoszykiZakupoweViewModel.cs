using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKoszykiZakupoweViewModel : WszystkieViewModel<KoszykiZakupoweForAllView>
    {
        #region Constructor
        public WszystkieKoszykiZakupoweViewModel()
            : base("Koszyki Zakupowe")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<KoszykiZakupoweForAllView>
                (
                   from koszykZakupowy in sklepMuzycznyEntities.KoszykiZakupowe
                   select new KoszykiZakupoweForAllView
                   {
                       KoszykID = koszykZakupowy.KoszykID,
                       KlienciEmail = koszykZakupowy.Klienci.Email,
                       KlienciTelefon = koszykZakupowy.Klienci.Telefon,
                       DataUtworzenia = koszykZakupowy.DataUtworzenia
                   }
                );
        }
        #endregion
    }
}
