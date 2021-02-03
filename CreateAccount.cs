using System;

namespace datingapp
{
    public class CreateAccount
    {
        // TABLE Users
        public string Username { get; set; }
        public string UPassword { get; set; }
        public string Active { get; set; }
        // TABLE PersonInfo
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MyAge { get; set; }
        public int MyHeight { get; set; }
        public int MyWeight { get; set; }
        public string MyGender { get; set; }
        // TABLE Addresses
        public string City { get; set; }
        public string ZipCode { get; set; }
        // TABLE AttractionTable
        public string ILikeGender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MinHeight { get; set; }
        public int MaxHeight { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }

        // Constructer
        public CreateAccount()
        {
            
        }

        // Fungere som main metode i denne klasse
        public void Create()
        {
            // Tager imod inputs
            GetInputs();
            // Sanitere
            // MySanitizer();
            // Indsætter i tabllen.

        }
        public void GetInputs()
        {
            // TABLE Users
            System.Console.WriteLine("Type Username:");
            string username = Console.ReadLine();
            System.Console.WriteLine("Type Password:");
            string password = Console.ReadLine();
            // TABLE PersonInfo
            System.Console.WriteLine("Type first name:");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Type last name:");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Type Age:");
            this.MyAge = int.Parse(Console.ReadLine());
//             Int.Parse eller TryParse eller Convert.ToInt32()
//              int.TryParse(input, out int temp)

            System.Console.WriteLine("Type Height:");
            this.MyHeight = Int32.Parse(Console.ReadLine());
            // string height = Console.ReadLine();
            System.Console.WriteLine("Type Weight:");
            string str_weight = Console.ReadLine();
            this.MyWeight = int.Parse(str_weight);


            System.Console.WriteLine("Type Gender [Male or Female]:");
            string myGender = Console.ReadLine();
            // TABLE Addresses
            System.Console.WriteLine("Type city:");
            string city = Console.ReadLine();
            System.Console.WriteLine("Type zipcode:");
            string zipcode = Console.ReadLine();
            // TABLE AttractionTable
            System.Console.WriteLine("Type the gender you like [Male or Female]:");
            string iLikeGender = Console.ReadLine();
            System.Console.WriteLine("Type minimum age:");
            string minAge = Console.ReadLine();
            System.Console.WriteLine("Type maximum age:");
            string maxAge = Console.ReadLine();
            System.Console.WriteLine("Type minimum height:");
            string minHeight = Console.ReadLine();
            System.Console.WriteLine("Type maximum height:");
            string maxHeight = Console.ReadLine();
            System.Console.WriteLine("Type minimum wieght:");
            string minWeight = Console.ReadLine();
            System.Console.WriteLine("Type maximum weight:");
            string maxWeight = Console.ReadLine();
        }

        public void MySanitizer()
        {
            // lav 
           this.MaxWeight
        }
        
        Username

        // lav en metode som tager imod inputs.

        // 

        // Indsæt i tabel. saniterede data
        public void MyInsert()
        {
            Sql.InsertIntoDB(
            $@"
                EXECUTE CreateAccount 
                    -- TABLE Users
                    @Username = '{Username}'
                    ,@UPassword = '{UPassword}'
                    ,@Active = '{Active}'
                    -- TABLE PersonInfo
                    ,@FirstName = '{FirstName}'
                    ,@LastName = '{LastName}'
                    ,@Age = {MyAge}
                    ,@Height = {MyHeight}
                    ,@PWeight = {MyWeight}
                    ,@MyGender = {MyGender}
                    -- TABLE Addresses
                    ,@City = {City}
                    ,@ZipCode = {ZipCode}
                    -- TABLE AttractionTable
                    ,@ILikeGender = {ILikeGender}
                    ,@MinAge = {MinAge}
                    ,@MaxAge = {MaxAge}
                    ,@MinHeight = {MinHeight}
                    ,@MaxHeight = {MaxHeight}
                    ,@MinWeight = {MinWeight}
                    ,@MaxWeight = {MaxWeight}
            ");
        }
    }
}