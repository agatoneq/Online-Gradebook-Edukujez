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
    public partial class Attendance : System.Web.UI.Page
    {
        AttendancesRepository AttendanceRepo = new AttendancesRepository();
        GroupsRepository GroupsRepo = new GroupsRepository();
        private UsersRepository userRepo = new UsersRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList.Items.Clear();
                var groupList = GroupsRepo.Table.ToList();
                var userList = userRepo.Table.ToList();

                foreach (User users in userList)
                {
                    if (users.UserName == UserSession.GetSession().UserName)
                        DropDownList.Items.Add(users.UserName + " " + users.UserSurname);

                }
                foreach (Group group in groupList)
                {

                    DropDownList.Items.Add(group.Name);

                }
            }
        }
    }
}
