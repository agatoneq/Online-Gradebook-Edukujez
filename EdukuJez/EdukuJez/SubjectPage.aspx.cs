using EdukuJez.Repositories;
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
        private SubjectsRepository repoS;
        protected void Page_Load(object sender, EventArgs e)
        {
            repoS = new SubjectsRepository();
            if (!IsPostBack)
            {
                if (UserSession.GetSession().UserGroups.Any(x => x.Name == "Uczniowie"))
                {
                    foreach (var s in repoS.Table)
                    {
                        foreach (var g in UserSession.GetSession().UserGroups)
                            if (g.Id == s.StudentGroupId)
                            {
                                ListBoxSubjects.Items.Add(s.SubjectName);
                            }
                    }
                }
                else if(UserSession.GetSession().UserGroups.Any(x => x.Name == "Nauczyciele"))
                {
                    LabelLink.Visible = true;
                    TextBoxLink.Visible = true;
                    ButtonAddMaterials.Visible = true;
                    foreach (var s in repoS.Table)
                    {
                        foreach (var g in UserSession.GetSession().UserGroups)
                            if (g.Id == s.TeacherGroupId)
                            {
                                ListBoxSubjects.Items.Add(s.SubjectName);
                            }
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
                ListBoxSubjects.Visible = false;
                ButtonSubjectShow.Visible = false;
                ButtonBack.Visible = true;
                LabelSubjectName.Visible = true;
                LabelSubjectDesc.Visible = true;
                LabelMaterials.Visible = true;
                LabelLink.Visible = false;
                TextBoxLink.Visible = false;
                ButtonAddMaterials.Visible = false;
                //miejsce na wyświetlanie materiałów
                LabelSubjectName.Text = ListBoxSubjects.SelectedItem.Text;
                LabelSubjectDesc.Text = repoS.Table.FirstOrDefault(s => s.SubjectName == ListBoxSubjects.SelectedItem.Text).SubjectDesc;
                LabelInfo.Visible = false;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            ListBoxSubjects.Visible = true;
            ButtonSubjectShow.Visible = true;
            ButtonBack.Visible = false;
            LabelSubjectName.Visible = false;
            LabelSubjectDesc.Visible = false;
            LabelMaterials.Visible = false;
            LabelLink.Visible = true;
            TextBoxLink.Visible = true;
            ButtonAddMaterials.Visible = true;
        }

        protected void ButtonAddMaterials_Click(object sender, EventArgs e)
        {
            //miejsce na dodanie materiałów do bazy
        }
    }
}