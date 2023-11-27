﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class ClassC : EntityBase
    {
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
        public string Hour { get; set; }
        public string Day { get; set; }
        public string Test { get; }
    }
}