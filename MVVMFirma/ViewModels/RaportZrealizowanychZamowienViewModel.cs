using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace MVVMFirma.ViewModels
{
    public class RaportZrealizowanychZamowienViewModel:WorkspaceViewModel
    {
        #region DB
        SklepMuzycznyEntities db;
        #endregion
        #region Konstruktor


        public RaportZrealizowanychZamowienViewModel()
        {
            base.DisplayName = "Raport Zamowien";
            db=new SklepMuzycznyEntities();
            //Ustawiamy domyślne wartości pól data od i data do i Koszt
            //DataOd=DateTime.Now;
            //DataDo=DateTime.Now;
            Koszt = 0;
        }
        #endregion
        #region Pola
        //dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        //private DateTime _DataOd;
        //public DateTime DataOd
        //{
        //    get
        //    {
        //        return _DataOd;
        //    }
        //    set
        //    {
        //        if (_DataOd != value)
        //        {
        //            _DataOd = value;
        //            OnPropertyChanged(() => DataOd);
        //        }
        //    }
        //}
        ////dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        //private DateTime _DataDo;
        //public DateTime DataDo
        //{
        //    get
        //    {
        //        return _DataDo;
        //    }
        //    set
        //    {
        //        if (_DataDo != value)
        //        {
        //            _DataDo = value;
        //            OnPropertyChanged(() => DataDo);
        //        }
        //    }
        //}
        //dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        private int _ProduktID;
        public int ProduktID
        {
            get
            {
                return _ProduktID;
            }
            set
            {
                if (_ProduktID != value)
                {
                    _ProduktID = value;
                    OnPropertyChanged(() => ProduktID);
                }
            }
        }
        private decimal? _Koszt;
        public decimal?  Koszt
        {
            get
            {
                return _Koszt;
            }
            set
            {
                if (_Koszt != value)
                {
                    _Koszt = value;
                    OnPropertyChanged(() => Koszt);
                }
            }
        }
        //Properties, który uzupełni wszystkie produkty w Comboboxie
        public IQueryable<KeyAndValue>KosztyItems
        {
            get
            {
                //obiekt logiki biznesowej
                return new KosztyB(db).GetKosztyKeyAndValueItems();
            }
        }
        #endregion
        // To jest komenda, któa zostanie podpięta pod przycisk Oblicz i kótra wywoła funkcję ObliczKosztyClick
        #region Komendy
        public ICommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczKosztyClick());
                return _ObliczCommand;
            }
        }
        private void obliczKosztyClick()
        {
            //to jest uzycie funkcji z klasy logiki biznesowej KosztyB, ktora liczy sume kosztow dla wybranego produktu
            Koszt = new KosztyB(db).KosztOkresDostawca(ProduktID);
        }
        #endregion
    }
}
