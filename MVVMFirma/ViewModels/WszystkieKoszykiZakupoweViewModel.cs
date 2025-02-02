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
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "email", "telefon" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "email")
                List = new ObservableCollection<KoszykiZakupoweForAllView>(List.OrderBy(item => item.KlienciEmail));
            if (SortField == "telefon")
                List = new ObservableCollection<KoszykiZakupoweForAllView>(List.OrderBy(item => item.KlienciTelefon));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "email", "telefon" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;


            if (FindField == "email")
                List = new ObservableCollection<KoszykiZakupoweForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.KlienciEmail) &&
                                       item.KlienciEmail.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
            if (FindField == "telefon")
                List = new ObservableCollection<KoszykiZakupoweForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.KlienciTelefon) &&
                                       item.KlienciTelefon.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
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
