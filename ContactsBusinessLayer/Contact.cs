using System;
using System.Data;
using ContactsData_Layer;

namespace ContactsBusiness_Layer
{
    public class ClsContact
    {
        public enum EnMode {AddNew = 0 , Update = 1};
        EnMode Mode = EnMode.AddNew;
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

            Mode = EnMode.AddNew ;
         
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
            
            Mode = EnMode.Update ;
        }

        private bool _AddNewContact()
        {
            this.ID = ClsContactsDataAccsess.AddNewContact(this.FirstName,this.LastName,this.Email,
                this.Phone,this.Address,this.DateOfBirth,this.ImagePath,this.countryID);

            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return ClsContactsDataAccsess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email,
                           this.Phone, this.Address, this.DateOfBirth, this.ImagePath, this.countryID);

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

        public static bool DeleteContact(int ID)
        {
            return ClsContactsDataAccsess.DeleteContact(ID);
        }

        public static DataTable GetAllContacts()
        {
            return ClsContactsDataAccsess.GetAllContacts();
        }

        public static bool IsContactExist(int ID)
        {
            return ClsContactsDataAccsess.IsContactExist(ID);
        }

        public bool Save()
            //save method
        {
            switch (Mode)
            {
                case EnMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EnMode.Update:
                    return _UpdateContact();
            }
            return false;
        }


    };

    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
        }

        private clsCountry(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsCountry FindCountry(string CountryName)
        {
            int ID = -1;
            if (ClsCountriesDataAccess.GetCountryInfo(ref ID, CountryName))
            {
                return new clsCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static bool IsCountryExist( string CountryName)
        {
            return ClsCountriesDataAccess.IsCountryExist(CountryName);
        }
    }

};
