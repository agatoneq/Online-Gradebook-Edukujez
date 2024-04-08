using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Submission: EntityBase
    {

        public const string IMAGE = "Obraz";
        public const string PAGE = "Strona";
        public const string DOCUMENT = "Dokument";
        public static List<string> Type = new List<string> { IMAGE, PAGE, DOCUMENT };//kategorie materiałów
        public Activity Activity { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Text { get; set; }
        public byte[] Content { get; set; }
    }
}