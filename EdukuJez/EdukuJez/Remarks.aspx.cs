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
        private Remark newRemark = new Remark();
        readonly RemarkRepository remarkRepo = new RemarkRepository();
        //public SubjectsRepository repoSubj = new SubjectsRepository();
        //public SubjViewRepository View = new SubjViewRepository();

        readonly GroupsRepository groupsRepo = new GroupsRepository();
        readonly UsersRepository userRepo = new UsersRepository();
        readonly GroupUsersRepository groupUserRepo = new GroupUsersRepository();
        String permission;
        //User currentuser = UserSession.GetSession().user;
        List<Group> groups = new List<Group>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                groups = groupsRepo.Table.ToList();
                StudentsGroupsList.DataSource = groups.Where(x => x.ParentGroup != null).Select(x => x.Name);
                StudentsGroupsList.DataBind();

                UploadStudentsList(groups);

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

            if (NewRemarkTextBox.Text != null)
            {
                newRemark.Contents = NewRemarkTextBox.Text;
                remarkRepo.Insert(newRemark);

                //var teachersId = Session.UserId;
                //var studentsFullName = StudentsList.SelectedValue;
                //newRemark.Submitter = userRepo.Table.First(x => x.Id == teachersId);
                //newRemark.Student = userRepo.Table.First(x => (x.UserName + " " + x.UserSurname) == studentsFullName);

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

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}