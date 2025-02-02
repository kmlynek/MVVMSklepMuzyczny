﻿using MVVMFirma.Models.Entities;
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
    public class WszystkiePromocjeViewModel : WszystkieViewModel<PromocjeForAllView>
    {
        #region Constructor
        public WszystkiePromocjeViewModel()
            : base("Promocje")
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
            List = new ObservableCollection<PromocjeForAllView>
                (
                   from promocja in sklepMuzycznyEntities.Promocje
                   select new PromocjeForAllView
                   {
                       PromocjaID = promocja.PromocjaID,
                       ProduktyNazwa = promocja.Produkty.Nazwa,
                       ProduktyCena = promocja.Produkty.Cena,
                       Opis = promocja.Opis,
                       Rabat = promocja.Rabat,
                       DataRozpoczecia = promocja.DataRozpoczecia,
                       DataZakonczenia = promocja.DataZakonczenia
                   }
                );
        }
        #endregion
    }
}
