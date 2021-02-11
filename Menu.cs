using System;

namespace datingapp
{
    static class Menu
    {
        public static bool StartMenu()
        {
            // Console.Clear();
            Console.WriteLine("StartMenu");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Create Account");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
 
            switch (Console.ReadLine())
            {
                case "1":
                    while (MenuHelpers.CurrentUser == null)
                    {
                        MenuHelpers.Login();
                        if (MenuHelpers.CurrentUser == null)
                        {
                            Console.WriteLine("Tast 'exit' for at afbryde login eller tryk enter for at prøve igen.");
                            if (Console.ReadLine()=="exit")
                            {
                                break;
                            }
                        }
                    }
                    while(MenuHelpers.CurrentUser != null) MainMenu();
                    return true;
                case "2":
                    MenuHelpers.CreateAccount();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("MainMenu");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Like list");
            Console.WriteLine("2) Matches");
            Console.WriteLine("3) Settings");
            Console.WriteLine("4) Sign Out");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    // lav liste med matches
                     // Indiker at du har liket, og at du ikke kan gøre det igen.
                    LikeListMenu();
                    // System.Console.WriteLine("Du er i MainMenu");
                    // Console.ReadLine();
                    return true;
                case "2":
                    // Få liste med dem som du matcher med, det vil sige at dem du har liked 
                    // og som har liked dig.
                    MatchMenu();
                    return true;
                case "3":
                    // Delete user
                    // change your profile
                    SettingsMenu();
                    return true;
                case "4":
                    // slet MenuHelpers.CurrentUser så den bliver erlig null
                    MenuHelpers.CurrentUser = null;
                    return true;
                default:
                    return true;
            }
        }
        public static bool LikeListMenu()
        {
            string userInput = "";
            while (userInput != "exit")
            {
                Console.Clear();
                Console.WriteLine("LikeList");
                Console.WriteLine("Type exit to exit");
                Console.WriteLine("Choose who you like:");

                // skaber liste
                MenuHelpers.RefreshLikeList(userInput);
                // lytter til input
                userInput = Console.ReadLine();
            }         
            return true;
        }
        public static bool MatchMenu()
        {
            string userInput = "";
            while (userInput != "exit")
            {
                Console.Clear();
                Console.WriteLine("MatchMenu");
                Console.WriteLine("Type exit to exit");
                Console.WriteLine("Choose who your message partner:");

                // skaber liste
                MenuHelpers.RefreshMatchList(userInput);
                // lytter til input
                userInput = Console.ReadLine();
            }         
            return true;
        }
        public static bool SettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("SettingsMenu");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Delete User");
            Console.WriteLine("2) Change your info");
            Console.WriteLine("3) Change what you like");
            Console.WriteLine("4) Go back");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    return true;
                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}