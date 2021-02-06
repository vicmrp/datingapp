using System;

namespace datingapp
{
    public class Users
    {
        public int UsersID { get; set; }    
           
        public string MyUsername
        {
            get => _MyUsername;
            set 
            {   
                // Sanitering:
                // Ikke over 15 karaktere langt
                // skal være lowercase
                // skal være en string
                if(value.Length>15)
                {
                    throw new Exception("Username is to long.");
                } else
                {   
                    _MyUsername = ((string)value.ToLower());
                }
            }
        }
        public string MyPassword { get; set; }

        public string Active { get; set; }


        public PersonInfo PersonInfo {get;set;}
        public Addresses Address {get;set;}
        public AttractionTable AttractionTable {get; set;}
        
        private string _MyUsername;
    }
}