using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
