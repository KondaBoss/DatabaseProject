using Milicija.Database;
using Milicija.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Milicija.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Constructors

        public MainWindowViewModel()
        {
            Zaposleni = new ObservableCollection<Employee>();
            Zaposleni.Add(new Official { JMBG = "1901999773630", Name = "Bogdan", LastName = "Kondic", Type = EmployeeTypes.OfficialStaff, OfficialType = OfficialType.Cop, StationId = 0 }) ;
            Zaposleni.Add(new Official { JMBG = "0302999790034", Name = "Nikola", LastName = "Zivanovic", Type = EmployeeTypes.OfficialStaff, OfficialType = OfficialType.Clerk, StationId = 1 });
            Zaposleni.Add(new Support { JMBG = "0510996773630", Name = "Veljko", LastName = "Djokic", Type = EmployeeTypes.SupportStaff });
            LoadFilterData();
        }


        #endregion

        #region Fields

        private ObservableCollection<FilterModel> filterTipoviZaposlenog;
        private FilterModel filterTipoviZaposlenogSelected;
        private ObservableCollection<FilterModel> filterTipoviSluzbenogLica;
        private FilterModel filterTipoviSluzbenogLicaSelected;

        private ObservableCollection<Employee> zaposleni;
        private Employee zaposleniSelected;
        private Employee zaposleniSourceSelected;

        private bool filterTipoviSluzbenogLicaEnabled;

        #endregion

        #region Properties

        public ObservableCollection<FilterModel> FilterTipoviZaposlenog
        {
            get { return filterTipoviZaposlenog; }
            set
            {
                if (filterTipoviZaposlenog != value)
                {
                    filterTipoviZaposlenog = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public FilterModel FilterTipoviZaposlenogSelected
        {
            get { return filterTipoviZaposlenogSelected; }
            set
            {
                if (filterTipoviZaposlenogSelected != value)
                {
                    filterTipoviZaposlenogSelected = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("ZaposleniSource");
                }
            }
        }
        public ObservableCollection<FilterModel> FilterTipoviSluzbenogLica
        {
            get { return filterTipoviSluzbenogLica; }
            set
            {
                if (filterTipoviSluzbenogLica != value)
                {
                    filterTipoviSluzbenogLica = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("ZaposleniSource");
                }
            }
        }
        public FilterModel FilterTipoviSluzbenogLicaSelected
        {
            get { return filterTipoviSluzbenogLicaSelected; }
            set
            {
                if (filterTipoviSluzbenogLicaSelected != value)
                {
                    filterTipoviSluzbenogLicaSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Employee> Zaposleni
        {
            get { return zaposleni; }
            set
            {
                if (zaposleni != value)
                {
                    zaposleni = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Employee ZaposleniSelected
        {
            get { return zaposleniSelected; }
            set
            {
                if (zaposleniSelected != value)
                {
                    zaposleniSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Employee ZaposleniSourceSelected
        {
            get { return zaposleniSourceSelected; }
            set
            {
                if (zaposleniSourceSelected != value)
                {
                    zaposleniSourceSelected = value;
                    NotifyPropertyChanged();
                    //NotifyPropertyChanged("IDIsEnabled");
                    SetControlValues(value);
                }
            }
        }
        public ICollectionView ZaposleniSource
        {
            get
            {
                var source = new CollectionViewSource { Source = Zaposleni }.View;
                source.SortDescriptions.Add(new SortDescription("Jmbg", ListSortDirection.Ascending));
                source.Filter = FilterZaposleniSource;
                return source;
            }
        }

        public bool FilterTipoviSluzbenogLicaEnabled
        {
            get { return filterTipoviSluzbenogLicaEnabled; }
            set
            {
                if (filterTipoviSluzbenogLicaEnabled != value)
                {
                    filterTipoviSluzbenogLicaEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

        


        #endregion

        #region Methods

        private void LoadFilterData()
        {
            FilterTipoviZaposlenog = new ObservableCollection<FilterModel>();
            FilterTipoviZaposlenog.Add(new FilterModel { Id = 0, Name = "Svi" });
            FilterTipoviZaposlenog.Add(new FilterModel { Id = 1, Name = "Sluzbena lica" });
            FilterTipoviZaposlenog.Add(new FilterModel { Id = 2, Name = "Pomocno osbolje" });

            FilterTipoviZaposlenogSelected = FilterTipoviZaposlenog.FirstOrDefault();

            FilterTipoviSluzbenogLica = new ObservableCollection<FilterModel>();
            FilterTipoviSluzbenogLica.Add(new FilterModel { Id = 0, Name = "Svi" });
            FilterTipoviSluzbenogLica.Add(new FilterModel { Id = 1, Name = "Drotovi" });
            FilterTipoviSluzbenogLica.Add(new FilterModel { Id = 2, Name = "Sudski cinovnici" });

            FilterTipoviSluzbenogLicaSelected = FilterTipoviSluzbenogLica.FirstOrDefault();
            FilterTipoviSluzbenogLicaEnabled = false;
        }

        private void SetControlValues(Employee model)
        {
            if (model == null)
            {
                //ID = 0;
                //Broj = string.Empty;
                //TipoviPutaSelected = TipoviPuta.FirstOrDefault();
            }
            else
            {
                //ID = put.ID;
                //Broj = put.Broj;
                //TipoviPutaSelected = TipoviPuta.FirstOrDefault(tp => tp.ID == put.Tip.ID);
            }
        }

        private bool FilterZaposleniSource(object item)
        {
            Employee e = item as Employee;

            if (FilterTipoviZaposlenogSelected != null)
            {
                if (FilterTipoviZaposlenogSelected.Id == 0)
                {
                    FilterTipoviSluzbenogLicaSelected = null;
                    FilterTipoviSluzbenogLicaEnabled = false;
                    return true;
                }
                else if (FilterTipoviZaposlenogSelected.Id == 1)
                {
                    if (e.Type == EmployeeTypes.OfficialStaff)
                    {
                        FilterTipoviSluzbenogLicaEnabled = true;
                        FilterTipoviSluzbenogLicaSelected = FilterTipoviSluzbenogLica.FirstOrDefault();
                        if (FilterTipoviSluzbenogLicaSelected.Id == 0)
                        {
                            return true;
                        }
                        else if (FilterTipoviSluzbenogLicaSelected.Id == 1)
                        {
                            // TODO
                            return (e as Official).OfficialType == OfficialType.Cop;
                        }
                        else if (FilterTipoviSluzbenogLicaSelected.Id == 2)
                        {
                            // TODO
                            return (e as Official).OfficialType == OfficialType.Clerk;
                        }
                        else
                        {
                            // nothing to do
                            return false;
                        }
                    }
                    else
                        return false;
                }
                else if (FilterTipoviZaposlenogSelected.Id == 2)
                {
                    if (e.Type == EmployeeTypes.SupportStaff)
                    {
                        FilterTipoviSluzbenogLicaSelected = null;
                        FilterTipoviSluzbenogLicaEnabled = false;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    // nothing to do
                    return false;
                }
            }

            return false;
        }

        #endregion

        #region Commands

        //public ICommand DodajUNadgledaneCommand { get { return new RelayCommand(dodajUNadgledane, canDodajUNadgledane); } }

        //private void dodajUNadgledane(object param)
        //{
        //    var placeholder = (PutPlaceholderModel)Putevi.Where(p => p.NadgledaSe && p.ID == 0).OrderBy(p => p.Index).FirstOrDefault();

        //    premestiPutUNadgledane(NenadgledaniPuteviSelected, placeholder);
        //}

        //private bool canDodajUNadgledane(object param)
        //{
        //    return NenadgledaniPuteviSelected != null;
        //}

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
