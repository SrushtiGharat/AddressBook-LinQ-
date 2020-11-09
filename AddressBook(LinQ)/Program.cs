using System;

namespace AddressBook_LinQ_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book using Linq");
            AddressBookService addressBook = new AddressBookService();
            addressBook.CreateTable();

            Console.WriteLine("1.Edit Contact");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new phone no");
                    string phone = Console.ReadLine();
                    addressBook.EditPhoneNo(name, phone);

                    addressBook.Display();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
