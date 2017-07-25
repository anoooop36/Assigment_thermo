using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class AddressBookModel
{
    
    public AddressBookModel(string n,string a, string e, string p)
	{
        Name = n;
        Address = a;
        EmployeeId = e;
        PhoneNo = p;
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public string EmployeeId { get; set; }
    public string PhoneNo { get; set; }
    public string ImagePath { get; set; }

}
