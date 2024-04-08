using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Frequency : EntityBase
    {
        User Student { get; set; }
        ClassC Class { get; set; }
        string Value { get; set; }
    }
}