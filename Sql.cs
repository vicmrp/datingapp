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
        // Create Account
        public Sql(string storedProcedureToRun)
        {
            RunStoredProcedure = new RelayCommand((storedProcedureToRun) =>
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedureToRun, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Table Users
                        cmd.Parameters.AddWithValue("@MyUsername", insertedObj.MyUsername);
                        cmd.Parameters.AddWithValue("@MyPassword", insertedObj.MyPassword);
                        cmd.Parameters.AddWithValue("@Active", insertedObj.Active);
                        // Table PersonInfo
                        cmd.Parameters.AddWithValue("@MyFirstName", insertedObj.PersonInfo.MyFirstName);
                        cmd.Parameters.AddWithValue("@MyLastName", insertedObj.PersonInfo.MyLastName);
                        cmd.Parameters.AddWithValue("@MyAge", insertedObj.PersonInfo.MyAge);
                        cmd.Parameters.AddWithValue("@MyHeight", insertedObj.PersonInfo.MyHeight);
                        cmd.Parameters.AddWithValue("@MyWeight", insertedObj.PersonInfo.MyWeight);
                        cmd.Parameters.AddWithValue("@MyGender", insertedObj.PersonInfo.MyGender);
                        // TABLE Addresses
                        cmd.Parameters.AddWithValue("@MyCity", insertedObj.Address.MyCity);
                        cmd.Parameters.AddWithValue("@MyZipCode", insertedObj.Address.MyZipCode);
                        // TABLE AttractionTable
                        cmd.Parameters.AddWithValue("@ILikeGender", insertedObj.AttractionTable.ILikeGender);
                        cmd.Parameters.AddWithValue("@MinAge", insertedObj.AttractionTable.MinAge);
                        cmd.Parameters.AddWithValue("@MaxAge", insertedObj.AttractionTable.MaxAge);
                        cmd.Parameters.AddWithValue("@MinHeight", insertedObj.AttractionTable.MinHeight);
                        cmd.Parameters.AddWithValue("@MaxHeight", insertedObj.AttractionTable.MaxHeight);
                        cmd.Parameters.AddWithValue("@MinWeight", insertedObj.AttractionTable.MinWeight);
                        cmd.Parameters.AddWithValue("@MaxWeight", insertedObj.AttractionTable.MaxWeight);
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public ICommand RunStoredProcedure { get; set; } // sp_CreateAccount sp_DisableAccount
        public ICommand RunInsecureSQL { get; set; }

        // 1) Create, Data der skal creates i en tabel (det hedder insert på sql'sk)
        public void CreateAccount(Users insertedObj)
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
            command = new SqlCommand("SELECT * FROM Users", connection);
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

            connection.Close();
            connection.Dispose();
        }

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
