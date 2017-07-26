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

        public ObservableCollection<AddressBookModel> EmpList { get { return empList; } set { empList = value; } }
        public ObservableCollection<AddressBookModel> empList ;

        private string textBox1;

        public string TextBox1 {
            get {
                    return textBox1;
            }
            set {
                    textBox1 = value;
                if (textBox1!=string.Empty && SelectedEmployee!=null)
                    SelectedEmployee.Name = textBox1;
                NotifyPropertyChanged("EmpList");
                NotifyPropertyChanged("TextBox1");
            }
        }
        private string textBox2;

        public string TextBox2
        {
            get
            {
                return textBox2;
            }
            set
            {
                textBox2 = value;
                if (textBox2 != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.EmployeeId = textBox2;
                NotifyPropertyChanged("EmpList");
                NotifyPropertyChanged("TextBox2");
            }
        }

        private string textBox3;

        public string TextBox3
        {
            get
            {
                return textBox3;
            }
            set
            {
                textBox3 = value;
                if (textBox3 != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.Address = textBox3;
                NotifyPropertyChanged("EmpList");
                NotifyPropertyChanged("TextBox3");
            }
        }

        private string textBox4;

        public string TextBox4
        {
            get
            {
                return textBox4;
            }
            set
            {
                textBox4 = value;
                if (textBox4 != string.Empty && SelectedEmployee != null)
                    SelectedEmployee.PhoneNo = textBox4;
                NotifyPropertyChanged("EmpList");
                NotifyPropertyChanged("TextBox4");
            }
        }

        public string Path { get; set; }

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
                    TextBox1 = SelectedEmployee.Name;
                    TextBox2 = SelectedEmployee.EmployeeId;
                    TextBox3 = SelectedEmployee.Address;
                    TextBox4 = SelectedEmployee.PhoneNo;
                    Path = SelectedEmployee.ImagePath;
                    NotifyPropertyChanged("TextBox1");
                    NotifyPropertyChanged("TextBox3");
                    NotifyPropertyChanged("TextBox4");
                    NotifyPropertyChanged("TextBox2");
                    NotifyPropertyChanged("Path");
                }
                //DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string TextClear { get; set; }

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
            return true;
        }
        private bool CanClearExecute(object param)
        {
            return true;
        }
        private bool CanDeleteExecute(object param)
        {
            return true;
        }

        private void AddName(object param)
        {
            //Names.Add(string.Format("Name {0}", id));
            //id++;
            
            AddressBookModel obj = new AddressBookModel(TextBox1,TextBox3,TextBox2,TextBox4);
            EmpList.Add(obj);

        }

        private void Clear(object param) {

            TextBox1 = string.Empty;
            TextBox2 = string.Empty;
            TextBox3 = string.Empty;
            TextBox4 = string.Empty;
            Path = string.Empty;
            NotifyPropertyChanged(TextBox1);
        }

        private void delete(object param) {
            EmpList.Remove(SelectedEmployee);
            TextBox1 = string.Empty;
            TextBox2 = string.Empty;
            TextBox3 = string.Empty;
            TextBox4 = string.Empty;
            Path = string.Empty;
            NotifyPropertyChanged(TextBox1);
        }

        

        //There is something called CommandParameter
        //It is any property from the view that you want to pass as an input for your logic.
        //That's why the signature for AddName is AddName(object param)
        #endregion



    }
}

