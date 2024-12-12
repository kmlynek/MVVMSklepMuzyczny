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
