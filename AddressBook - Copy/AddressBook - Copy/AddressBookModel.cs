using System;

namespace AddressBookModel
{
    public class AddressBookModel
    {
        public AddressBookModel(string n, string a, int e, int p)
        {
            Name = n;
            Address = a;
            EmployeeId = e;
            PhoneNo = p;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int EmployeeId { get; set; }
        public int PhoneNo { get; set; }

    }
}
