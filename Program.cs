using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace datingapp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool showMenu = true;
                while (showMenu)
                {
                    // Menuen Startmenu starter
                    showMenu = Menu.StartMenu();
                }
            }
            catch (System.Exception)
            {                
                throw;
            }
        }
    }
}
