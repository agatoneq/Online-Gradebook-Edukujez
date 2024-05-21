using EdukuJez.Model.Main;
using EdukuJez.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class SubjectAddAdminPanel : Page
    {
        private Subject subject;
        readonly GroupsRepository repoG = new GroupsRepository();
        readonly GroupUsersRepository repoGU= new GroupUsersRepository();
        readonly UsersRepository repoU = new UsersRepository();
        readonly SubjectsRepository repoS = new SubjectsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Subject"] != null) subject = (Subject)Session["Subject"];
            if (!IsPostBack)
            {
                List<Group> groups = repoG.Table.ToList();
                DropDownListStudents.DataSource = groups.Where(x => x.ParentGroup != null).Where(x => x.ParentGroup.Name == UserSession.STUDENT_GROUP).Select(x => x.Name);
                DropDownListStudents.DataBind();
                DropDownListTeachers.DataSource = groups.Where(x => x.ParentGroup != null).Where(x => x.ParentGroup.Name == UserSession.TEACHER_GROUP).Select(x => x.Name);
                DropDownListTeachers.DataBind();

                if (Session["Subject"] != null)
                {
                    TextBoxSubjectName.Text = subject.SubjectName;
                    TextBoxSubjectDescription.Text = subject.SubjectDesc;
                    DropDownListStudents.Items.FindByText(repoG.Table.FirstOrDefault(x => x.Id == subject.StudentGroupId).Name).Selected = true;
                    DropDownListTeachers.Items.FindByText(repoG.Table.FirstOrDefault(x => x.Id == subject.TeacherGroupId).Name).Selected = true;
                    ButtonSubjectAccept.Text = "Edytuj przedmiot";
                }
            }
        }
        protected void ButtonSubjectAccept_Click(object sender, EventArgs e)
        {
            if (Session["Subject"] != null)
            {

                if (!TextBoxSubjectName.Text.Equals("") && !TextBoxSubjectDescription.Text.Equals("") && DropDownListStudents.SelectedItem != null && DropDownListTeachers.SelectedItem != null)
                {
                    if (!TextBoxSubjectName.Text.Equals(subject.SubjectName) && repoS.Table.Any(x => x.SubjectName == TextBoxSubjectName.Text))
                    {
                        LabelInfo.Text = "Nazwa przedmiotu musi być unikatowa";
                        LabelInfo.Visible = true;
                    }
                    else
                    {
                        Subject sub = repoS.Table.FirstOrDefault(x => x.SubjectName == subject.SubjectName);
                        subject = new Subject();
                        //update przedmiotu
                        sub.SubjectName = TextBoxSubjectName.Text;
                        sub.SubjectDesc = TextBoxSubjectDescription.Text;
                        sub.StudentGroupId = repoG.Table.FirstOrDefault(x => x.Name == DropDownListStudents.Text).Id;
                        sub.TeacherGroupId = repoG.Table.FirstOrDefault(x => x.Name == DropDownListTeachers.Text).Id;
                        repoS.UpdateRow(sub);
                        LabelInfo.Text = "Edytowano przedmiot";
                        LabelInfo.Visible = true;
                        Session.Contents.Remove("Subject");
                        Session.Abandon();
                    }
                }
                else
                {
                    LabelInfo.Text = "Żadne pole nie może być puste";
                    LabelInfo.Visible = true;
                }
            }
            else {
                if (!TextBoxSubjectName.Text.Equals("") && !TextBoxSubjectDescription.Text.Equals("") && DropDownListStudents.SelectedItem != null && DropDownListTeachers.SelectedItem != null)
                {
                    if (repoS.Table.Any(x => x.SubjectName == TextBoxSubjectName.Text))
                    {
                        LabelInfo.Text = "Nazwa przedmiotu musi być unikatowa";
                        LabelInfo.Visible = true;
                    }
                    else
                    {
                        Subject sub = new Subject();
                        sub.SubjectName = TextBoxSubjectName.Text;
                        sub.SubjectDesc = TextBoxSubjectDescription.Text;
                        sub.TeacherGroupId = repoG.Table.FirstOrDefault(x => x.Name == DropDownListTeachers.Text).Id;
                        sub.StudentGroupId = repoG.Table.FirstOrDefault(x => x.Name == DropDownListStudents.Text).Id;
                        repoS.Insert(sub);
                        LabelInfo.Text = "Dodano przedmiot";
                        LabelInfo.Visible = true;
                    }
                }
                else
                {
                    LabelInfo.Text = "Żadne pole nie może być puste";
                    LabelInfo.Visible = true;
                }
            }
        }

        protected void ButtonSubjectCancel_Click(object sender, EventArgs e)
        {
            if (Session["Subject"] != null)
            {
                Session.Contents.Remove("Subject");
                Session.Abandon();
            }
            Response.Redirect("SubjectAdminPanel.aspx");
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }
    }
}