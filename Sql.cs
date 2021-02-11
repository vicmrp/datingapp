using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace datingapp
{
    public class Sql
    {
        private static string ConnectionString = @"Data Source=BYG-A101-VICRE\MSSQLSERVER01;Initial Catalog=datingapp;Integrated Security=True";
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

            if (result == 1) return true;
            return false;
        }
        public static List<PersonInfo> GetAllPotientialLikes(int usersID)
        {
            List<PersonInfo> listPersonInfo = new List<PersonInfo>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($@"       
                SELECT 
                P.PersonInfoID AS PersonInfoID,
                P.UsersID AS UsersID,
                P.MyFirstName AS MyFirstName,
                P.MyLastName AS MyLastName,
                p.MyAge AS MyAge,
                p.MyHeight AS MyHeight,
                p.MyWeight AS MyWeight,
                p.MyGender AS MyGender
                --, P.UsersID as PINusersId, P.MyGender, P.MyAge
                FROM AttractionTable A, PersonInfo P 
                WHERE 
                (P.MyWeight>=A.MinWeight AND P.MyWeight<=A.MaxWeight) AND
                (P.MyAge>=A.MinAge AND P.MyAge<=A.MaxAge) AND
                (P.MyHeight>=A.MinHeight AND P.MyHeight<=A.MaxHeight) AND
                (P.MyGender=A.ILikeGender) AND
                (A.UsersID=@usersID AND P.UsersID <> A.UsersID)
            ", connection);
            command.Parameters.AddWithValue("@usersID", usersID);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PersonInfo personInfo = new PersonInfo();
                // Tilføj værdierne fra db til objektet.
                personInfo.PersonInfoID = reader.GetInt32(0);
                personInfo.UsersID = reader.GetInt32(1);
                personInfo.MyFirstName = reader.GetString(2);
                personInfo.MyLastName = reader.GetString(3);
                personInfo.MyAge = reader.GetInt32(4);
                personInfo.MyHeight = reader.GetInt32(5);
                personInfo.MyWeight = reader.GetInt32(6);
                personInfo.MyGender = reader.GetString(7);
                // tilføj person info til din liste
                listPersonInfo.Add(personInfo);
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return listPersonInfo;
        }
        public static List<ILikeTable> GetWhoILike(int usersID)
        {
            List<ILikeTable> listILikeTable = new List<ILikeTable>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($@"       
                SELECT * FROM ILikeTable
                WHERE WhoIAmUsersID=@usersID
            ", connection);
            command.Parameters.AddWithValue("@usersID", usersID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ILikeTable iLikeTable = new ILikeTable();
                // Tilføj værdierne fra db til objektet.
                iLikeTable.ILikeTableID = reader.GetInt32(0);
                iLikeTable.WhoIAmUsersID = reader.GetInt32(1);
                iLikeTable.WhoILikeUsersID = reader.GetInt32(2);
                // tilføj person info til din liste
                listILikeTable.Add(iLikeTable);
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return listILikeTable;
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

        public static bool SetWhoILike(int whoIAmUsersID, int whoILikeUsersID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO ILikeTable (WhoIAmUsersID,WhoILikeUsersID) VALUES (@whoIAmUsersID, @whoILikeUsersID)", connection);
            command.Parameters.AddWithValue("@whoIAmUsersID", whoIAmUsersID);
            command.Parameters.AddWithValue("@whoILikeUsersID", whoILikeUsersID);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            connection.Dispose();

            if (result == 1) return true;
            return false;
        }
        public static bool CheckIfAlreadyLiked(int whoIAmUsersID, int whoILikeUsersID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM ILikeTable WHERE WhoIAmUsersID=@whoIAmUsersID AND WhoILikeUsersID=@whoILikeUsersID", connection);
            command.Parameters.AddWithValue("@whoIAmUsersID", whoIAmUsersID);
            command.Parameters.AddWithValue("@whoILikeUsersID", whoILikeUsersID);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            connection.Dispose();

            if (result == 1) return true;
            return false;
        }

        public static List<PersonInfo> GetMatches(int whoIAmUsersID)
        {
            List<PersonInfo> matches = new List<PersonInfo>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(
            $@"
            SELECT ILikeTable2.WhoILikeUsersID AS WhoILikeUsersID,
            (
                SELECT COUNT(WhoILikeUsersID)
                FROM
                ILikeTable AS ILikeTable1 
                WHERE
                ILikeTable1.WhoIAmUsersID = ILikeTable2.WhoILikeUsersID AND ILikeTable1.WhoILikeUsersID = ILikeTable2.WhoIAmUsersID
            ) AS
            [Match] FROM 
            ILikeTable AS ILikeTable2 WHERE WhoIAmUsersID = @whoIAmUsersID
            ", connection);
            command.Parameters.AddWithValue("@whoIAmUsersID", whoIAmUsersID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Check if user i like likes me back.
                if (reader.GetInt32(1) == 1)
                {
                    // Add user to list by id.
                    matches.Add(GetPersonInfoById(reader.GetInt32(0)));
                }
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return matches;
        }
        public static PersonInfo GetPersonInfoById(int userID)
        {
            PersonInfo personInfo = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(
            $@"
                SELECT * FROM PersonInfo WHERE UsersID = @userID
            ",
            connection);
            command.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                personInfo = new PersonInfo()
                {
                    PersonInfoID = reader.GetInt32(0),
                    UsersID = reader.GetInt32(1),
                    MyFirstName = reader.GetString(2),
                    MyLastName = reader.GetString(3),
                    MyAge = reader.GetInt32(4),
                    MyHeight = reader.GetInt32(5),
                    MyWeight = reader.GetInt32(6),
                    MyGender = reader.GetString(7)
                };
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return personInfo;
        }
    }
}
