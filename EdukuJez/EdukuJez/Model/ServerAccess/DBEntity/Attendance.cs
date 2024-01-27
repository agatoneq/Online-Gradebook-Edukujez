using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Attendance : EntityBase
    {
        public User Student { get; set; }
        public DateTime Date { get; set; }
        public ClassC Class { get; set; }
        public string Presence { get; set; } // obecny,nieobecny, spóźniony, usprawiedliwiony, zwolniony (do ustalenia)
    }
}