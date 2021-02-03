using System;
using System.Data;
using System.Data.SqlClient;

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
        public static void insert(string sql) 
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertIntoDB(string input)
        {
            try
            {
                Sql.insert(input);
            }
            catch (Exception)
            {
                Console.WriteLine($"sql kommandoen lykkedes ikke");
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
