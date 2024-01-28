using EdukuJez.Model.ServerAccess.Repositories;
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
    public partial class ChildForParent : System.Web.UI.Page
    {
        private UsersRepository userRepo = new UsersRepository();
        private GroupUsersRepository GURepo = new GroupUsersRepository();
        private UserParentsRepository UPRepo = new UserParentsRepository();

        private int ParentId, ChildId; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");
            if (!IsPostBack)
            {
                LoadData();
            }
        }



        protected void MargeChildToParent(object sender, EventArgs e)
        {
            var ParentId = int.Parse(DropDownListParent.SelectedValue);
            var ChildId = int.Parse(DropDownListChild.SelectedValue);
            var query = new UserParent();
            userRepo.Table.FirstOrDefault(x => x.Id == ParentId).Parents.Add(query);
            userRepo.Table.FirstOrDefault(x => x.Id == ChildId).Students.Add(query);

            userRepo.Update();
        }


        protected void DestroyChildToParent(object sender, EventArgs e)
        {
            var ParentId = int.Parse(DropDownListParent.SelectedValue);
            var ChildId = int.Parse(DropDownListChild.SelectedValue);
       
           var del = UPRepo.Table.FirstOrDefault(x => x.ParentId == ParentId && x.StudentId==ChildId);


            UPRepo.Delete(del);

        }

        void LoadData()
        {
            var ParentList = GURepo.Table.Include(g => g.Group).Include(g => g.User).Where(x => x.Group.Name == UserSession.PARENT_GROUP).Select(x => x.User);

            DropDownListParent.Items.Clear();
            DropDownListChild.Items.Clear();

            foreach (User users in ParentList)
            {
                ListItem item = new ListItem(users.UserName+ users.UserSurname, users.Id.ToString());

                DropDownListParent.Items.Add(item);

            }

            var ChildList = GURepo.Table.Include(g => g.Group).Include(g => g.User).Where(x => x.Group.Name == UserSession.STUDENT_GROUP).Select(x => x.User);
            foreach (User users in ChildList)
            {
                ListItem item = new ListItem(users.UserName + users.UserSurname, users.Id.ToString());

                DropDownListChild.Items.Add(item);

            }
        }




    }


}