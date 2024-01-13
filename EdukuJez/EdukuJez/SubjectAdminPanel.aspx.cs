using EdukuJez.Model.Main;
using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class SubjectAdminPanel : Page
    {
        protected void Page_load(object sender, EventArgs e)
        {
            //sprawdzanie czy uzytkownik ma uprawnienia admina - jeszcze nie działa
            //if (UserSession.GetSession().user.Groups.Any(x => x.Group.Name == "Administratorzy"))
            {
                if (!IsPostBack)
                {
                    var repoS = new SubjectsRepository();
                    foreach (var s in repoS.Table)
                    {
                        ListBoxAllSubjects.Items.Add(s.SubjectName);

                    }
                    ButtonAdd.Visible = true;
                    ButtonEdit.Visible = true;
                    ButtonDelete.Visible = true;
                }
            }
            //else
           {
                LabelInfo.Text = "Brak dostępu do zawartości strony";
                LabelInfo.Visible = true;
           }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SubjectAddAdminPanel.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (ListBoxAllSubjects.SelectedItem == null)
            {
                LabelInfo.Text = "Należy wybrać przedmiot";
                LabelInfo.Visible = true;
            }
            else
            {
                var subject = new SubjectsRepository();
                Session["Subject"] = subject.Table.FirstOrDefault(s => s.SubjectName == ListBoxAllSubjects.SelectedItem.Text);
                Response.Redirect("SubjectAddAdminPanel.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxAllSubjects.SelectedItem == null)
            {
                LabelInfo.Text = "Należy wybrać przedmiot";
                LabelInfo.Visible = true;
            }
            else
            {
                var repoS = new SubjectsRepository();
                //nazwa przedmiotu musi być unikatowa
                repoS.Delete(repoS.Table.FirstOrDefault(x => x.SubjectName == ListBoxAllSubjects.SelectedItem.Text));
                ListBoxAllSubjects.Items.Remove(ListBoxAllSubjects.SelectedItem);
            }
        }
    }
}