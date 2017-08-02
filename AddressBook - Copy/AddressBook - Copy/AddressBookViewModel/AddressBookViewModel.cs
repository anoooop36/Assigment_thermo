using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AddressBook.Commands;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace AddressBook.ViewModel 
{
    public class AddressBookViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<AddressBookModel> empList;
        public ObservableCollection<AddressBookModel> EmpList { get { return empList; } set { empList = value; } }
        

        private string textName;
        public string TextName {
            get {
                    return textName;
            }
            set {
                    textName = value;
                //if (textName!=string.Empty && SelectedEmployee!=null)
                //    SelectedEmployee.Name = textName;
                NotifyPropertyChanged("TextName");

            }
        }

        private string textId;
        public string TextId
        {
            get
            {
                return textId;
            }
            set
            {
                textId = value;
                if (textId != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.EmployeeId = textId;
                NotifyPropertyChanged("TextId");

            }
        }

        private string textAddress;
        public string TextAddress
        {
            get
            {
                return textAddress;
            }
            set
            {
                textAddress = value;
                if (textAddress != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.Address = textAddress;
                NotifyPropertyChanged("TextAddress");
            }
        }

        private string textPhoneNo;
        public string TextPhoneNo
        {
            get
            {
                return textPhoneNo;
            }
            set
            {
                textPhoneNo = value;
                if (textPhoneNo != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.PhoneNo = textPhoneNo;
                NotifyPropertyChanged("TextPhoneNo");

            }
        }

        private string path;
        public string Path {
            get { return path; }
            set { path = value; NotifyPropertyChanged("Path"); }
            
        }

        private AddressBookModel _selectedEmployee;
        public AddressBookModel SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }

            set
            {
                _selectedEmployee = value;
                if (value != null) {
                    TextName = SelectedEmployee.Name;
                    TextId = SelectedEmployee.EmployeeId;
                    TextAddress = SelectedEmployee.Address;
                    TextPhoneNo = SelectedEmployee.PhoneNo;
                    Path = SelectedEmployee.ImagePath;
                }
                //DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        

        public AddressBookViewModel()
        {
            EmpList = new ObservableCollection<AddressBookModel>();
            AddressBookModel model2 = new AddressBookModel("Anoop", "df", "2", "8945");
            model2.ImagePath = @"C:\Users\anoop.chaudhary\Documents\Visual Studio 2017\Projects\AddressBook\AddressBook\bin\Debug\images/download.png";
            EmpList.Add(model2);
            AddressBookModel model3 = new AddressBookModel("Atul", "gdf", "4", "9945");
            model3.ImagePath = @"C:\Users\anoop.chaudhary\Documents\Visual Studio 2017\Projects\AddressBook\AddressBook\bin\Debug\images/download1.png";
            EmpList.Add(model3);
            AddCommand = new RelayCommand(AddName, CanAddExecute);
            ClearCommand = new RelayCommand(Clear, CanClearExecute);
            DeleteCommand = new RelayCommand(delete,CanDeleteExecute);

        }

        #region Private Members

     
        private ICommand addCommand;
        private ICommand clearCommand;
        private ICommand deleteCommand;
        #endregion

        #region Properties



        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; NotifyPropertyChanged("AddCommand"); }
        }

        public ICommand ClearCommand
        {
            get { return clearCommand; }
            set { clearCommand = value; NotifyPropertyChanged("ClearCommand"); }
        }

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; NotifyPropertyChanged("DeleteCommand"); }
        }
        #endregion

        #region INotifyPropertyChanged Implentation

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //This is to notify the view that a property has changed
        #endregion

       

        #region Private Methods

        private bool CanAddExecute(object param)
        {
            return this.TextName != string.Empty && this.TextId!= string.Empty && this.TextAddress!= string.Empty && this.TextPhoneNo!= string.Empty;
        }

        private bool CanClearExecute(object param)
        {
            return true;
        }
        private bool CanDeleteExecute(object param)
        {
            return this.SelectedEmployee!=null;
        }

        private void AddName(object param)
        {
            //Names.Add(string.Format("Name {0}", id));
            //id++;
            
            AddressBookModel obj = new AddressBookModel(TextName,TextAddress,TextId,TextPhoneNo);
            EmpList.Add(obj);

        }

        private void Clear(object param) {

            TextName = string.Empty;
            TextId = string.Empty;
            TextAddress = string.Empty;
            TextPhoneNo = string.Empty;
            Path = string.Empty;
            AddressBookModel model = new AddressBookModel("","","","");
            //empList.Add(model);
            SelectedEmployee = model;
            //NotifyPropertyChanged(Path);
        }

        private void delete(object param) {
            EmpList.Remove(SelectedEmployee);
            TextName = string.Empty;
            TextId = string.Empty;
            TextAddress = string.Empty;
            TextPhoneNo = string.Empty;
            Path = string.Empty;
            //NotifyPropertyChanged(TextName);
        }

        

        //There is something called CommandParameter
        //It is any property from the view that you want to pass as an input for your logic.
        //That's why the signature for AddName is AddName(object param)
        #endregion



    }
}

