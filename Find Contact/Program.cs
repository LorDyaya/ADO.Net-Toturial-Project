using System;
using System.Data;
using ContactsBusiness_Layer;

namespace Contactspresentation_layer
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

        static void testFindCountry(string Name)
        {
            clsCountry country = clsCountry.FindCountry(Name);

            if (country != null)
            {
                Console.WriteLine(country.ID);
                Console.WriteLine(country.CountryName);
                Console.WriteLine(country.Code);
                Console.WriteLine(country.PhoneCode);
            }
            else
            {
                Console.WriteLine("There No Country With that name!");
            }
        }

        static void testFindCountryByID(int ID)

        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                Console.WriteLine("Name: " + Country1.CountryName);
                Console.WriteLine("Code: " + Country1.Code);
                Console.WriteLine("PhoneCode: " + Country1.PhoneCode);

            }

            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
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

                contact.FirstName = "Khallled";
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

        static void testUpdateCountry(int ID)
        {
            clsCountry country = clsCountry.Find(ID);
            if (country != null) 
            {
                country.CountryName = "EGYPT";
                country.Code = "02";
                country.PhoneCode = "+02";

                if (country.Save())
                {
                    Console.WriteLine("Country Updated Successfully");
                }
            }
            else
            {
                Console.WriteLine("Country is you want to update is Not found!");
            }
        }

        static void testDeleteContact(int ID)
        {
            if (ClsContact.IsContactExist(ID))
            {
                if (ClsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Failed To Delete Contact");
                }               
            }
            else
            {
                Console.WriteLine("No, this Contact is Not Exist For Delete");
            }
          
        }

        static void testGetAllContacts()
        {
            DataTable datatable = ClsContact.GetAllContacts();
            Console.WriteLine("Contacts Data : ");
            foreach (DataRow row in datatable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]} , {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void testIsContactExist(int ID)
        {
            
            if (ClsContact.IsContactExist(ID)) 
            {
                Console.WriteLine("Yes, Contact Is Found");
            }
            else
            {
                Console.WriteLine("No, this Contact is Not Exist");
            }
        }

        static void testIsCountryExist(string Name)
        {
            if (clsCountry.IsCountryExist(Name)) 
            {
                Console.WriteLine("Yes, Country Is Found");
            }
            else
            {
                Console.WriteLine("No, This Country is Not Exist");
            }
        }

        static void Main(string[] args)
        {
            //testFindContact(1);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(201);
            //testGetAllContacts();
            //testIsContactExist(133);
            //testFindCountry("Germany");
            // testIsCountryExist("Ghana");
            testUpdateCountry(7);
           

            Console.ReadKey();
        }
    }
}
