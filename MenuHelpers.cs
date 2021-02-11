using System;
using System.Collections.Generic;
using System.Linq;

namespace datingapp {
    public static class MenuHelpers {
        public static Users CurrentUser { get; set; }
        // Metode
        public static void CreateAccount()
        {
            // Table Users
            Users newUser = new Users();
            Console.WriteLine("Udfyld Username.");
            newUser.MyUsername = Console.ReadLine();
            Console.WriteLine("Udfyld Password.");
            newUser.MyPassword = Console.ReadLine();
            newUser.Active = "True";

            // PersonInfo
            newUser.PersonInfo = new PersonInfo();
            PersonInfo PersonInfo = newUser.PersonInfo;
            Console.WriteLine("Indtast Fornavn");
            PersonInfo.MyFirstName = Console.ReadLine();
            Console.WriteLine("Indtast Efternavn");
            PersonInfo.MyLastName = Console.ReadLine();
            Console.WriteLine("Indtast din alder");
            PersonInfo.MyAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indast din højde");
            PersonInfo.MyHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast din vægt");
            PersonInfo.MyWeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast dit køn - Male eller Female");
            PersonInfo.MyGender = Console.ReadLine();

            // Table Addresses
            newUser.Address = new Addresses();
            Addresses Address = newUser.Address;
            Console.WriteLine("Indtast by");
            Address.MyCity = Console.ReadLine(); 
            Console.WriteLine("Indtast postnummer");
            Address.MyZipCode = Console.ReadLine();

            // Table AttractionTable
            newUser.AttractionTable = new AttractionTable();
            AttractionTable AttractionTable = newUser.AttractionTable;
            Console.WriteLine("Indtast fortrukne køn");
            AttractionTable.ILikeGender = Console.ReadLine();
            Console.WriteLine("Minimuns alder");
            AttractionTable.MinAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maximums alder");
            AttractionTable.MaxAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Min højde");
            AttractionTable.MinHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max højde");
            AttractionTable.MaxHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Min vægt");
            AttractionTable.MinWeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max vægt");
            AttractionTable.MaxWeight = Convert.ToInt32(Console.ReadLine());


            Sql.CreateAccount (newUser);
        }
        public static void PrintCurrentUser()
        {
            Console.WriteLine($"{CurrentUser.MyUsername}, {CurrentUser.MyPassword}, {CurrentUser.PersonInfo.MyFirstName}");
        }
        public static void Login()
        {
            Console.WriteLine("Udfyld Username.");
            var myUsername = Console.ReadLine();
            Console.WriteLine("Udfyld Password.");
            string myPassword = Console.ReadLine();

            // kald login metoden
            bool result = Sql.ValidateCredentials(myUsername, myPassword);

            // hvis sandt hent user objekt
            if (result)
            {
                CurrentUser = Sql.GetUserObject(myUsername);
            }
        }
        
        // Henter alle dem som du er tiltrukket af.
        public static void LikeList()
        {
            // Print userID
            System.Console.WriteLine($"Like liste. CurrentUserID={CurrentUser.UsersID}");
            // Hent liste med dem du er tiltrukket af, udefra CurrentUser.UsersID
            int count = 1;
            List<PersonInfo> listPersonInfo = Sql.GetAllPotientialLikes(CurrentUser.UsersID);
            listPersonInfo =  listPersonInfo.OrderBy(o=>o.MyFirstName).ToList();
            foreach (PersonInfo personInfo in listPersonInfo)
            {
                System.Console.WriteLine($"{count} - {personInfo.MyFirstName}, {personInfo.MyLastName}");
                count++;
            }
            // Echo list ud til brugeren. Hvor der er indikeret om bruger allerede har liket dem.
            

            // // Man skal kunne vælge få listen sorteret efter efternavn
            // List<Kunde> listsKunde3 = Kunde.DanKundeListe();
            // List<Kunde> SortedList = listsKunde3.OrderBy(o=>o.Navn).ToList();
            // Console.WriteLine("sorteret liste med kunder: ");
            // foreach (var item in SortedList)
            // {
            //     //System.Console.WriteLine(item.ToString());
            //     Console.WriteLine($"Navn: {item.Navn}, Telefon: {item.Telefon}, Email: {item.Email}, Kundetype: {item.KundeType}");
            // }

            // Vent på om brugeren 
        }
        // public static void DisableAccount(string accountName)
        // {
        //     Sql.Equals.DisableAccount()
        // }
    }  
}