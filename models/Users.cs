using System;

namespace datingapp
{
    public class Users
    {
        public int UsersID { get; set; }    
        private string myUsername;
        public string MyUsername
        {
            get { return myUsername; }
            set 
            {
                if(value.Length>15)
                {
                    throw new Exception("Username is to long.");
                } else
                {   
                    myUsername = ((string)value.ToLower());
                }
            }
        }
        public string MyPassword { get; set; }
        private string active;
        public string Active
        {
            get { return active; }
            set
            {
                if (value == "True" || value == "False") 
                {
                    active = value;
                } else 
                {
                    throw new Exception("Active fejl");
                } 
            }
        }
        public PersonInfo PersonInfo { get; set; }
        public Addresses Address { get; set; }
        public AttractionTable AttractionTable { get; set; }
    }
}