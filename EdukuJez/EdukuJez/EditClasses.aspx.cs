
using EdukuJez.Migrations;
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


        List<string> Class = new List<string> { };
        List<string> Subject = new List<string> { };
        List<string> Group = new List<string> { };
        List<string> Name = new List<string> { };
        List<string> Surname = new List<string> { };
        List<string> Teacher = new List<string> { };


        private ScheduleRepository scheduleRepo = new ScheduleRepository();
        private GroupsRepository groupRepo = new GroupsRepository();
        private SubjectsRepository subjRepo = new SubjectsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            var Lessons = scheduleRepo;
            var lessonPlan = Lessons.Table.Include(u => u.Group).Include(u => u.Subject).ToList();

            LoadToList(lessonPlan);
            CreateDynamicControls(lessonPlan);

        }

        public EditClasses()
        {
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;

            int Class = Convert.ToInt32(DropDownListTeacher.SelectedValue);
            int grupaId = Convert.ToInt32(DropDownListGroup.SelectedValue);
            int przedmiotId = Convert.ToInt32(DropDownListSubject.SelectedValue);

            var query = new ClassC() { Hour = godzina, Day = dzien, Class = Class };


            scheduleRepo.Insert(query);


        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;
            int Class = Convert.ToInt32(DropDownListTeacher.SelectedValue);
            int grupaId = Convert.ToInt32(DropDownListGroup.SelectedValue);
            int przedmiotId = Convert.ToInt32(DropDownListSubject.SelectedValue);




            var query = new ClassC() { Id = 1, Hour = godzina, Day = dzien, Class = Class };

            var dbc = new ScheduleRepository();

            dbc.Delete(query);


        }


        private void CreateDynamicControls(ICollection<ClassC> lessonPlan)
        {
            string[] dropdownNames = { "Dzien", "Godzina", "Nauczyciel", "Grupa", "Przedmiot" };

            // Zakładając, że masz listy wartości dla każdego DropDownList
            List<string> days = new List<string> { "Poniedzialek", "Wtorek", "Sroda", "Czwartek", "Piatek" };
            List<string> hours = new List<string> { "8:00 – 8:45", "8:50 – 9:35", "9:45 – 10:30", "10:35 – 11:20", "11:40 – 12:25", "12:45 – 13:30", "13:35 – 14:20", "14:25 – 15:10" };
            List<string> teachers = Teacher;
            List<string> groups = Group;
            List<string> subjects = Subject;
            List<string> classes = Class;

            List<List<string>> values = new List<List<string>> { days, hours, teachers, groups, subjects, classes };

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

            foreach (ClassC lesson in lessonPlan)
            {
                TableRow row = new TableRow();

                // Tworzenie nowych komórek TableCell
                TableCell cellClass = new TableCell { Text = lesson.Class.ToString() };
                TableCell cellHour = new TableCell { Text = lesson.Hour.ToString() };
                TableCell cellDay = new TableCell { Text = lesson.Day.ToString() };

                // Dodawanie komórek do wiersza
                row.Cells.Add(cellDay);
                row.Cells.Add(cellClass);
                row.Cells.Add(cellHour);

                // Dodawanie wiersza do tabeli MainTable
                MainTable.Rows.Add(row);
            }
        }


        void LoadToList(ICollection<ClassC> lessonPlan)
        { 
            string a;
            foreach (ClassC lesson in lessonPlan)
            {
                Class.Add(lesson.Class.ToString());
                //Subject.Add(lesson.Subject.Id.ToString());
                Group.Add(lesson.Group.Id.ToString());
                Name.Add(lesson.Name.ToString());
                Surname.Add(lesson.Surname.ToString());
                a = lesson.Name.ToString() + " " + (lesson.Surname.ToString());
                Teacher.Add(a);
            }

        }

    }
}

