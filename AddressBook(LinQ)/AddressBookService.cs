using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBook_LinQ_
{
    class AddressBookService
    {
        DataTable dataTable = new DataTable();
        public void CreateTable()
        {
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("State");
            dataTable.Columns.Add("ZipCode");
            dataTable.Columns.Add("PhoneNo");
            dataTable.Columns.Add("Email");
        }
    }
}
