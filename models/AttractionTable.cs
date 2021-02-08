using System;
namespace datingapp
{
    public class AttractionTable
    {
        public int AttractionTableID {get;set;}
        public int UsersID {get;set;}
        private string iLikeGender;
        public string ILikeGender
        {
            get { return iLikeGender; }
            set
            {
                if (value == "Male" || value == "Female") 
                {
                    iLikeGender = value;
                } else 
                {
                    throw new Exception("iLikeGender fejl");
                }    
            }
        }
        public int MinAge {get;set;}
        public int MaxAge {get;set;}
        public int MinHeight {get;set;}
        public int MaxHeight { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
    }
}