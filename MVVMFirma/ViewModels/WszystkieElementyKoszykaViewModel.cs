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
    public class WszystkieElementyKoszykaViewModel : WszystkieViewModel<ElementyKoszykaForAllView>
    {
        #region Constructor
        public WszystkieElementyKoszykaViewModel()
            : base("Elementy Koszyka")
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
            List = new ObservableCollection<ElementyKoszykaForAllView>
                (
                   from elementKoszyka in sklepMuzycznyEntities.ElementyKoszyka
                   select new ElementyKoszykaForAllView
                   {
                       ElementID = elementKoszyka.ElementID,
                       Ilosc = elementKoszyka.Ilosc,
                       ProduktyNazwa = elementKoszyka.Produkty.Nazwa,
                       ProduktyCena = elementKoszyka.Produkty.Cena,                       
                   }
                );
        }
        #endregion
    }
}
