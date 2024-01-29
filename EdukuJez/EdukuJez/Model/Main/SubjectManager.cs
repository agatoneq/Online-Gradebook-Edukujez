using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public static class SubjectManager
    {
        public static Subject Subject{get; set; }
        public static bool ActivtyTransferFlag { get; set; } = false;

        public static void ReloadSubject()
        {
            Subject = new SubjectsRepository().Table.Include(x => x.Activites)
                    .Include(x => x.Attachments).Include(x => x.Classes).Include(x => x.StudentGroup).Include(x => x.TeacherGroup)
                    .FirstOrDefault(x => x.Id == Subject.Id);
        }
    }
}
