using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EdukuJez.Repositories
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public ICollection<GroupUser> Groups { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<ClassUsers> Clasess { get; set; }

        public bool IsNameValid(string name)
        {
            Regex reg = new Regex("^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2,19}$");
            return reg.IsMatch(name);
        }

        public bool IsSurnameValid(string surname)
        {
            Regex reg = new Regex(@"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2,19}(-[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2,19})?$");
            return reg.IsMatch(surname);
        }

        public bool IsLoginValid(string login, int loginLength)
        {
            Regex reg = new Regex(@"^[a-zA-Z]\w{2,29}$");
            return reg.IsMatch(login);
        }

        public bool IsPasswordValid(string password)
        {
            Regex reg = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%&?]).{8,50}$");
            return reg.IsMatch(password);
        }
    }
}