using System;

namespace datingapp
{
    static class Menu
    {
        public static bool StartMenu()
        {
            Console.Clear();
            Console.WriteLine("StartMenu");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Create Account");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
 
            switch (Console.ReadLine())
            {
                case "1":
                    //LoginFomula();
                    return true;
                case "2":

                    // konverter data
                    // int result = Int32.Parse(input);
                    // int age = Int32.Parse(age_str);
                    // int height = Int32.Parse(height_str);

                    CreateAccount acc1 = new CreateAccount(
                        "vicmrp3",
                        "password",
                        "True",
                        "Victor",
                        "Reipur",
                        age,
                        189,
                        94,
                        "Male",
                        "Lyngby",
                        "2800",
                        "Female",
                        22,
                        26,
                        160,
                        189,
                        50,
                        80
                    );
                    acc1.MyInsert();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        // private static bool CreateAccountMenu()
        // {
        //     Console.Clear();
        //     Console.WriteLine("CreateAccountMenu");
        //     Console.WriteLine("Choose an option:");
        //     Console.WriteLine("1) Create ACC by importing file");
        //     Console.WriteLine("2) Create ACC Manually");
        //     Console.WriteLine("3) Exit");
        //     Console.Write("\r\nSelect an option: "); 
        //     switch (Console.ReadLine())
        //     {
        //         case "1":
        //             // Specificer filen
        //             Functions.CreateAccountAutomatically();
        //             return true;
        //         case "2":
        //             return true;
        //         case "3":
        //             return false;
        //         default:
        //             return true;
        //     }
        // }

        // private static void LoginFomula()
        // {
        //     Console.WriteLine("Login Fomula");
        //     Console.ReadLine();
        // }
        // private static void CreateAccount()
        // {
        //     Console.WriteLine("Creating Account");
        //     string[] lines = System.IO.File.ReadAllLines(@"C:\Temp\datingprofil.txt");
        //     // if(Sql.SqlConnectionOK()) Console.WriteLine("SQL is okay");
        //     // Sql.InsertIntoDB(
        //     // @"
        //     //     EXECUTE CreateAccount 
        //     //         -- TABLE Users
        //     //         @Username = 'alex9123'
        //     //         ,@UPassword = '1234'
        //     //         ,@Active = 'True'
        //     //         -- TABLE PersonInfo
        //     //         ,@FirstName = 'Alex'
        //     //         ,@LastName = 'Petersen'
        //     //         ,@Age = 31
        //     //         ,@Height = 192
        //     //         ,@PWeight = 120
        //     //         ,@MyGender = 'Male'
        //     //         -- TABLE Addresses
        //     //         ,@City = 'Gilleleje'
        //     //         ,@ZipCode = '2800'
        //     //         -- TABLE AttractionTable
        //     //         ,@ILikeGender = 'Female'
        //     //         ,@MinAge = 20
        //     //         ,@MaxAge = 35
        //     //         ,@MinHeight = 150
        //     //         ,@MaxHeight = 200
        //     //         ,@MinWeight = 50
        //     //         ,@MaxWeight = 100
        //     // ");
        //     Console.ReadLine();
        // }
    }
}