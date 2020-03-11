using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W20_Surname1WebAPI.Models
{
    public class MessageModel
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _messagetext;
        public string Message
        {
            get { return _messagetext; }
            set { _messagetext = value; }
        }
    }
}