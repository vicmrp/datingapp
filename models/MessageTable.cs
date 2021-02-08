using System;

namespace datingapp
{
    public class MessageTable
    {
        public int MessageTableID {get;set;}
        public int SenderUsersID {get;set;}
        public int RecipientUsersID {get;set;}
        public string MyMessage {get;set;}
    }
}