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

namespace MVVMFirma.ViewModels
{
    public class RaportSprzedazyViewModel : WorkspaceViewModel
    {
        #region DB
        SklepMuzycznyEntities db;
        #endregion
        #region Konstruktor


        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport Sprzedazy";
            db = new SklepMuzycznyEntities();
            //Ustawiamy domyślne wartości pól data od i data do i Koszt
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            Zysk = 0;
        }
        #endregion
        #region Pola
        //dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        //dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        //dla każdego pola istotnego dla obliczeń tworzymy Pola i Właściwości
        private int _ZamowienieID;
        public int ZamowienieID
        {
            get
            {
                return _ZamowienieID;
            }
            set
            {
                if (_ZamowienieID != value)
                {
                    _ZamowienieID = value;
                    OnPropertyChanged(() => ZamowienieID);
                }
            }
        }
        private decimal? _Zysk;
        public decimal? Zysk
        {
            get
            {
                return _Zysk;
            }
            set
            {
                if (_Zysk != value)
                {
                    _Zysk = value;
                    OnPropertyChanged(() => Zysk);
                }
            }
        }
        //Properties, który uzupełni wszystkie produkty w Comboboxie
        public IQueryable<KeyAndValue> SprzedazItems
        {
            get
            {
                //obiekt logiki biznesowej
                return new SprzedazB(db).GetSprzedazKeyAndValueItems();
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
                    _ObliczCommand = new BaseCommand(() => obliczSprzedazClick());
                return _ObliczCommand;
            }
        }
        private void obliczSprzedazClick()
        {
            //to jest uzycie funkcji z klasy logiki biznesowej KosztyB, ktora liczy sume kosztow dla wybranego produktu
            Zysk = new SprzedazB(db).SprzedazOkresZamowienie(ZamowienieID, DataOd, DataDo);
        }
        #endregion
    }
}
