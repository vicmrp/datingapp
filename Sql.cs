using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace datingapp
{
    static class Sql
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
        public static void insert(Users insertedObj) 
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CreateAccount", con))
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
