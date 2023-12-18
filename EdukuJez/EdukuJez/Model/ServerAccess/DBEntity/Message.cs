using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Message : EntityBase
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }
        public bool IsGroupMsg { get; set; }
        public ICollection<MessageUsers> Recipients { get; set; }
        public ICollection<MessageGroups> GroupRecipients { get; set; }
    }
}