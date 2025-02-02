using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel//pod T beda podstawiane konkretne typy elementow listy
    {
        #region DB
        protected readonly SklepMuzycznyEntities sklepMuzycznyEntities;//to jest pole, ktore reprezentuje baze danych
        #endregion
        #region Command
        private BaseCommand _LoadCommand;//to jest komenda, która będzie wywoływała funkcję Load pobierającą z bazy danych
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        private BaseCommand _AddCommand;//to jest komenda, która będzie wywoływała funkcję add wywołującą okno do dodawania i zostanie podpięta pod przycisk dodaj 
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List;//tu będą przechowywane adresy pobrane z Bazy Danych
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);//to jest zlecenie odswiezenia listy na interfejsie
            }
        }
        #endregion
        #region Constructor

        public WszystkieViewModel(String displayName)
        {
            sklepMuzycznyEntities = new SklepMuzycznyEntities();
            base.DisplayName = displayName;
        }
        #endregion
        #region Helpers
        public abstract void Load();
        private void add()
        {
            //Messenger jest biblioteki MVVMLight, dzięki messengerowi wysyłami do innych obiektów komunikat DisplayName addd, gdzie DisplayName jest nazwą widoku
            //Ten komunikat odbierze MainWindowViewModel, które jest odpowiedzialne za otwieranie okien
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
        #region Sort And Filtr
        //do sortowania
        //wynik wyboru po czym sortować zostanie zapisany w SortField
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public abstract List<string> GetComboboxSortList();
        private BaseCommand _SortCommand; //to jest komenda, która będzie wywoływana po naciśnięciu sortuj
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        public abstract void Sort();
        //do filtrowania
        public string FindField { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public abstract List<string> GetComboboxFindList();
        public string FindTextBox { get; set; }

        private BaseCommand _FindCommand; //to jest komenda, która będzie wywoływana po naciśnięciu sortuj
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        public abstract void Find();
        #endregion
    }
}
