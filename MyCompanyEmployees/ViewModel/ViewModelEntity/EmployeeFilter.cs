

namespace MyCompanyEmployees
{
    class EmployeeFilter : BaseViewModel
    {

        private string _filterString;
        public string FilterString
        {
            get {  return _filterString; }
            set 
            { 
                _filterString = value; 
                OnPropertyChanged("FilterString"); 
            }
        }
    }
}
