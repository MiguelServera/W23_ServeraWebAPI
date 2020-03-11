using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W20_Surname1WebAPI.Models
{
    public class LastMessageModel
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _lastmessage;
        public string LastMessage
        {
            get { return _lastmessage; }
            set { _lastmessage = value; }
        }
    }
}