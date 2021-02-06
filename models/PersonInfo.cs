using System;

namespace datingapp {
    public class PersonInfo
    {
        public int PersonInfoID { get; set; }
        public int UsersID { get; set; }
        public string MyFirstName { get; set; }
        public string MyLastName { get; set; }
        public int MyAge { get; set; }
        public int MyHeight { get; set; }
        public int MyWeight { get; set; }
        private string myGender;
        public string MyGender
        {
            get { return myGender; }
            set 
            {
                if (value == "Male" || value == "Female") 
                {
                    myGender = value;
                } else 
                {
                    throw new Exception("myGender fejl");
                }                
            }
        }
    }
}