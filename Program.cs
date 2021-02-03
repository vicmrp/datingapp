using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

// Sqlcs -> clsSqlcs

namespace datingapp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu.StartMenu();
            }
        }
    }
}
