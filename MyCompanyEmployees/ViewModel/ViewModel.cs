using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using ProtoBuf;
using System.Windows;
using System.Windows.Data;
using System.Reflection;

namespace MyCompanyEmployees
{
    class ViewModel: BaseViewModel
    {
        #region Constructor
        public ViewModel()
        {


            using (FileStream fs = new FileStream("Empoyees.proto", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    Employees = Serializer.Deserialize<ObservableCollection<Employee>>(fs);
                }
                else
                {
                    Employees = new ObservableCollection<Employee>();
                }

            }

            eFilter = new ObservableCollection<EmployeeFilter>();


            PropertyInfo[] typeInfos = typeof(Employee).GetProperties();
            foreach (PropertyInfo propertyInfos in typeInfos)
            {
                eFilter.Add(new EmployeeFilter { FilterString = propertyInfos.Name });
                
                
            }
            
            FilteredEmployee = CollectionViewSource.GetDefaultView(Employees);

            FilteredEmployee.Filter = i =>
            {
                if (string.IsNullOrEmpty(FilterParams))
                {
                    return true;
                }

                Employee employee = i as Employee;

                return employee.IsFiltered(SelectedFilter.FilterString, FilterParams);
            };
        }
        #endregion

        #region Save Method
        public void ViewModelSave()
        {

            using (FileStream fs = new FileStream("Empoyees.proto", FileMode.OpenOrCreate))
            {
                Serializer.Serialize(fs, Employees);
            }

        }

        #endregion

        #region Commands
        private MyCommand _removeCommand;

        public MyCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new MyCommand(obj =>
                {
                    Employee currentEmployee = SelectedEmployee;

                    if (currentEmployee != null)
                    {
                        Employees.Remove(currentEmployee);
                    }
                }
                ));
            }
        }


        private MyCommand _addCommand;
        public MyCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new MyCommand(obj =>
                {
                    if (!string.IsNullOrEmpty(FilterParams))
                    {
                        MessageBox.Show("Очистите фильтр, чтобы добавить нового пользователя");
                        return;
                    }
                    Employee currentEmployee = new Employee();
                    Employees.Insert(0, currentEmployee);
                    SelectedEmployee = currentEmployee;

                }
                ));
            }
        }
        #endregion

        #region Employees collection

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }


        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
            }
        }
        #endregion

        #region Filter Entity

        public ICollectionView FilteredEmployee { get; set; }

        private string _filterParams;
        public string FilterParams
        {
            get {  return _filterParams; }
            set 
            {
                _filterParams = value;
                FilteredEmployee.Refresh();
                OnPropertyChanged("FilterParams");
            }
        }

        public ObservableCollection<EmployeeFilter> eFilter { get; set; }

        private EmployeeFilter _selectedFilter;
        public EmployeeFilter SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                _selectedFilter = value;
                OnPropertyChanged("SelectedFilter");
            }
        }

        #endregion
    }
}
