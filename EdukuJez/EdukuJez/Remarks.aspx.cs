using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EdukuJez
{
    public partial class Remarks : System.Web.UI.Page
    {
        readonly RemarkRepository remarkRepo = new RemarkRepository();

        readonly GroupsRepository groupsRepo = new GroupsRepository();
        readonly UsersRepository userRepo = new UsersRepository();
        readonly GroupUsersRepository groupUserRepo = new GroupUsersRepository();
        User currentuser;
        String permission;
        List<Group> groups = new List<Group>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = UserSession.GetSession().user;
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true || UserSession.CheckPermission(UserSession.TEACHER_GROUP) == true)
                permission = "nauczyciel";
            else
                permission = "uczen";

            switch (permission)
            {
                case "uczen":
                    StudentsPanel.Visible = true;
                    break;
                case "nauczyciel":
                    TeachersPanel.Visible = true;
                    break;
            }

            if (!IsPostBack)
            {
                //nauczyciel
                MainInfoLabel.Text = "Wybierz grupę i ucznia, któremu chcesz wstawić uwagę:";
                groups = groupsRepo.Table.ToList();
                StudentsGroupsList.DataSource = groups.Where(x => x.ParentGroup != null).Select(x => x.Name);
                StudentsGroupsList.DataBind();

                UploadStudentsList(groups);

                if (permission == "uczen")
                {
                    //uczeń
                    List<Remark> remarks = remarkRepo.Table.Include(s => s.Student).Include(su => su.Submitter).ToList();
                    var remarksList = remarks.Where(x => x.Student.Id == currentuser.Id);
                    myRepeater.DataSource = remarksList;
                    myRepeater.DataBind();


                    if (remarksList.Any())
                    {
                        MainInfoLabel.Text = "Lista Twoich uwag:";
                        myRepeater.DataSource = remarksList;
                        myRepeater.DataBind();
                    }
                    else
                    {
                        MainInfoLabel.Text = "Nie masz żadnych uwag.";
                    }
                }

            }
        }
        
        protected void UploadStudentsList(List<Group> groups)
        {
            var groupsId = groups.Where(x => x.Name == StudentsGroupsList.Text).Select(x => x.Id);
            var groupId = groupsId.FirstOrDefault();

            List<User> users = userRepo.Table.ToList();
            List<GroupUser> groupUserList = groupUserRepo.Table.Include(u => u.User).Include(g => g.Group).ToList();

            List<int> studentsId = groupUserList.Where(x => x.Group != null && x.Group.Id == groupId && x.User != null).Select(x => x.User.Id).ToList();


            StudentsList.DataSource = users.Where(x => studentsId.Contains(x.Id)).Select(user => $"{user.UserName} {user.UserSurname}");

            StudentsList.DataBind();
        }

        protected void AddNewRemarkButton_Click(object sender, EventArgs e)
        {
            var Session = UserSession.GetSession();
            Remark newRemark = new Remark();
            if (NewRemarkTextBox.Text != null)
            {
                newRemark.Contents = NewRemarkTextBox.Text;

                userRepo.Table.FirstOrDefault(x => x.Id == currentuser.Id).SubmittedRemarks.Add(newRemark);
                userRepo.Table.FirstOrDefault(x => (x.UserName + " " + x.UserSurname) == StudentsList.SelectedValue).Remarks.Add(newRemark);
                userRepo.Update();

                MainInfoLabel.Text = "Dodałeś uwagę uczniowi " + StudentsList.SelectedValue + ". <br> Kliknij poniższy przycisk, aby kontynuować.";
                TeachersPanel.Visible = false;
                RestartButton.Visible = true;
            }
        }

        protected void StudentsGroupsListSelectedIndexChanged(object sender, EventArgs e)
        {
            groups = groupsRepo.Table.ToList();
            UploadStudentsList(groups);
        }
        protected void NewRemarkBoxChanged(object sender, EventArgs e)
        {
            if(NewRemarkTextBox.Text != null)
            {
                AddNewRemarkButton.Enabled = true;
            }
        }

        protected void ConfirmRestartClick(object sender, EventArgs e)
        {
            Response.Redirect("Remarks.aspx");
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}