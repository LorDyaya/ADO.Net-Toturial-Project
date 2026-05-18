using ContactsDataLayer;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

namespace ContactsData_Layer
{
    public class ClsContactsDataAccsess
    {
        public static bool GetContactInfoByID(int ID,ref string FirstName ,ref string LastName ,ref string Email ,
        ref string Phone ,ref string Address , ref DateTime DateOfBirth, ref string ImagePath, ref int countryID )
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    countryID = (int)reader["countryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
                }
                else
                {
                    isfound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static int AddNewContact(string FirstName , string LastName , string Email, string Phone,
            string Address, DateTime DateOfBirth, string ImagePath, int countryID)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, 
                                                   DateOfBirth, ImagePath, CountryID)
                          VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, 
                                  @ImagePath, @CountryID);
                          SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);            
            command.Parameters.AddWithValue("@CountryID", countryID);
            if (ImagePath != "") 
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }
             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ContactID;
        }


        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email, string Phone,
            string Address, DateTime DateOfBirth, string ImagePath, int countryID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE Contacts   
                            SET FirstName = @FirstName,      
                                LastName = @LastName,
                                Email = @Email, 
                                Phone = @Phone,
                                Address = @Address, 
                                DateOfBirth = @DateOfBirth,
                                ImagePath = @ImagePath,
                                CountryID = @CountryID
                                WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address",Address);
            command.Parameters.AddWithValue("@DateOfBirth",DateOfBirth);
            command.Parameters.AddWithValue("@CountryID",countryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();               
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }


        public static bool DeleteContact(int ContactID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = @"DELETE Contacts                                              
                                WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllContacts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "SELECT * From Contacts";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsContactExist(int ContactID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found = 1 FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID",ContactID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

  

    }

    public class ClsCountriesDataAccess
    {
        public static bool GetCountryInfo(ref int CountryID, string CountryName)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "SELECT * from Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsCountryExist(string CountryName)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found = 1 FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }

}
