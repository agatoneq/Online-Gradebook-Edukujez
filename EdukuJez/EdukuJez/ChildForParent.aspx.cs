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
        private GroupsRepository groupRepo = new GroupsRepository();

        private int ParentId, ChildId; 

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        protected void SelectedName(object sender, EventArgs e)
        {
            string controlName="";
            DropDownList dropdownList = sender as DropDownList;
            if (dropdownList != null)
            {
                controlName = dropdownList.ID; 
            }

            var CurrentId = int.Parse(dropdownList.SelectedValue);
            User user = userRepo.Table.FirstOrDefault(x => x.Id == CurrentId);

            if (controlName== "DropDownListParent")
            {
                LabelParent.Text = user.UserName +" "+user.UserSurname;
                ParentId = user.Id; 
            }
            else
            {
                LabelChild.Text = user.UserName + " " + user.UserSurname;
                ChildId = user.Id;
            }
        }

        protected void MargeChildToParent(object sender, EventArgs e)
        {
           // var query = new 
        }


        protected void DestroyChildToParent(object sender, EventArgs e)
        {

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