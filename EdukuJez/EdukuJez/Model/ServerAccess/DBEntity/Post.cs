using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Post : EntityBase
    {
        public  virtual User User { set; get; }
        public Message Message { set; get; }
        public bool IsUserSender { get; set; }

    }
}