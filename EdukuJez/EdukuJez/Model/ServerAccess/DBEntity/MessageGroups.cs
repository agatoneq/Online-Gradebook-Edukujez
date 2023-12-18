using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class MessageGroups : EntityBase
    {
        public Message Message { get; set; }
        public User User { get; set; }
    }
}