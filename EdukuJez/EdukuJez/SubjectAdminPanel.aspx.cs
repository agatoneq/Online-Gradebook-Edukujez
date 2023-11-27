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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var repoG = new GroupsRepository();
                var repoU = new UsersRepository();
                for (int i = 0; i < repoG.GetAll().Count(); ++i)
                {
                    DropDownList.Items.Add(repoG.GetAll()[i].Name);

                }
                for (int i = 0; i < repoU.GetAll().Count(); ++i)
                {
                    DropDownList.Items.Add(repoU.GetAll()[i].UserName + " " + repoU.GetAll()[i].UserSurname + ":" + repoU.GetAll()[i].UserGroup);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(DropDownList.SelectedItem.ToString());
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Remove(ListBox1.SelectedItem);
        }

        protected void ButtonSubjectAccept_Click(object sender, EventArgs e)
        {
            if (TextBoxSubjectName.Text!="") {
                var repoS = new SubjectsRepository();
                Subject subject = new Subject();
                subject.SubjectName = TextBoxSubjectName.Text;
                //subject.SubjectNameDescription = TextBoxSubjectDescription;
                repoS.Create(subject);
                //dodanie grupom uprawnień do przedmiotu
            }
        }
    }
}