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

        static void testAddNewContact()
        {
            ClsContact contact = new ClsContact();

            contact.FirstName = "Salma";
            contact.LastName = "Rady";
            contact.Email = "SR@Gmail.com";
            contact.Phone = "35754635";
            contact.Address = "Nafesh St ";
            contact.DateOfBirth = new DateTime(1999, 3, 10, 5, 00, 0);
            contact.countryID = 2;
            contact.ImagePath = "";

            if (contact.Save()) 
            {
                Console.WriteLine("Contact Added Successfully With ID = " + contact.ID);
            }
        }

        static void testUpdateContact(int ID)
        {
            ClsContact contact = ClsContact.Find(ID);
            if (contact != null)
            {

                contact.FirstName = "Khaled";
                contact.LastName = "Salem";
                contact.Email = "KS@Gmail.com";
                contact.Phone = "00922429";
                contact.Address = "Gozra St ";
                contact.DateOfBirth = new DateTime(1990, 1, 11, 4, 10, 0);
                contact.countryID = 4;
                contact.ImagePath = "";

                if (contact.Save())
                {
                    Console.WriteLine("Contact Updated Successfully");
                }

            }
        }


        static void Main(string[] args)
        {
            //testFindContact(3);
            //testAddNewContact();
            testUpdateContact(2);
            Console.ReadKey();
        }
    }
}
