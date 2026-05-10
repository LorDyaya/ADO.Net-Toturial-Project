using System;
using System.Data;
using ContactsBusinessLayer;

namespace Console_App
{
    internal class Program
    {

        static void testFindContact(int ID)
        {
            ClsContact contact = ClsContact.Find(ID);

            if (contact != null) 
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.DateOfBirth);
                Console.WriteLine(contact.ImagePath);
                Console.WriteLine(contact.countryID);
               
            }
            else
            {
                Console.WriteLine("Contact {" + ID + "} Not Found!");
            }
        }
        static void Main(string[] args)
        {
            testFindContact(1);
            Console.ReadKey();
        }
    }
}
