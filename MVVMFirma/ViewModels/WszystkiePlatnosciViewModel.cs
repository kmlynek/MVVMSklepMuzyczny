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
    public class WszystkiePlatnosciViewModel : WszystkieViewModel<PlatnosciForAllView>
    {
        #region Constructor
        public WszystkiePlatnosciViewModel()
            : base("Płatności")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>
                (
                   from platnosc in sklepMuzycznyEntities.Platnosci
                   select new PlatnosciForAllView
                   {
                       PlatnoscID = platnosc.PlatnoscID,
                       DataPlatnosci = platnosc.DataPlatnosci,
                       Kwota = platnosc.Kwota,
                       MetodaPlatnosci = platnosc.MetodaPlatnosci,
                       ZamowieniaStatus = platnosc.Zamowienia.Status
                   }
                );
        }
        #endregion
    }
}
