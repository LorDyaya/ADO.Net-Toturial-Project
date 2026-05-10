using System;
using System.Data;
using ContactsDataLayer;

namespace ContactsBusinessLayer
{
    public class ClsContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int countryID {  get; set; }

        public ClsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";            
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.countryID = -1;
            this.ImagePath = "";
         
        }

        private ClsContact(int ID, string FirstName, string LastName,
         string Email, string Phone, string Address, DateTime DateOfBirth, string ImagePath, int countryID)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;                                                 
            this.DateOfBirth = DateOfBirth;
            this.countryID = countryID;
            this.ImagePath = ImagePath;            
        }

        public static ClsContact Find(int ID)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int countryID = -1;

            if (ClsContactsDataAccsess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email,
                ref Phone, ref Address, ref DateOfBirth, ref ImagePath, ref countryID))  

                return new ClsContact(ID, FirstName, LastName, Email, Phone, Address,
                    DateOfBirth, ImagePath, countryID);
            else
                return null;            
        }

    };

 
  
}
