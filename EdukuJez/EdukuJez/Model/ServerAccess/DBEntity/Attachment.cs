using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Attachment : EntityBase
    {
        public Subject Subject { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Text { get; set; }
        public byte[] Content { get; set; }
}
}