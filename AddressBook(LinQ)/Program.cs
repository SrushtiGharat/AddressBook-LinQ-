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

            Console.WriteLine("1.Edit Contact\n2.Remove Contact\n3.Get Contact By City Or State\n4.Get count by city and state");
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
                case 2:
                    Console.WriteLine("Enter name");
                    string nameToDelete = Console.ReadLine();
                    addressBook.RemoveContact(nameToDelete);
                    addressBook.Display();
                    break;
                case 3:
                    Console.WriteLine("Enter city or state");
                    string cityOrState = Console.ReadLine();
                    addressBook.GetContactByCityOrState(cityOrState);
                    break;
                case 4:
                    addressBook.GetCountByCityAndState();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
