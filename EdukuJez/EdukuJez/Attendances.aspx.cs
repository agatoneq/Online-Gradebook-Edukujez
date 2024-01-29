using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class Attendances : System.Web.UI.Page
    {
        AttendancesRepository attendanceRepo = new AttendancesRepository();
        UsersRepository usersRepo = new UsersRepository(); // Załóż, że masz repozytorium użytkowników, możesz dostosować nazwę
        User currentuser = UserSession.GetSession()?.user;
        public SubjViewRepository View = new SubjViewRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAttendanceData();
            }
        }

        private void LoadAttendanceData()
        {
            UserSession userSession = UserSession.GetSession();

            // Pobierz użytkownika razem z przypisanymi przedmiotami
            // Get attendance data for the logged-in user
            var userAttendance = attendanceRepo.Table
                .Where(a => a.Student.Id == userSession.UserId)
                .Include(w => w.Class)
                .ThenInclude(w => w.Subject)
                .Include(w => w.Class)
                .ThenInclude(w => w.Warden)
                .ToList();

            PopulateAttendanceTable(userAttendance);

            // Dodaj przedmioty użytkownika do listy rozwijanej
            var c = View.GetSubjects(currentuser.Id);
            if (c.Count() != 0)
            {
                foreach (var i in c)
                {
                    SubjectsDropDown.Items.Add(i.SubjectName);
                }
            }
            else
            {
                SubjectsDropDown.Items.Add("Brak przedmiotów do wyświetlenia");
            }

            
        }

        protected void SubjectsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Zdarzenie wywoływane po zmianie wybranego przedmiotu w DropDownList
            LoadAttendanceData(); // Załaduj dane obecności dla wybranego przedmiotu
        }

        private void PopulateAttendanceTable(ICollection<Attendance> userAttendance)
        {
            var attendanceData = userAttendance.Select(a => new
            {
                SubjectName = a.Class?.Subject?.SubjectName,
                Date = a.Date,
                TeacherName = a.Class?.Warden?.UserName,
                TeacherSurname = a.Class?.Warden?.UserSurname,
                Presence = a.Presence
            });

            attendanceRepeater.DataSource = attendanceData.ToList();
            attendanceRepeater.DataBind();
        }
    }
}
