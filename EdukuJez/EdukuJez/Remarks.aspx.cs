using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class Remarks : System.Web.UI.Page
    {
        public GradesRepository repoGrades = new GradesRepository();
        public SubjectsRepository repoSubj = new SubjectsRepository();
        public SubjViewRepository View = new SubjViewRepository();
        public GroupsRepository repoGroups = new GroupsRepository();
        String permission;
        //User currentuser = UserSession.GetSession().user;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void AddNewRemarkButton_Click(object sender, EventArgs e)
        {
        }

        protected void StudentsGroupsListSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}