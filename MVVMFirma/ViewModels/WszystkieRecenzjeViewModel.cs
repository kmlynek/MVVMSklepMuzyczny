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
    public class WszystkieRecencjeViewModel : WszystkieViewModel<RecenzjeForAllView>
    {
        #region Constructor
        public WszystkieRecencjeViewModel()
            : base("Recenzje")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<RecenzjeForAllView>
                (
                   from recenzja in sklepMuzycznyEntities.Recenzje
                   select new RecenzjeForAllView
                   {
                       RecenzjaID = recenzja.RecenzjaID,
                       ProduktyNazwa = recenzja.Produkty.Nazwa,
                       KlienciImie = recenzja.Klienci.Imie,
                       Ocena = recenzja.Ocena,
                       Komentarz = recenzja.Komentarz,
                       DataRecenzji = recenzja.DataRecenzji
                   }
                );
        }
        #endregion
    }
}
