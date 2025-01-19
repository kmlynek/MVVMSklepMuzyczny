using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using System.Xml.Serialization;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //To jest messenger, który oczekuje na stringa i jak go złapie to wywołuje metodę open, która jest zdefinowana w regionie helpersow
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                //new CommandViewModel(
                //    "Towary",
                //    new BaseCommand(() => this.ShowAllTowar())),

                //new CommandViewModel(
                //    "Towar",
                //    new BaseCommand(() => this.CreateView(new NowyTowarViewModel()))),

                new CommandViewModel(
                    "Adres",
                    new BaseCommand(() => this.CreateView(new NowyAdresViewModel()))),

                new CommandViewModel(
                    "Adresy",
                    new BaseCommand(() => this.ShowAllAdresy())),

                new CommandViewModel(
                    "Kategoria",
                    new BaseCommand(() => this.CreateView(new NowaKategoriaViewModel()))),

                new CommandViewModel(
                    "Kategorie",
                    new BaseCommand(() => this.ShowAllKategorie())),

                new CommandViewModel(
                    "Dostawca",
                    new BaseCommand(() => this.CreateView(new NowyDostawcaViewModel()))),

                new CommandViewModel(
                    "Dostawcy",
                    new BaseCommand(() => this.ShowAllDostawcy())),

                new CommandViewModel(
                    "Element Koszyka",
                    new BaseCommand(() => this.CreateView(new NowyElementKoszykaViewModel()))),

                new CommandViewModel(
                    "Elementy Koszyka",
                    new BaseCommand(() => this.ShowAllElementyKoszyka())),

                new CommandViewModel(
                    "Faktura",
                    new BaseCommand(() => this.CreateView(new NowaFakturaViewModel()))),

                new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllFaktury())),

                //new CommandViewModel(
                //    "Kontrahenci",
                //    new BaseCommand(() => this.ShowAllKontrahenci())),

                new CommandViewModel(
                    "Klient",
                    new BaseCommand(() => this.CreateView(new NowyKlientViewModel()))),

                new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.ShowAllKlienci())),

                new CommandViewModel(
                    "Koszyk zakupowy",
                    new BaseCommand(() => this.CreateView(new NowyKoszykZakupowyViewModel()))),

                new CommandViewModel(
                    "Koszyki zakupowe",
                    new BaseCommand(() => this.ShowAllKoszykiZakupowe())),

                new CommandViewModel(
                    "Platnosc",
                    new BaseCommand(() => this.CreateView(new NowaPlatnoscViewModel()))),

                new CommandViewModel(
                    "Platnosci",
                    new BaseCommand(() => this.ShowAllPlatnosci())),

                new CommandViewModel(
                    "Pracownik",
                    new BaseCommand(() => this.CreateView(new NowyPracownikViewModel()))),

                new CommandViewModel(
                    "Pracownicy",
                    new BaseCommand(() => this.ShowAllPracownicy())),

                new CommandViewModel(
                    "Produkt",
                    new BaseCommand(() => this.CreateView(new NowyProduktViewModel()))),

                new CommandViewModel(
                    "Produkty",
                    new BaseCommand(() => this.ShowAllProdukty())),

                new CommandViewModel(
                    "Produkt dostawcy",
                    new BaseCommand(() => this.CreateView(new NowyProduktDostawcyViewModel()))),

                new CommandViewModel(
                    "Produkty dostawcy",
                    new BaseCommand(() => this.ShowAllProduktyDostawcy())),

                new CommandViewModel(
                    "Promocja",
                    new BaseCommand(() => this.CreateView(new NowaPromocjaViewModel()))),

                new CommandViewModel(
                    "Promocje",
                    new BaseCommand(() => this.ShowAllPromocje())),

                new CommandViewModel(
                    "Recenzja",
                    new BaseCommand(() => this.CreateView(new NowaRecenzjaViewModel()))),

                new CommandViewModel(
                    "Recenzje",
                    new BaseCommand(() => this.ShowAllRecenzje())),

                new CommandViewModel(
                    "Stan magazynowy",
                    new BaseCommand(() => this.CreateView(new NowyStanMagazynowyViewModel()))),

                new CommandViewModel(
                    "Stany magazynowe",
                    new BaseCommand(() => this.ShowAllStanMagazynowy())),

                new CommandViewModel(
                    "Szczegol zamowienia",
                    new BaseCommand(() => this.CreateView(new NoweSzczegolyZamowieniaViewModel()))),

                new CommandViewModel(
                    "Szczegoly Zamowienia",
                    new BaseCommand(() => this.ShowAllSzczegolyZamowienia())),

                new CommandViewModel(
                    "Zamowienie",
                    new BaseCommand(() => this.CreateView(new NoweZamowienieViewModel()))),

                new CommandViewModel(
                    "Zamowienia",
                    new BaseCommand(() => this.ShowAllZamowienia())),

                new CommandViewModel(
                    "Raport Zamowien",
                    new BaseCommand(() => this.CreateView(new RaportZrealizowanychZamowienViewModel()))),
                new CommandViewModel(
                    "Raport Sprzedazy",
                    new BaseCommand(() => this.CreateView(new RaportSprzedazyViewModel())))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }

        private void ShowAll<T>() where T : WorkspaceViewModel, new()
        {
            // Sprawdzenie, czy widok już istnieje w kolekcji
            T workspace = this.Workspaces.FirstOrDefault(vm => vm is T) as T;

            if (workspace == null)
            {
                // Tworzenie nowego widoku, jeśli nie istnieje
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            // Ustawienie aktywnego widoku
            this.SetActiveWorkspace(workspace);
        }

        //private void ShowAllTowar()
        //{
        //    ShowAll<WszystkieTowaryViewModel>();
        //}

        private void ShowAllAdresy()
        {
            ShowAll<WszystkieAdresyViewModel>();
        }

        private void ShowAllDostawcy()
        {
            ShowAll<WszyscyDostawcyViewModel>();
        }

        private void ShowAllElementyKoszyka()
        {
            ShowAll<WszystkieElementyKoszykaViewModel>();
        }
        private void ShowAllFaktury()
        {
            ShowAll<WszystkieFakturyViewModel>();
        }

        private void ShowAllKategorie()
        {
            ShowAll<WszystkieKategorieViewModel>();
        }
        private void ShowAllKlienci()
        {
            ShowAll<WszyscyKlienciViewModel>();
        }

        // ponizej test

        private void ShowAllKoszykiZakupowe()
        {
            ShowAll<WszystkieKoszykiZakupoweViewModel>();
        }

        private void ShowAllPlatnosci()
        {
            ShowAll<WszystkiePlatnosciViewModel>();
        }

        private void ShowAllPracownicy()
        {
            ShowAll<WszyscyPracownicyViewModel>();
        }

        private void ShowAllProdukty()
        {
            ShowAll<WszystkieProduktyViewModel>();
        }

        private void ShowAllProduktyDostawcy()
        {
            ShowAll<WszystkieProduktyDostawcyViewModel>();
        }

        private void ShowAllPromocje()
        {
            ShowAll<WszystkiePromocjeViewModel>();
        }

        private void ShowAllRecenzje()
        {
            ShowAll<WszystkieRecencjeViewModel>();
        }

        private void ShowAllStanMagazynowy()
        {
            ShowAll<WszystkieStanMagazynowyViewModel>();
        }

        private void ShowAllSzczegolyZamowienia()
        {
            ShowAll<WszystkieSzczegolyZamowieniaViewModel>();
        }

        private void ShowAllZamowienia()
        {
            ShowAll<WszystkieZamowieniaViewModel>();
        }


        //private void ShowAllAdresy()
        //{
        //    WszystkieAdresyViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
        //        as WszystkieAdresyViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new WszystkieAdresyViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.SetActiveWorkspace(workspace);
        //}
        
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void open(string name)  //name to jest wysłany komunikat
        {           

            if (name == "DostawcyAdd")
                CreateView(new NowyDostawcaViewModel()); //to wywyołujemy zakładkę do dodawania nowego dostawcy

            if (name == "FakturyAdd")
                CreateView(new NowaFakturaViewModel());

            if (name == "KlienciAdd")
                CreateView(new NowyKlientViewModel());

            if (name == "PracownicyAdd")
                CreateView(new NowyPracownikViewModel());

            if (name == "AdresyAdd")
                CreateView(new NowyAdresViewModel());

            if (name == "Elementy KoszykaAdd")
                CreateView(new NowyElementKoszykaViewModel());

            if (name == "KategorieAdd")
                CreateView(new NowaKategoriaViewModel());

            if (name == "Koszyki ZakupoweAdd")  //nie dziala
                CreateView(new NowyKoszykZakupowyViewModel());

            if (name == "PłatnościAdd")
                CreateView(new NowaPlatnoscViewModel());

            if (name == "Produkty DostawcyAdd")
                CreateView(new NowyProduktDostawcyViewModel()); 

            if (name == "ProduktyAdd")
                CreateView(new NowyProduktViewModel()); 

            if (name == "PromocjeAdd")
                CreateView(new NowaPromocjaViewModel()); 

            if (name == "RecenzjeAdd")
                CreateView(new NowaRecenzjaViewModel()); 

            if (name == "Stan magazynowyAdd")
                CreateView(new NowyStanMagazynowyViewModel()); 

            if (name == "Szczegoly ZamowieniaAdd")
                CreateView(new NoweSzczegolyZamowieniaViewModel());

            if (name == "ZamowieniaAdd")
                CreateView(new NoweZamowienieViewModel());

            if (name == "AdresyAll")
                ShowAllAdresy();
            
            if (name == "KategorieAll")
                ShowAllKategorie();
        }
        #endregion

    }
}
