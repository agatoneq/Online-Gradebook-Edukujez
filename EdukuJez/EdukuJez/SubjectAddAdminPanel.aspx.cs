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

namespace EdukuJez
{
    public partial class SubjectAddAdminPanel : Page
    {
        private Subject subject;
        private GroupsRepository repoG = new GroupsRepository();
        private SubjectsRepository repoS = new SubjectsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
                //sprawdzanie czy uzytkownik ma uprawnienia admina - jeszcze nie działa
                //if (UserSession.GetSession().user.Groups.Any(x => x.Group.Name == "Administratorzy"))
                {
                    if(Session["Subject"] != null) subject = (Subject)Session["Subject"];
                if (!IsPostBack)
                    {

                        foreach (var s in repoG.Table)
                        {
                            //znalezienie tylko grup uczniów na razie nie działa
                            //if(s.ParentGroup.Id == repoG.Table.FirstOrDefault(x => x.Name == "Uczniowie").Id)
                            DropDownListStudents.Items.Add(s.Name);

                        }
                        
                        foreach (var t in repoG.Table)
                        {
                            //znalezienie tylko grup nauczycieli na razie nie działa 
                            //if (t.ParentGroup.Id == repoG.Table.FirstOrDefault(x => x.Name == "Nauczyciele").Id)
                            DropDownListTeachers.Items.Add(t.Name);
                        }
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
                //else
                {
                    LabelInfo.Text = "Brak dostępu do zawartości strony";
                    LabelInfo.Visible = true;
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
                    }
                }
                else
                {
                    LabelInfo.Text = "Żadne pole nie może być puste";
                    LabelInfo.Visible = true;
                }
            }
        }
    }
}