// using System;

// namespace datingapp
// {
//     public static class CreateAccount
//     {
//             public static CreateAcc() {
// // TABLE Users
// System.Console.WriteLine("Type Username:");
// string username = Console.ReadLine();
// System.Console.WriteLine("Type Password:");
// string password = Console.ReadLine();
// // TABLE PersonInfo
// System.Console.WriteLine("Type first name:");
// string firstName = Console.ReadLine();
// System.Console.WriteLine("Type last name:");
// string lastName = Console.ReadLine();
// System.Console.WriteLine("Type Age:");
// this.MyAge = int.Parse(Console.ReadLine());
// //             Int.Parse eller TryParse eller Convert.ToInt32()
// //              int.TryParse(input, out int temp)

// System.Console.WriteLine("Type Height:");
// this.MyHeight = Int32.Parse(Console.ReadLine());
// // string height = Console.ReadLine();
// System.Console.WriteLine("Type Weight:");
// string str_weight = Console.ReadLine();
// this.MyWeight = int.Parse(str_weight);


// System.Console.WriteLine("Type Gender [Male or Female]:");
// string myGender = Console.ReadLine();
// // TABLE Addresses
// System.Console.WriteLine("Type city:");
// string city = Console.ReadLine();
// System.Console.WriteLine("Type zipcode:");
// string zipcode = Console.ReadLine();
// // TABLE AttractionTable
// System.Console.WriteLine("Type the gender you like [Male or Female]:");
// string iLikeGender = Console.ReadLine();
// System.Console.WriteLine("Type minimum age:");
// string minAge = Console.ReadLine();
// System.Console.WriteLine("Type maximum age:");
// string maxAge = Console.ReadLine();
// System.Console.WriteLine("Type minimum height:");
// string minHeight = Console.ReadLine();
// System.Console.WriteLine("Type maximum height:");
// string maxHeight = Console.ReadLine();
// System.Console.WriteLine("Type minimum wieght:");
// string minWeight = Console.ReadLine();
// System.Console.WriteLine("Type maximum weight:");
// string maxWeight = Console.ReadLine();
//             }

//         }

//         // public void MySanitizer()
//         // {
//         //     // lav 
//         //    this.MaxWeight
//         // }
        
//         // Username

//         // lav en metode som tager imod inputs.

//         // 

        // Indsæt i tabel. saniterede data
        // public void MyInsert()
        // {
        //     Sql.InsertIntoDB(
        //     $@"
        //         EXECUTE CreateAccount 
        //             -- TABLE Users
        //             @Username = '{Username}'
        //             ,@UPassword = '{UPassword}'
        //             ,@Active = '{Active}'
        //             -- TABLE PersonInfo
        //             ,@FirstName = '{FirstName}'
        //             ,@LastName = '{LastName}'
        //             ,@Age = {MyAge}
        //             ,@Height = {MyHeight}
        //             ,@PWeight = {MyWeight}
        //             ,@MyGender = {MyGender}
        //             -- TABLE Addresses
        //             ,@City = {City}
        //             ,@ZipCode = {ZipCode}
        //             -- TABLE AttractionTable
        //             ,@ILikeGender = {ILikeGender}
        //             ,@MinAge = {MinAge}
        //             ,@MaxAge = {MaxAge}
        //             ,@MinHeight = {MinHeight}
        //             ,@MaxHeight = {MaxHeight}
        //             ,@MinWeight = {MinWeight}
        //             ,@MaxWeight = {MaxWeight}
        //     ");
        // }
//     }
// }