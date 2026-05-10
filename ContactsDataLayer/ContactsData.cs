using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataLayer
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
                    ImagePath = (string)reader["ImagePath"];                   
                    countryID = (int)reader["countryID"];
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

    }
}
