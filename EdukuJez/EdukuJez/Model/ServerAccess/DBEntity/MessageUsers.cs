using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class MessageUsers :EntityBase
    {
        public Message Message { get; set; }
        public User User { get; set; }
    }
}