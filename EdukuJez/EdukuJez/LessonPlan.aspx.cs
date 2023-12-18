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
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                
                var lessonPlan = Lessons.Table.Include(u => u.Group).Include(w => w.Subject).ToList();
                PopulateLessonTable(lessonPlan);
            }
        }
        private void PopulateLessonTable(ICollection<ClassC> lessonPlan)
        {
            var l = Lessons.Table.Select(a => new
            {
                Day = a.Day,
                SubjectName = a.Subject.SubjectName,
                Name = a.Name,
                Surname = a.Surname,
                Class = a.Class,
                Hour = a.Hour
            });
            myRepeater.DataSource = l.ToList();
            myRepeater.DataBind();
        }
    }
}