using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Input;

namespace datingapp
{
    public class Sql
    {
        private static string ConnectionString = @"Data Source=BYG-A101-VICRE\MSSQLSERVER01;Initial Catalog=datingapp;Integrated Security=True";

        public static bool SqlConnectionOK()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        // 1) Create, Data der skal creates i en tabel (det hedder insert på sql'sk)
        public static void CreateAccount(Users insertedObj)
        {
            // Forbindelse
            //
            // Laver et sql objekt - byggestenene til at oprette forbindelse til serveren
            SqlConnection connection = new SqlConnection(ConnectionString);
            // Åbner forbindelsen.
            connection.Open();
            //
            // Forbindelse

            // Kommando type ([text] for sql, StoredProcedure for StoredProcedure)
            //
            // Laver ny "Kommando" aka Query -- med stored procedure
            SqlCommand command = new SqlCommand("sp_CreateAccount", connection);
            // command = new SqlCommand("SELECT * FROM Users", connection);
            command.CommandType = CommandType.StoredProcedure;
            //
            // Kommando type

            // Table Users
            command.Parameters.AddWithValue("@MyUsername", insertedObj.MyUsername);
            command.Parameters.AddWithValue("@MyPassword", insertedObj.MyPassword);
            command.Parameters.AddWithValue("@Active", insertedObj.Active);
            // Table PersonInfo
            command.Parameters.AddWithValue("@MyFirstName", insertedObj.PersonInfo.MyFirstName);
            command.Parameters.AddWithValue("@MyLastName", insertedObj.PersonInfo.MyLastName);
            command.Parameters.AddWithValue("@MyAge", insertedObj.PersonInfo.MyAge);
            command.Parameters.AddWithValue("@MyHeight", insertedObj.PersonInfo.MyHeight);
            command.Parameters.AddWithValue("@MyWeight", insertedObj.PersonInfo.MyWeight);
            command.Parameters.AddWithValue("@MyGender", insertedObj.PersonInfo.MyGender);
            // TABLE Addresses
            command.Parameters.AddWithValue("@MyCity", insertedObj.Address.MyCity);
            command.Parameters.AddWithValue("@MyZipCode", insertedObj.Address.MyZipCode);
            // TABLE AttractionTable
            command.Parameters.AddWithValue("@ILikeGender", insertedObj.AttractionTable.ILikeGender);
            command.Parameters.AddWithValue("@MinAge", insertedObj.AttractionTable.MinAge);
            command.Parameters.AddWithValue("@MaxAge", insertedObj.AttractionTable.MaxAge);
            command.Parameters.AddWithValue("@MinHeight", insertedObj.AttractionTable.MinHeight);
            command.Parameters.AddWithValue("@MaxHeight", insertedObj.AttractionTable.MaxHeight);
            command.Parameters.AddWithValue("@MinWeight", insertedObj.AttractionTable.MinWeight);
            command.Parameters.AddWithValue("@MaxWeight", insertedObj.AttractionTable.MaxWeight);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        public static bool ValidateCredentials(string username, string password)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT COUNT (*) FROM Users WHERE MyUsername=@MyUsername AND MyPassword=@MyPassword", connection);
            command.Parameters.AddWithValue("@MyUsername", username);
            command.Parameters.AddWithValue("@MyPassword", password);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            connection.Dispose();

            if(result==1) return true;
            return false;
        }

        public static Users GetUserObject(string username)
        {
            Users user = new Users();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($@"       
                SELECT * FROM [Users] 
                INNER JOIN PersonInfo ON PersonInfo.UsersID = [Users].UsersID
                INNER JOIN [Addresses] ON [Addresses].UsersID = [Users].UsersID
                INNER JOIN [AttractionTable] ON [AttractionTable].UsersID = Users.UsersID
                WHERE Users.MyUsername = @username
            ", connection);
            command.Parameters.AddWithValue("@username", username);
            
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {                
                // table Users
                user.UsersID = reader.GetInt32(0);
                user.MyUsername = reader.GetString(1);
                user.MyPassword = reader.GetString(2);
                user.Active = reader.GetString(3);
                // table PersonInfo
                user.PersonInfo = new PersonInfo();
                user.PersonInfo.PersonInfoID = reader.GetInt32(4);
                user.PersonInfo.UsersID = reader.GetInt32(5);
                user.PersonInfo.MyFirstName = reader.GetString(6);
                user.PersonInfo.MyLastName = reader.GetString(7);
                user.PersonInfo.MyAge = reader.GetInt32(8);
                user.PersonInfo.MyHeight = reader.GetInt32(9);
                user.PersonInfo.MyWeight = reader.GetInt32(10);
                user.PersonInfo.MyGender = reader.GetString(11);
                // table Addresses
                user.Address = new Addresses();
                user.Address.AddressesID = reader.GetInt32(12);
                user.Address.UsersID = reader.GetInt32(13);
                user.Address.MyCity = reader.GetString(14);
                user.Address.MyZipCode = reader.GetString(15);
                // table Attractiontable
                user.AttractionTable = new AttractionTable()
                {
                    AttractionTableID = reader.GetInt32(16),
                    UsersID = reader.GetInt32(17),
                    ILikeGender = reader.GetString(18),
                    MinAge = reader.GetInt32(19),
                    MaxAge = reader.GetInt32(20),
                    MinHeight = reader.GetInt32(21),
                    MaxHeight = reader.GetInt32(22),
                    MinWeight = reader.GetInt32(23),
                    MaxWeight = reader.GetInt32(24)
                };
            }

            command.Dispose();
            connection.Close();
            connection.Dispose();

            return user;
        }

        // LoginAccount - SELECT * FROM Users WHERE Username=<username> AND MyPassword=<password> LIMIT 1


        // 2a) DataAdapter og DataTable, returnere DataTable
        public static DataTable ReadTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                DataTable records = new DataTable();

                //Create new DataAdapter
                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                    //Use DataAdapter to fill DataTable records
                    con.Open();
                    a.Fill(records);
                }
                return records;
            }
        }
    }
}
