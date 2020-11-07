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

            dataTable.Rows.Add("Seeta", "Ram", "02-Green Tower", "Mumbai", "Maharashtra", "400500", "9999999999", "seeta@gmail.com");
            dataTable.Rows.Add("Ram", "Verma", "03-Shastri Nagar", "Delhi", "Delhi", "788890", "7777777777", "ram@gmail.com");
            dataTable.Rows.Add("Rahul", "Yadav", "04-Orchids Colony", "Bangalore", "Karnataka","500300","4444444444", "rahulyadav@gmail.com");
            dataTable.Rows.Add("Riya", "Singh", "05-Pancham Society", "Mumbai", "Maharashtra", "400503", "3333333333", "riya@gmail.com");

            Console.WriteLine("Table created successfully");
        }
    }
}
