using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AddressBook.Commands;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    public class AddressBookViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<AddressBookModel> EmpList { get { return empList; } set { empList = value; } }
        public ObservableCollection<AddressBookModel> empList ;
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string EmployeeId { get; set; }
        public string MyProperty { get { return ""; } set { } }

        public AddressBookViewModel()
        {
            EmpList = new ObservableCollection<AddressBookModel>();
            AddressBookModel model2 = new AddressBookModel("Anoop", "df", "2", "8945");
           EmpList.Add(model2);
            AddressBookModel model3 = new AddressBookModel("Atul", "gdf", "4", "9945");
            EmpList.Add(model3);
            AddCommand = new RelayCommand(AddName, CanAddExecute);
            ClearCommand = new RelayCommand(Clear, CanAddExecute);


        }

        #region Private Members

     
        private ICommand addCommand;
        private ICommand clearCommand;
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
        #endregion

        #region INotifyPropertyChanged Implentation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
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

        private void AddName(object param)
        {
            //Names.Add(string.Format("Name {0}", id));
            //id++;
            
            AddressBookModel obj = new AddressBookModel("ajay","Banglore","22","6636");
            EmpList.Add(obj);

        }

        private void Clear(object param) {

            MyProperty="";
          


        }

        //There is something called CommandParameter
        //It is any property from the view that you want to pass as an input for your logic.
        //That's why the signature for AddName is AddName(object param)
        #endregion



    }
}

