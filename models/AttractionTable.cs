using System;
namespace datingapp
{
    public class AttractionTable
    {
        public int AttractionTableID {get;set;}
        public int UsersID {get;set;}
        public string ILikeGender {get;set;}
        public int MinAge {get;set;}
        public int MaxAge {get;set;}
        public int MinHeight {get;set;}
        public int MaxHeight { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
    }
}