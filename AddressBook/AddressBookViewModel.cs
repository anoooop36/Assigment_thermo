using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AddressBookModel;


namespace AddressBookViewModel
{
    public class AddressBookViewModel
    {
        public AddressBookViewModel()
        {
        }

        public List<AddressBookModel> emp = List<AddressBookModel>();

        AddressBookModel model1 = new AddressBookModel("Anoop", "df", 2, 8945);
        AddressBookModel model1 = new AddressBookModel("Ajay", "wwe", 3, 9944);
        emp.Add(model1);
        emp.Add(model2);

    
    
}
}
