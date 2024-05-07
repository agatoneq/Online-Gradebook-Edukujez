using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdukuJez.Repositories
{
    public class User : EntityBase
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserSurname { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public bool Deactivated { get; set; } = false;


        public ICollection<GroupUser> Groups { get; set; } = new List<GroupUser>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<Grade> SubmittedGrades { get; set; } = new List<Grade>();
        public ICollection<Remark> Remarks { get; set; } = new List<Remark>();
        public ICollection<Remark> SubmittedRemarks { get; set; } = new List<Remark>();
        public ICollection<ClassC> Teaches { get; set; } = new List<ClassC>();
        public ICollection<ClassUsers> Clasess { get; set; } = new List<ClassUsers>();
        public ICollection<MessageUsers> MessagesUsers { get; set; } = new List<MessageUsers>();
        public ICollection<Group> Educates { get; set; } = new List<Group>();
        public ICollection<Message> Sends { get; set; } = new List<Message>();
        public ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();
        public ICollection<UserParent> Students { get; set; } = new List<UserParent>();
        public ICollection<UserParent> Parents { get; set; } = new List<UserParent>();
        public ICollection<Frequency> Frequency { get; set; } = new List<Frequency>();
        public ICollection<Substitution> Substitutions { get; set; } = new List<Substitution>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();


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