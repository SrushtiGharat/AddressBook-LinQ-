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

            dataTable.Rows.Add("Seeta", "Rai", "02-Green Tower", "Mumbai", "Maharashtra", "400500", "9999999999", "seeta@gmail.com");
            dataTable.Rows.Add("Ram", "Verma", "03-Shastri Nagar", "Delhi", "Delhi", "788890", "7777777777", "ram@gmail.com");
            dataTable.Rows.Add("Rahul", "Yadav", "04-Orchids Colony", "Bangalore", "Karnataka","500300","4444444444", "rahulyadav@gmail.com");
            dataTable.Rows.Add("Riya", "Singh", "05-Pancham Society", "Mumbai", "Maharashtra", "400503", "3333333333", "riya@gmail.com");

            Console.WriteLine("Table created successfully");
        }

        public void EditPhoneNo(string name,string phoneNo)
        {
            var result = from contact in dataTable.AsEnumerable()
                        where contact.Field<string>("First Name") == name
                        select contact;
            foreach(var contact in result)
            {
                contact.SetField("PhoneNo", phoneNo);
            }
            Console.WriteLine("Contact edited successfully");
        }

        public void Display()
        {
            foreach(var contact in dataTable.AsEnumerable())
            {
                Console.WriteLine(contact.Field<string>("First Name")+"\t"+ contact.Field<string>("Last Name")+
                    "\t"+ contact.Field<string>("Address")+"\t"+contact.Field<string>("City")+"\t"+ contact.Field<string>("State")+
                    "\t"+ contact.Field<string>("ZipCode")+"\t"+ contact.Field<string>("PhoneNo")+"\t"+ contact.Field<string>("Email"));
            }
        }
    }
}
