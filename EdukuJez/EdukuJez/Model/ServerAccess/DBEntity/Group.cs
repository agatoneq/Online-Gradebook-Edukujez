﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Group : EntityBase
    {
        public string GroupName { get; set; }
        public int ParentGroup { get; set; }
    }
}