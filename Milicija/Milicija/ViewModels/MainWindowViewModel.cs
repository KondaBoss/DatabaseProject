using Milicija.Database;
using Milicija.Extras;
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
using System.Windows.Input;

namespace Milicija.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        PoliceContainer pc = new PoliceContainer();
        #region Constructors

        public MainWindowViewModel()
        {
            LoadEmployees();
            LoadFilterData();
        }
        #endregion

        #region Fields

        private ObservableCollection<FilterModel> filterTipoviZaposlenog;
        private FilterModel filterTipoviZaposlenogSelected;
        private ObservableCollection<FilterModel> filterTipoviSluzbenogLica;
        private FilterModel filterTipoviSluzbenogLicaSelected;

        private ObservableCollection<FilterModel> filterTipZaposlenog;
        private FilterModel filterTipZaposlenogSelected;
        private ObservableCollection<FilterModel> filterTipSluzbenogLica;
        private FilterModel filterTipSluzbenogLicaSelected;

        private ObservableCollection<FilterModel> filterCin;
        private FilterModel filterCinSelected;
        private ObservableCollection<FilterModel> filterSpecijalnost;
        private FilterModel filterSpecijalnostSelected;

        private ObservableCollection<Rank> cinovi;
        private ObservableCollection<Specialty> specijalnosti;

        private ObservableCollection<Employee> zaposleni;
        private Employee zaposleniSelected;
        private Employee zaposleniSourceSelected;

        private bool filterTipoviSluzbenogLicaEnabled;
        private bool filterTipSluzbenogLicaEnabled;
        private bool filterCinEnabled;
        private bool filterSpecijalnostEnabled;

        private string jmbg;
        private string name;
        private string lastName;

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
                    FilterTipoviSluzbenogLicaSelected = FilterTipoviZaposlenog.FirstOrDefault();
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
                    NotifyPropertyChanged("ZaposleniSource");
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<FilterModel> FilterTipZaposlenog
        {
            get { return filterTipZaposlenog; }
            set
            {
                if (filterTipZaposlenog != value)
                {
                    filterTipZaposlenog = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public FilterModel FilterTipZaposlenogSelected
        {
            get { return filterTipZaposlenogSelected; }
            set
            {
                if (filterTipZaposlenogSelected != value)
                {
                    filterTipZaposlenogSelected = value;
                    if (value != null && value.Id == 0)
                    {
                        FilterTipSluzbenogLicaSelected = FilterTipSluzbenogLica.FirstOrDefault();
                        FilterTipSluzbenogLicaEnabled = true;
                    }
                    else
                    {
                        FilterTipSluzbenogLicaSelected = null;
                        FilterTipSluzbenogLicaEnabled = false;
                    }

                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<FilterModel> FilterTipSluzbenogLica
        {
            get { return filterTipSluzbenogLica; }
            set
            {
                if (filterTipSluzbenogLica != value)
                {
                    filterTipSluzbenogLica = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public FilterModel FilterTipSluzbenogLicaSelected
        {
            get { return filterTipSluzbenogLicaSelected; }
            set
            {
                if (filterTipSluzbenogLicaSelected != value)
                {
                    filterTipSluzbenogLicaSelected = value;
                    if (value != null && value.Id == 0)
                    {
                        FilterCinEnabled = true;
                        FilterCinSelected = FilterCin.FirstOrDefault();

                        FilterSpecijalnostEnabled = false;
                        FilterSpecijalnostSelected = null;
                    }
                    else if (value != null && value.Id == 1)
                    {
                        FilterSpecijalnostEnabled = true;
                        FilterSpecijalnostSelected = FilterSpecijalnost.FirstOrDefault();

                        FilterCinEnabled = false;
                        FilterCinSelected = null;
                    }
                    else
                    {
                        FilterCinEnabled = false;
                        FilterCinSelected = null;
                        FilterSpecijalnostEnabled = false;
                        FilterSpecijalnostSelected = null;
                    }
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<FilterModel> FilterCin
        {
            get { return filterCin; }
            set
            {
                if (filterCin != value)
                {
                    filterCin = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public FilterModel FilterCinSelected
        {
            get { return filterCinSelected; }
            set
            {
                if (filterCinSelected != value)
                {
                    filterCinSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<FilterModel> FilterSpecijalnost
        {
            get { return filterSpecijalnost; }
            set
            {
                if (filterSpecijalnost != value)
                {
                    filterSpecijalnost = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public FilterModel FilterSpecijalnostSelected
        {
            get { return filterSpecijalnostSelected; }
            set
            {
                if (filterSpecijalnostSelected != value)
                {
                    filterSpecijalnostSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Rank> Cinovi
        {
            get { return cinovi; }
            set
            {
                if (cinovi != value)
                {
                    cinovi = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Specialty> Specijalnosti
        {
            get { return specijalnosti; }
            set
            {
                if (specijalnosti != value)
                {
                    specijalnosti = value;
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

        public bool FilterTipSluzbenogLicaEnabled
        {
            get { return filterTipSluzbenogLicaEnabled; }
            set
            {
                if (filterTipSluzbenogLicaEnabled != value)
                {
                    filterTipSluzbenogLicaEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool FilterCinEnabled
        {
            get { return filterCinEnabled; }
            set
            {
                if (filterCinEnabled != value)
                {
                    filterCinEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool FilterSpecijalnostEnabled
        {
            get { return filterSpecijalnostEnabled; }
            set
            {
                if (filterSpecijalnostEnabled != value)
                {
                    filterSpecijalnostEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
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
            FilterTipoviSluzbenogLica.Add(new FilterModel { Id = 1, Name = "Policajci" });
            FilterTipoviSluzbenogLica.Add(new FilterModel { Id = 2, Name = "Sudski cinovnici" });

            FilterTipoviSluzbenogLicaSelected = FilterTipoviSluzbenogLica.FirstOrDefault();
            FilterTipoviSluzbenogLicaEnabled = false;

            FilterTipZaposlenog = new ObservableCollection<FilterModel>();
            FilterTipZaposlenog.Add(new FilterModel { Id = 0, Name = "Sluzbeno lice" });
            FilterTipZaposlenog.Add(new FilterModel { Id = 1, Name = "Pomocno osbolje" });

            FilterTipoviZaposlenogSelected = FilterTipZaposlenog.FirstOrDefault();

            FilterTipSluzbenogLica = new ObservableCollection<FilterModel>();
            FilterTipSluzbenogLica.Add(new FilterModel { Id = 0, Name = "Policajac" });
            FilterTipSluzbenogLica.Add(new FilterModel { Id = 1, Name = "Sudski cinovnik" });

            FilterTipSluzbenogLicaSelected = null;
            FilterTipSluzbenogLicaEnabled = false;

            Cinovi = new ObservableCollection<Rank>();
            foreach (var item in pc.Ranks)
            {
                Cinovi.Add(item);
            }

            FilterCin = new ObservableCollection<FilterModel>();
            int i = 0;
            foreach (var item in Cinovi)
            {
                FilterCin.Add(new FilterModel { Id = i, Name = item.Name });
                i++;
            }

            FilterCinSelected = null;
            FilterCinEnabled = true;

            Specijalnosti = new ObservableCollection<Specialty>();
            foreach (var item in pc.Specialties)
            {
                Specijalnosti.Add(item);
            }

            FilterSpecijalnost = new ObservableCollection<FilterModel>();
            i = 0;
            foreach (var item in Specijalnosti)
            {
                FilterSpecijalnost.Add(new FilterModel { Id = i, Name = item.Name });
                i++;
            }

            FilterSpecijalnostSelected = null;
            FilterSpecijalnostEnabled = true;
        }

        private void LoadEmployees()
        {
            Zaposleni = new ObservableCollection<Employee>();
            foreach (var item in pc.Employees)
            {
                Zaposleni.Add(item);
            }
        }

        private void SetControlValues(Employee model)
        {
            if (model != null)
            {
                Jmbg = model.JMBG;
                Name = model.Name;
                LastName = model.LastName;
                if (model.Type == EmployeeTypes.OfficialStaff)
                {
                    FilterTipZaposlenogSelected = FilterTipZaposlenog[0];
                    FilterTipSluzbenogLicaEnabled = true;

                    if ((model as Official).OfficialType == OfficialType.Cop)
                    {
                        FilterTipSluzbenogLicaSelected = FilterTipSluzbenogLica[0];
                        FilterCinEnabled = true;
                        FilterCinSelected = FilterCin.SingleOrDefault(x => x.Name == (model as Cop).Rank.Name);
                        FilterSpecijalnostSelected = null;
                        FilterSpecijalnostEnabled = false;
                    }
                    else if ((model as Official).OfficialType == OfficialType.Clerk)
                    {
                        FilterTipSluzbenogLicaSelected = FilterTipSluzbenogLica[1];
                        FilterSpecijalnostEnabled = true;
                        FilterSpecijalnostSelected = FilterSpecijalnost.SingleOrDefault(x => x.Name == (model as Clerk).Specialty.Name);
                        FilterCinSelected = null;
                        FilterCinEnabled = false;
                    }
                    else
                        FilterTipSluzbenogLicaSelected = null;

                }
                else if (model.Type == EmployeeTypes.SupportStaff)
                {
                    FilterTipZaposlenogSelected = FilterTipZaposlenog[1];
                    FilterTipSluzbenogLicaSelected = null;
                    FilterTipSluzbenogLicaEnabled = false;
                    FilterCinSelected = null;
                    FilterCinEnabled = false;
                    FilterSpecijalnostSelected = null;
                    FilterSpecijalnostEnabled = false;
                }
                else
                {
                    FilterTipSluzbenogLicaSelected = null;
                    FilterTipSluzbenogLicaEnabled = false;
                    FilterCinSelected = null;
                    FilterCinEnabled = false;
                    FilterSpecijalnostSelected = null;
                    FilterSpecijalnostEnabled = false;
                }
            }
            else
            {
                Jmbg = string.Empty;
                Name = string.Empty;
                LastName = string.Empty;
                FilterTipSluzbenogLicaSelected = null;
                FilterTipSluzbenogLicaEnabled = false;
                FilterCinSelected = null;
                FilterCinEnabled = false;
                FilterSpecijalnostSelected = null;
                FilterSpecijalnostEnabled = false;
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

        public ICommand AddEmployeeCommand { get { return new RelayCommand(addEmployee, canAddEmployee); } }

        private void addEmployee(object param)
        {
            if (FilterTipZaposlenogSelected != null && FilterTipZaposlenogSelected.Id == 1)
            {
                pc.Employees.Add(new Support { JMBG = Jmbg, Name = Name, LastName = LastName, Type = EmployeeTypes.SupportStaff });
                pc.SaveChanges();
            }
            else
            {
                if (FilterTipSluzbenogLicaSelected != null && FilterTipSluzbenogLicaSelected.Id == 0)
                {
                    Cop c = new Cop() { JMBG = Jmbg, Name = Name, LastName = LastName, Type = EmployeeTypes.OfficialStaff, OfficialType = OfficialType.Cop };

                    if (FilterCinSelected != null)
                        c.Rank = Cinovi.FirstOrDefault(x => x.Name == FilterCinSelected.Name);

                    pc.Employees.Add(c);
                    pc.SaveChanges();
                }
                else if (FilterTipSluzbenogLicaSelected != null && FilterTipSluzbenogLicaSelected.Id == 1)
                {
                    Clerk cl = new Clerk() { JMBG = Jmbg, Name = Name, LastName = LastName, Type = EmployeeTypes.OfficialStaff, OfficialType = OfficialType.Clerk };

                    if (FilterCinSelected != null)
                        cl.Specialty = Specijalnosti.FirstOrDefault(x => x.Name == FilterSpecijalnostSelected.Name);

                    pc.Employees.Add(cl);
                    pc.SaveChanges();
                }
            }
        }

        private bool canAddEmployee(object param)
        {
            if (ZaposleniSourceSelected != null || string.IsNullOrEmpty(Jmbg) || string.IsNullOrEmpty(Name)|| string.IsNullOrEmpty(LastName) || FilterTipZaposlenogSelected == null)
                return false;
            if (FilterTipZaposlenogSelected != null && FilterTipZaposlenogSelected.Id == 0)
            {
                if (FilterCinSelected == null)
                    return false;
            }
            if (FilterTipSluzbenogLicaSelected != null && FilterTipSluzbenogLicaSelected.Id == 0)
            {
                if (FilterCinSelected == null)
                    return false;
            }
            else if (FilterTipSluzbenogLicaSelected != null && FilterTipSluzbenogLicaSelected.Id == 1)
            {
                if (FilterSpecijalnostSelected == null)
                    return false;
            }
            return true;
        }

        public ICommand EditEmployeeCommand { get { return new RelayCommand(editEmployee, canEditEmployee); } }

        private void editEmployee(object param)
        {
            pc.Employees.FirstOrDefault(x => x.JMBG == ZaposleniSourceSelected.JMBG).Name = Name;
            pc.Employees.FirstOrDefault(x => x.JMBG == ZaposleniSourceSelected.JMBG).LastName = LastName;
            
            if (FilterTipZaposlenogSelected.Id == 0)
            {
                pc.Employees.FirstOrDefault(x => x.JMBG == ZaposleniSourceSelected.JMBG).Type = EmployeeTypes.OfficialStaff;
            }
            else if (FilterTipZaposlenogSelected.Id == 1)
                pc.Employees.FirstOrDefault(x => x.JMBG == ZaposleniSourceSelected.JMBG).Type = EmployeeTypes.SupportStaff;

            pc.SaveChanges();
        }

        private bool canEditEmployee(object param)
        {
            if (ZaposleniSourceSelected == null || string.IsNullOrEmpty(Jmbg) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(LastName) || FilterTipZaposlenogSelected == null)
                return false;
            if (pc.Employees.FirstOrDefault(x => x.JMBG == Jmbg) != null)
                return false;
            if (FilterTipZaposlenogSelected != null && FilterTipZaposlenogSelected.Id == 0)
            {
                if (FilterCinSelected == null)
                    return false;
            }
            else if (FilterTipZaposlenogSelected != null && FilterTipZaposlenogSelected.Id == 1)
            {
                if (FilterSpecijalnostSelected == null)
                    return false;
            }
            return true;
        }

        public ICommand DeleteEmployeeCommand { get { return new RelayCommand(deleteEmployee, canDeleteEmployee); } }

        private void deleteEmployee(object param)
        {
            // IsDeleted = true
        }

        private bool canDeleteEmployee(object param)
        {
            return ZaposleniSourceSelected != null;
        }

        public ICommand CancelCommand { get { return new RelayCommand(cancel, canCancel); } }

        private void cancel(object param)
        {
            ZaposleniSourceSelected = null;
            Jmbg = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            FilterTipZaposlenogSelected = FilterTipZaposlenog.FirstOrDefault();
            FilterTipSluzbenogLicaSelected = FilterTipSluzbenogLica.FirstOrDefault();
            FilterCinSelected = FilterCin.FirstOrDefault();
            FilterSpecijalnostSelected = null;
        }

        private bool canCancel(object param)
        {
            return true;
        }

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
