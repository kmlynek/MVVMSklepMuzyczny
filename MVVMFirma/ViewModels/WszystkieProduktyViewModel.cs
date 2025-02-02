using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieProduktyViewModel : WszystkieViewModel<ProduktyForAllView>
    {
        #region Constructor
        public WszystkieProduktyViewModel()
            : base("Produkty")
        {
        }
        #endregion
        #region Sort And Find
        //tu decydujemy po czym sortować do Comboboxa
        public override List<string> GetComboboxSortList()
        {
            return null;
        }
        //tu decydujemy jak sortować
        public override void Sort()
        {

        }
        //tu decydujemy po czym wyszukiwać do Comboboxa
        public override List<string> GetComboboxFindList()
        {
            return null;
        }
        //tu decydujemy jak wyszukiwać
        public override void Find()
        {

        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie adresy z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<ProduktyForAllView>
                (
                   from produkt in sklepMuzycznyEntities.Produkty
                   select new ProduktyForAllView
                   {
                       ProduktID = produkt.ProduktID,
                       Nazwa = produkt.Nazwa,
                       Opis = produkt.Opis,
                       Cena = produkt.Cena,
                       KategorieNazwa = produkt.Kategorie.Nazwa,
                       KategorieOpis = produkt.Kategorie.Opis
                   }
                );
        }
        #endregion
    }
}
