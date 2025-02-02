using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszyscyDostawcyViewModel : WszystkieViewModel<DostawcyForAllView>
    {
        #region Constructor
        public WszyscyDostawcyViewModel()
            : base("Dostawcy")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "kontakt" };
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<DostawcyForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "kontakt")
                List = new ObservableCollection<DostawcyForAllView>(List.OrderBy(item => item.Kontakt));
        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "kontakt" };
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {
            if (string.IsNullOrEmpty(FindTextBox) || List == null)
                return;

            if (FindField == "nazwa")
                List = new ObservableCollection<DostawcyForAllView>(
                    //Jesli textbox nie jest nullem 
                    List.Where(item => !string.IsNullOrEmpty(item.Nazwa) &&
                                       item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );//ignorujemy wielkosc liter

            if (FindField == "kontakt")
                List = new ObservableCollection<DostawcyForAllView>(
                    List.Where(item => !string.IsNullOrEmpty(item.Kontakt) &&
                                       item.Kontakt.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase))
                );
        }

        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<DostawcyForAllView>
                (
                   from dostawca in sklepMuzycznyEntities.Dostawcy  
                   select new DostawcyForAllView 
                   {
                       DostawcaID = dostawca.DostawcaID,
                       Nazwa = dostawca.Nazwa,
                       Kontakt = dostawca.Kontakt,
                       AdresyUlica = dostawca.Adresy.Ulica,
                       AdresyMiasto = dostawca.Adresy.Miasto,
                       AdresyKodPocztowy = dostawca.Adresy.KodPocztowy,
                   }
                );
        }
        #endregion
    }
}
