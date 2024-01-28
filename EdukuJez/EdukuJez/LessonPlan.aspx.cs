using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class LessonPlan : System.Web.UI.Page
    {
        ScheduleRepository Lessons = new ScheduleRepository();
        GroupsRepository GroupsRepo = new GroupsRepository(); // Dodane repozytorium do obsługi grup

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGroups(); // Metoda do załadowania grup do DropDownList przy pierwszym załadowaniu strony
            }

            LoadLessonPlan(); // Metoda do załadowania planu lekcji
        }

        private void LoadGroups()
        {
            List<Group> groups = GroupsRepo.Table.ToList();
            GroupDropDown.DataSource = groups;
            GroupDropDown.DataTextField = "Name";
            GroupDropDown.DataValueField = "Id";
            GroupDropDown.DataBind();
        }

        private void LoadLessonPlan()
        {
            int selectedGroupId;
            if (int.TryParse(GroupDropDown.SelectedValue, out selectedGroupId))
            {
                var lessonPlan = Lessons.Table
                    .Where(a => a.Group.Id == selectedGroupId)
                    .Include(a => a.Warden)
                    .Include(u => u.Group)
                    .Include(w => w.Subject)
                    .ToList();

                PopulateLessonTable(lessonPlan);
            }
        }

        protected void GroupSelectionChanged(object sender, EventArgs e)
        {
            // Zdarzenie wywoływane po zmianie wybranej grupy w DropDownList
            LoadLessonPlan(); // Załaduj plan lekcji dla wybranej grupy
        }

        private void PopulateLessonTable(ICollection<ClassC> lessonPlan)
        {
            var l = lessonPlan.Select(a => new
            {
                Day = a.Day,
                SubjectName = a.Subject.SubjectName,
                Name = a.Warden.UserName,
                Surname = a.Warden.UserSurname,
                Class = a.Class,
                Hour = a.Hour
            });

            myRepeater.DataSource = l.ToList();
            myRepeater.DataBind();
        }
    }
}
