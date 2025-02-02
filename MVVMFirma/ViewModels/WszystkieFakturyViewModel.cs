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
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturyForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base("Faktury")
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
            List = new ObservableCollection<FakturyForAllView>
                (
                   from faktura in sklepMuzycznyEntities.Faktury  //dla każdej faktury z bazy danych sklepu muzycznego
                   select new FakturyForAllView //tworzymy nową FakturęFollAllView
                   {
                       FakturaID= faktura.FakturaID,
                       KlienciZamowieniaImie= faktura.Zamowienia.Klienci.Imie,
                       KlienciZamowieniaNazwisko = faktura.Zamowienia.Klienci.Nazwisko,
                       KlienciZamowieniaEmail = faktura.Zamowienia.Klienci.Email,
                       KlienciZamowieniaTelefon = faktura.Zamowienia.Klienci.Telefon,
                       ZamowieniaDataZamowienia = faktura.Zamowienia.DataZamowienia,
                       ZamowieniaStatus=faktura.Zamowienia.Status,
                       ZamowieniaKwotaLaczna =faktura.Zamowienia.KwotaLaczna,
                   }
                );
        }
        #endregion
    }
}
