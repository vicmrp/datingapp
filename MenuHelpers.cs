using System;
using System.Collections.Generic;
using System.Linq;

namespace datingapp
{
    public static class MenuHelpers
    {
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


            Sql.CreateAccount(newUser);
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
        public static void RefreshLikeList(string userInput)
        {
            // Hent liste med dem du er tiltrukket af, udefra CurrentUser.UsersID
            int count = 1;
            List<PersonInfo> listPersonInfo = Sql.GetAllPotientialLikes(CurrentUser.UsersID);
            listPersonInfo = listPersonInfo.OrderBy(o => o.MyFirstName).ToList();
            int.TryParse(userInput, out int myChoice);
            if (myChoice >= 1 && myChoice <= listPersonInfo.Count())
            {
                if (!Sql.CheckIfAlreadyLiked(CurrentUser.UsersID, listPersonInfo[myChoice - 1].UsersID))
                {
                    Sql.SetWhoILike(CurrentUser.UsersID, listPersonInfo[myChoice - 1].UsersID);
                }
            }
            List<ILikeTable> listILikeTable = Sql.GetWhoILike(CurrentUser.UsersID);
            foreach (PersonInfo personInfo in listPersonInfo)
            {
                // NOTATION 1
                // // hvis personInfo's usersid er ens med WhoILikeUsersID så er det true
                // bool doesExist = false;
                // foreach (ILikeTable like in listILikeTable)
                // {
                //     if (like.WhoILikeUsersID==personInfo.UsersID)
                //     {
                //         doesExist = true;
                //         break;
                //     }
                // }

                // NOTATION 2
                if (listILikeTable.Any(x => x.WhoILikeUsersID == personInfo.UsersID))
                {
                    System.Console.WriteLine($"{count} - {personInfo.MyFirstName}, {personInfo.MyLastName} [liked allerade]");
                }
                else
                {
                    System.Console.WriteLine($"{count} - {personInfo.MyFirstName}, {personInfo.MyLastName}");
                }
                count++;
            }
            // Echo list ud til brugeren. Hvor der er indikeret om bruger allerede har liket dem.

            // Vent på om brugeren 
        }
        public static void RefreshMatchList(string userInput)
        {
            int count = 1;
            // Henter en liste af objekter af typen PersonInfo
            List<PersonInfo> listMatches = Sql.GetMatches(CurrentUser.UsersID);
            listMatches = listMatches.OrderBy(o => o.MyFirstName).ToList();


            int.TryParse(userInput, out int myChoice);
            if (myChoice >= 1 && myChoice <= listMatches.Count())
            {
                Chat(listMatches[myChoice - 1]);
            }
            else
            {
                foreach (PersonInfo match in listMatches)
                {
                    System.Console.WriteLine($"{count++} - {match.MyFirstName}, {match.MyLastName}");
                }
            }

            // Først skal listen genreres. Man skal hente data fra PersonInfo tabellen.
            // Baseret ens usersID, som skal optræde 

            // Jeg vil have en liste med alle dem som jeg matcher med.
            // Det vil sige alle dem som jeg selv har liked, og som har liket mig.
        }
        public static void Chat(PersonInfo personToMessage)
        {
            string userInput = "";
            while (userInput != "@exit")
            {
                Console.Clear();
                Console.WriteLine("Chatroom");
                Console.WriteLine("Type @exit and press enter to exit");
                Console.WriteLine($"Chatting with {personToMessage.MyFirstName} {personToMessage.MyLastName}:");
                List<PersonInfo> listUsersInRoom = new List<PersonInfo>()
                {
                    CurrentUser.PersonInfo,
                    personToMessage
                };
                // get chat
                List<MessageTable> Messages = Sql.GetAllMessages(CurrentUser.UsersID, personToMessage.UsersID);
                foreach (MessageTable message in Messages)
                {
                    Console.WriteLine($"{listUsersInRoom.FirstOrDefault(e => e.UsersID == message.SenderUsersID).MyFirstName}: {message.MyMessage}");
                }

                userInput = Console.ReadLine();
                MessageTable newMessage = new MessageTable()
                {
                    SenderUsersID = CurrentUser.UsersID,
                    RecipientUsersID = personToMessage.UsersID,
                    MyMessage = userInput
                };

                if (userInput != "@exit") Sql.SetMessage(newMessage);

            }
        }
    }
}