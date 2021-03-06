﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AddressBook_LinQ_
{
    class AddressBookService
    {
        DataTable dataTable = new DataTable();

        /// <summary>
        /// Create a data table for address book and insert values
        /// </summary>
        public void CreateTable()
        {
            dataTable.Columns.Add("AddressBook Name");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("State");
            dataTable.Columns.Add("ZipCode");
            dataTable.Columns.Add("PhoneNo");
            dataTable.Columns.Add("Email");

            dataTable.Rows.Add("Book1","Friend","Seeta", "Rai", "02-Green Tower", "Mumbai", "Maharashtra", "400500", "9999999999", "seeta@gmail.com");
            dataTable.Rows.Add("Book2","Family","Ram", "Verma", "03-Shastri Nagar", "Delhi", "Delhi", "788890", "7777777777", "ram@gmail.com");
            dataTable.Rows.Add("Book3","Friend","Rahul", "Yadav", "04-Orchids Colony", "Bangalore", "Karnataka","500300","4444444444", "rahulyadav@gmail.com");
            dataTable.Rows.Add("Book4","Profession","Riya", "Singh", "05-Pancham Society", "Mumbai", "Maharashtra", "400503", "3333333333", "riya@gmail.com");

            Console.WriteLine("Table created successfully");
        }

        /// <summary>
        /// Edit contact in the address book
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNo"></param>
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

        /// <summary>
        /// Get contacts by city or state
        /// </summary>
        /// <param name="cityOrState"></param>
        public void GetContactByCityOrState(string cityOrState)
        {
            var result = from contact in dataTable.AsEnumerable()
                         where (contact.Field<string>("City") == cityOrState || contact.Field<string>("State") == cityOrState)
                         select contact;
            foreach (var contact in result)
            {
                Console.WriteLine(contact.Field<string>("First Name") + "\t" + contact.Field<string>("Last Name") +
                     "\t" + contact.Field<string>("Address") + "\t" + contact.Field<string>("City") + "\t" + contact.Field<string>("State") +
                     "\t" + contact.Field<string>("ZipCode") + "\t" + contact.Field<string>("PhoneNo") + "\t" + contact.Field<string>("Email"));
            }
        }

        /// <summary>
        /// Get address book size by city and state
        /// </summary>
        public void GetCountByCityAndState()
        {
            var result = from contact in dataTable.AsEnumerable()
                         group contact by new { State = contact.Field<string>("State"), City = contact.Field<string>("City") } into grp
                         select new { State = grp.Key.State, City = grp.Key.City, Count = grp.Count() };
            foreach(var data in result)
            {
                Console.WriteLine(data.State + "------" + data.City + "------" + data.Count);
            }
        }

        /// <summary>
        /// Given city sort by name
        /// </summary>
        /// <param name="city"></param>
        public void SortByName(string city)
        {
            var result = from contact in dataTable.AsEnumerable()
                         where contact.Field<string>("City") == city
                         orderby contact.Field<string>("First Name"), contact.Field<string>("Last Name")
                         select contact;
            foreach (var contact in result)
            {
                Console.WriteLine(contact.Field<string>("First Name") + "\t" + contact.Field<string>("Last Name") +
                     "\t" + contact.Field<string>("Address") + "\t" + contact.Field<string>("City") + "\t" + contact.Field<string>("State") +
                     "\t" + contact.Field<string>("ZipCode") + "\t" + contact.Field<string>("PhoneNo") + "\t" + contact.Field<string>("Email"));
            }
        }

        /// <summary>
        /// Get size of address book by type
        /// </summary>
        public void CountByType()
        {
            var result = from contact in dataTable.AsEnumerable()
                         group contact by contact.Field<string>("Type") into grp
                         select new { Type = grp.Key, Count = grp.Count() };
            foreach(var data in result)
            {
                Console.WriteLine(data.Type + "-----" + data.Count);
            }
        }

        /// <summary>
        /// Remove a contact from address book
        /// </summary>
        /// <param name="name"></param>
        public void RemoveContact(string name)
        {
            var result = from contact in dataTable.AsEnumerable()
                         where contact.Field<string>("First Name") == name
                         select contact;
            foreach (var contact in result.ToList())
            {
                contact.Delete();
            }
             Console.WriteLine("Contact removed successfully");
        }

        /// <summary>
        /// Display address book
        /// </summary>
        public void Display()
        {
            foreach(var contact in dataTable.AsEnumerable())
            {
                Console.WriteLine(contact.Field<string>("AddressBook Name") + "\t" + contact.Field<string>("Type") +"\t"+
                    contact.Field<string>("First Name")+"\t"+ contact.Field<string>("Last Name")+
                    "\t"+ contact.Field<string>("Address")+"\t"+contact.Field<string>("City")+"\t"+ contact.Field<string>("State")+
                    "\t"+ contact.Field<string>("ZipCode")+"\t"+ contact.Field<string>("PhoneNo")+"\t"+ contact.Field<string>("Email"));
            }
        }
    }
}
