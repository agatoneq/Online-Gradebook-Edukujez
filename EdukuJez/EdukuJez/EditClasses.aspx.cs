
using EdukuJez.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.EntityFrameworkCore;
using EdukuJez.Model.ServerAccess.Repositories;
using System.Runtime.CompilerServices;

namespace EdukuJez
{
    public partial class EditClasses : System.Web.UI.Page
    {

        // Deklaracja zmiennych do przechowywania DropDownList jako zmiennych klasy
        private DropDownList DropDownListDay;
        private DropDownList DropDownListHour;
        private DropDownList DropDownListTeacher;
        private DropDownList DropDownListGroup;
        private DropDownList DropDownListSubject;
        private DropDownList DropDownListClass;


        List<string> Class = new List<string> { };
        List<string> Subject = new List<string> { };
        List<string> Group = new List<string> { };
        List<string> Name = new List<string> { };
        List<string> Surname = new List<string> { };
        List<string> Teacher = new List<string> { };

        readonly GroupUsersRepository groupUserRepo = new GroupUsersRepository();
        private ScheduleRepository scheduleRepo = new ScheduleRepository();
        private GroupsRepository groupRepo = new GroupsRepository();
        private SubjectsRepository subjRepo = new SubjectsRepository();
        private UsersRepository userRepo = new UsersRepository();
        private ClassUsersRepository CURepo = new ClassUsersRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false || UserSession.CheckPermission(UserSession.TEACHER_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");
            ReloadData();
        }

        public EditClasses()
        {
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;

            // rozdzielenie imienia i nazwiska na dwa osobne stringi do wysłania do DB
            string Teacher = DropDownListTeacher.SelectedValue;
            string[] parts = Teacher.Split(' ');



            var group = Convert.ToString(DropDownListGroup.SelectedValue);
            var subject = Convert.ToString(DropDownListSubject.SelectedValue);
            int classRoom = Convert.ToInt32(DropDownListClass.SelectedValue);
            
            var c = new ClassC() { Hour = godzina, Day = dzien, Class = classRoom };

            userRepo.Table.First(x => x.UserName == parts[0] && x.UserSurname == parts[1]).Teaches.Add(c);
            groupRepo.Table.First(x => x.Name == group).Classes.Add(c);
            subjRepo.Table.First(x => x.SubjectName == subject).Classes.Add(c);



            User u = userRepo.Table.First(x => x.UserName == parts[0] && x.UserSurname == parts[1]);
            var CU = new ClassUsers();
            c.Users = new List<ClassUsers>() { CU };    
            u.Clasess = new List<ClassUsers>() { CU };


            if (scheduleRepo.Table.Any(x => x.Hour == godzina && x.Day == dzien && x.Warden.UserName == parts[0] && x.Warden.UserSurname == parts[1] && x.Class == classRoom && x.Group.Name == group && x.Subject.SubjectName == subject))
            {

            }
            else
            {
                userRepo.Update();
                groupRepo.Update();
                subjRepo.Update();

            }



            ReloadData();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;

            // rozdzielenie imienia i nazwiska na dwa osobne stringi do wysłania do DB
            string Teacher = DropDownListTeacher.SelectedValue;
            string[] parts = Teacher.Split(' ');

            var group = Convert.ToString(DropDownListGroup.SelectedValue);
            var subject = Convert.ToString(DropDownListSubject.SelectedValue);
            int classRoom = Convert.ToInt32(DropDownListClass.SelectedValue);

          

            ClassC query = scheduleRepo.Table.Include(x=>x.Users)
                .FirstOrDefault(x => x.Hour == godzina && x.Day == dzien && x.Warden.UserName == parts[0] && x.Warden.UserSurname == parts[1] && x.Class == classRoom && x.Group.Name == group && x.Subject.SubjectName==subject);

            scheduleRepo.Delete(query);
            if (query != null)
            {
                var CU = query.Users.ToList();

                foreach (var users in CU)
                {
                    CURepo.Delete(users);
                }
                ReloadData();
            }
            else { }
        }


        private void CreateDynamicControls(ICollection<ClassC> lessonPlan)
        {
            MainTable.Controls.Clear();
            string[] dropdownNames = { "Dzien", "Godzina", "Nauczyciel", "Grupa", "Przedmiot", "Sala" };

            // Zakładając, że masz listy wartości dla każdego DropDownList
            List<string> days = new List<string> { "Poniedzialek", "Wtorek", "Sroda", "Czwartek", "Piatek" };
            List<string> hours = new List<string> { "8:00 – 8:45", "8:50 – 9:35", "9:45 – 10:30", "10:35 – 11:20", "11:40 – 12:25", "12:45 – 13:30", "13:35 – 14:20", "14:25 – 15:10" };
            List<string> teachers = Teacher;
            List<string> groups = Group;
            List<string> subjects = Subject;
            List<string> classRoom = new List<string> { "1", "2", "3", "4", "5", "6" };

            List<List<string>> values = new List<List<string>> { days, hours, teachers, groups, subjects, classRoom };

            //Tworzenie dropdownlist
            for (int i = 0; i < dropdownNames.Length; i++)
            {
                DropDownList dropdown = new DropDownList();
                dropdown.ID = "DropDownList" + i;
                dropdown.CssClass = "form-control";

                // Dodawanie wartości do DropDownList
                foreach (var value in values[i])
                {
                    dropdown.Items.Add(new ListItem(value, value)); // Tutaj 'value' zostanie ustawione jako Value i Text dla ListItem
                }
                // Dodanie utworzonego DropDownList do zmiennej klasy
                switch (i)
                {
                    case 0:
                        DropDownListDay = dropdown;
                        break;
                    case 1:
                        DropDownListHour = dropdown;
                        break;
                    case 2:
                        DropDownListTeacher = dropdown;
                        break;
                    case 3:
                        DropDownListGroup = dropdown;
                        break;
                    case 4:
                        DropDownListSubject = dropdown;
                        break;
                    case 5:
                        DropDownListClass = dropdown;
                        break;
                }

                TableCell cell = new TableCell();
                cell.Controls.Add(dropdown);

                Label label = new Label();
                label.Text = dropdownNames[i] + ": ";
                label.AssociatedControlID = dropdown.ID;

                TableCell labelCell = new TableCell();
                labelCell.Controls.Add(label);

                TableRow row = new TableRow();
                row.Cells.Add(labelCell);
                row.Cells.Add(cell);

                MainTable.Rows.Add(row);
            }

            Button AddButton = new Button();
            AddButton.ID = "AddButton";
            AddButton.Text = "Add";
            AddButton.Click += new EventHandler(AddButton_Click);


            Button DeleteButton = new Button();
            DeleteButton.ID = "DeleteButton";
            DeleteButton.Text = "Delete";
            DeleteButton.Click += new EventHandler(DeleteButton_Click);

            TableCell submitCell = new TableCell();
            submitCell.ColumnSpan = 2;

            submitCell.Controls.Add(AddButton);
            submitCell.Controls.Add(DeleteButton);

            TableRow submitRow = new TableRow();
            submitRow.Cells.Add(submitCell);

            MainTable.Rows.Add(submitRow);

            TableRow rowStart = new TableRow();

            // Tworzenie nowych komórek TableCell
            TableCell StartcellClass = new TableCell { Text = "Sala" };
            TableCell StartcellHour = new TableCell { Text = "Godzina"};
            TableCell StartcellDay = new TableCell { Text = "Dzień"};
            TableCell StartcellTeacherName = new TableCell { Text = "Imie" };
            TableCell StartcellTeacherSurname = new TableCell { Text = "Nazwisko" };
            TableCell StartcellGroup = new TableCell { Text = "Grupa"};
            TableCell StartcellSubject = new TableCell { Text = "Przedmiot"};

            // Dodawanie komórek do wiersza
            rowStart.Cells.Add(StartcellDay);
            rowStart.Cells.Add(StartcellHour);
            rowStart.Cells.Add(StartcellClass);
            rowStart.Cells.Add(StartcellGroup);
            rowStart.Cells.Add(StartcellSubject);
            rowStart.Cells.Add(StartcellTeacherName);
            rowStart.Cells.Add(StartcellTeacherSurname);

            // Dodawanie wiersza do tabeli MainTable
            MainTable.Rows.Add(rowStart);
            //dodawanie wartości do tabeli
            foreach (ClassC lesson in lessonPlan)
            {
                TableRow row = new TableRow();

                // Tworzenie nowych komórek TableCell
                TableCell cellClass = new TableCell { Text = lesson.Class.ToString() };
                TableCell cellHour = new TableCell { Text = lesson.Hour.ToString() };
                TableCell cellDay = new TableCell { Text = lesson.Day.ToString() };
                TableCell cellTeacherName = new TableCell { Text = lesson.Warden.UserName.ToString() };
                TableCell cellTeacherSurname = new TableCell { Text = lesson.Warden.UserSurname.ToString() };
                TableCell cellGroup = new TableCell { Text = lesson.Group.Name.ToString() };
                TableCell cellSubject = new TableCell { Text = lesson.Subject.SubjectName.ToString() };

                // Dodawanie komórek do wiersza
                row.Cells.Add(cellDay);
                row.Cells.Add(cellHour);
                row.Cells.Add(cellClass);
                row.Cells.Add(cellGroup);
                row.Cells.Add(cellSubject);
                row.Cells.Add(cellTeacherName);
                row.Cells.Add(cellTeacherSurname);

                // Dodawanie wiersza do tabeli MainTable
                MainTable.Rows.Add(row);
            }
        }

        //ładowanie listy do wyświetlania 
        void LoadToList(ICollection<ClassC> lessonPlan)
        {
            string a;
            foreach (ClassC lesson in lessonPlan)
            {
                Class.Add(lesson.Class.ToString());
                Subject.Add(lesson.Subject.SubjectName.ToString());

                Name.Add(lesson.Warden.UserName.ToString());
                Surname.Add(lesson.Warden.UserSurname.ToString());

                Group.Add(lesson.Group.Name.ToString());

                a = lesson.Warden.UserName.ToString() + " " + (lesson.Warden.UserSurname.ToString());
                Teacher.Add(a);
            }

        }
        private void ReloadData()
        {

        DropDownListTeacher?.Items.Clear();
            DropDownListGroup?.Items.Clear();    
        DropDownListSubject?.Items.Clear();


            var subList = subjRepo.Table.ToList();
            var groupList = groupRepo.Table.Where(y=>y.Name != UserSession.TEACHER_GROUP && y.ParentGroup.Name != UserSession.TEACHER_GROUP).ToList();
            List<GroupUser> groupUserList = groupUserRepo.Table.Include(u => u.User).Include(g => g.Group).ToList();
            var userList = groupUserList.Where(x => x.Group != null && x.Group.Name == UserSession.TEACHER_GROUP && x.User != null).Select(x => x.User).ToList(); ;
            var lessonPlan = scheduleRepo.Table.Include(u => u.Group).Include(u => u.Warden).Include(u => u.Subject).ToList();

            LoadToChose(groupList, subList, userList, lessonPlan);


            CreateDynamicControls(lessonPlan);

        }
        void LoadToChose(ICollection<Group> groupT, ICollection<Subject> SubjectT, ICollection<User> UserT, ICollection<ClassC> lessonPlan)
        {
            foreach (Group group in groupT)
            {

                    Group.Add(group.Name);
                
            }
            foreach (Subject subject in SubjectT)
            {
                Subject.Add(subject.SubjectName.ToString());
            }
            foreach (User user in UserT)
            {

                    var a = user.UserName.ToString() + " " + user.UserSurname.ToString();
                    Teacher.Add(a);
                
            }
            foreach (ClassC lesson in lessonPlan)
            {
                Class.Add(lesson.Class.ToString());
            }
        }
    }
}

