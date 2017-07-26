using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class AddressBookModel : INotifyPropertyChanged
{

    private string name;
    private string employeeId;
    private string phoneNo;
    private string address;
    public AddressBookModel(string n,string a, string e, string p)
	{
        Name = n;
        Address = a;
        EmployeeId = e;
        PhoneNo = p;
        ImagePath= @"C:\Users\anoop.chaudhary\Documents\Visual Studio 2017\Projects\AddressBook\AddressBook\bin\Debug\images/download.png";
    }

    public string Name {
        get {
            return name;
        }
        set {
            name = value;
            NotifyPropertyChanged("Name");
        }
    }
    public string Address {
        get
        {
            return address;
        }
        set
        {
            address = value;
            NotifyPropertyChanged("Address");
        }
    }
    public string EmployeeId {
        get
        {
            return employeeId;
           
        }
        set
        {
            employeeId = value;
            NotifyPropertyChanged("EmployeeId");
        }
    }
    public string PhoneNo {
        get
        {
            return phoneNo;
        }
        set
        {
            phoneNo = value;
            NotifyPropertyChanged("PhoneNo");
        }
    }

    private string imagePath;
    public string ImagePath {
        get
        {
            return imagePath;
        }
        set
        {
            imagePath = value;
            NotifyPropertyChanged("ImagePath");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
