using System;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public partial class AttendanceAdminPanel : System.Web.UI.Page
    {
        private readonly AttendancesRepository attendancesRepo = new AttendancesRepository();
        private readonly UsersRepository usersRepo = new UsersRepository();
        private readonly GroupsRepository groupsRepo = new GroupsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // LoadGroups();
               // LoadStudentsForGroup();
            }
        }
        /*
        protected void GroupsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentsForGroup();
        }

        protected void AddAttendanceButton_Click(object sender, EventArgs e)
        {
            int selectedGroupId = Convert.ToInt32(GroupsDropDown.SelectedValue);
            int selectedStudentId = Convert.ToInt32(StudentsDropDown.SelectedValue);
            DateTime currentDate = DateTime.Now;
            string presence = PresenceDropDown.SelectedValue;

            User selectedStudent = usersRepo.GetByLogin(selectedStudentId.ToString());

            if (selectedStudent != null)
            {
                attendancesRepo.AddNewEntry(new Attendance
                {
                    Student = selectedStudent,
                    Date = currentDate,
                    Group = groupsRepo.GetById(selectedGroupId),
                    Presence = presence
                });

                RefreshListBox();
                LoadStudentsForGroup();
            }
            else
            {
                // Obsługa przypadku, gdy nie można odnaleźć użytkownika o podanym identyfikatorze
                // Możesz dodać odpowiednie komunikaty lub logikę obsługi błędów.
            }
        }

        private void LoadGroups()
        {
            GroupsDropDown.DataSource = groupsRepo.Table.ToList();
            GroupsDropDown.DataTextField = "GroupName";
            GroupsDropDown.DataValueField = "Id";
            GroupsDropDown.DataBind();
        }

        private void LoadStudentsForGroup()
        {
            int selectedGroupId = Convert.ToInt32(GroupsDropDown.SelectedValue);

            // Pobierz uczniów dla wybranej grupy
            var studentsForGroup = groupsRepo.GetById(selectedGroupId)?.Users.ToList();

            if (studentsForGroup != null && studentsForGroup.Any())
            {
                StudentsDropDown.DataSource = studentsForGroup;
                StudentsDropDown.DataTextField = "UserName";
                StudentsDropDown.DataValueField = "Id";
                StudentsDropDown.DataBind();
            }
        }

        private void RefreshListBox()
        {
            // Pobierz dane z obecności i przypisz do ListBox
            var attendanceEntries = attendancesRepo.Table.OrderBy(a => a.Date).ToList();

            // Przygotuj listę niestandardowych ciągów do wyświetlenia w ListBoxie
            var listBoxItems = attendanceEntries.Select(a => $"{a.Date.ToString("dd-MM-yyyy")} : {a.Student.UserName} - {a.Presence}").ToList();

            ListBoxAllAttendances.DataSource = listBoxItems;
            ListBoxAllAttendances.DataBind();
        }*/
    }
}
