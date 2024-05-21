﻿using EdukuJez.Model.Main;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class SubjectPage : System.Web.UI.Page
    {
        const String SUBJECT_CONTENT_SITE = "SubjectContentPage.aspx";
        const String MAIN_SITE = "Main.aspx";
        private SubjectsRepository repoS = new SubjectsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserSession.CheckPermission(UserSession.STUDENT_GROUP) == true)
                {
                    foreach (var s in repoS.Table)
                    {
                        foreach (var g in UserSession.GetSession().UserGroups)
                            if (g.Id == s.StudentGroupId)
                            {
                                ListBoxSubjects.Items.Add(s.SubjectName);
                                break;
                            }
                    }
                }
                else if(UserSession.CheckPermission(UserSession.TEACHER_GROUP) == true)
                {
                    foreach (var s in repoS.Table)
                    {
                        foreach (var g in UserSession.GetSession().UserGroups)
                            if (g.Id == s.TeacherGroupId)
                            {
                                ListBoxSubjects.Items.Add(s.SubjectName);
                                break;
                            }
                    }
                }
                else if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true)
                {
                    foreach (var s in repoS.Table)
                    {

                        ListBoxSubjects.Items.Add(s.SubjectName);

                    }
                }
            }
        }

        protected void ButtonSubjectShow_Click(object sender, EventArgs e)
        {
            if (ListBoxSubjects.SelectedItem == null)
            {
                LabelInfo.Text = "Należy wybrać przedmiot";
                LabelInfo.Visible = true;
            }
            else
            {
                SubjectManager.Subject = repoS.Table.Include(x => x.Activites)
                    .Include(x => x.Attachments).Include(x => x.Classes).Include(x => x.StudentGroup).Include(x => x.TeacherGroup)
                    .FirstOrDefault(x => x.SubjectName == ListBoxSubjects.SelectedItem.Text);
                Response.Redirect(SUBJECT_CONTENT_SITE);
            }
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(MAIN_SITE);
        }
    }
}