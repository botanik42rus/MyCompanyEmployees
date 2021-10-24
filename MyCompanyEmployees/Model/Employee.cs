using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using ProtoBuf;


namespace MyCompanyEmployees
{

    [ProtoContract]
    class Employee: BaseViewModel
    {

        #region IsFilteredMethod
        public bool IsFiltered(string SelectedFilter, string TextFilter)
        {
            var propInfo = typeof(Employee).GetProperty(SelectedFilter);
            string currentProperty = (string) propInfo.GetValue(this).ToString();
            return currentProperty.Contains(TextFilter);
        }
        #endregion

        #region FirstName
        private string _firstName;

        [ProtoMember(1)]
        public string FirstName
        {
            get { return _firstName; }
            set 
            {  
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        #endregion

        #region LastName
        private string _lastname;
        [ProtoMember(2)]
        public string LastName
        {
            get {  return _lastname; }
            set 
            {
                _lastname = value;
                OnPropertyChanged("LastName");
            }
        }
        #endregion

        #region MiddleName
        private string _middleName;
        [ProtoMember(3)]
        public string MiddleName
        {
            get {  return _middleName; }
            set 
            {  
                _middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        #endregion

        #region Age
        private int _age;
        [ProtoMember(4)]
        public int Age
        {
            get {  return _age; }
            set 
            {  
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        #endregion

        #region Wage
        private double _wage;
        [ProtoMember(5)]
        public double Wage
        {
            get {  return _wage; }
            set 
            {  
                _wage = value;
                OnPropertyChanged("Wage");
            }
        }
        #endregion

        #region E-Mail
        private string _email;
        [ProtoMember(6)]
        public string Email
        {
            get {  return _email; }
            set 
            {  
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        #endregion

        #region Phone
        private string _phone;
        [ProtoMember(7)]
        public string Phone
        {
            get {  return _phone; }
            set 
            {  
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        #endregion

        #region Description
        private string _description;
        [ProtoMember(8)]
        public string Description
        {
            get {  return _description; }
            set 
            {  
                _description = value;
                OnPropertyChanged("Descripion");
            }
        }
        #endregion

        #region Position
        private string _position;
        [ProtoMember(9)]
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        #endregion

        #region Department
        private string _department;
        [ProtoMember(10)]
        public string Department
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged("Department");
            }
        }
        #endregion

        #region IsFired
        private bool _isFired;
        [ProtoMember (11)]
        public bool IsFired
        {
            get { return _isFired; }
            set
            {
                _isFired = value;
                OnPropertyChanged("IsFired");
            }
        }
        #endregion

        #region Category
        private string _category;
        [ProtoMember(12)]
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        #endregion
    }
}
