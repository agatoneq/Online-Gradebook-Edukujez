using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public partial class GroupManger : System.Web.UI.Page
    {
        readonly GroupsRepository repo = new GroupsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshTables();
            
        }

        protected void NewGroupButton_Click(object sender, EventArgs e)
        {
            var ng = new Group();
            ng.Name = NewGroupTextBox.Text;
            ng.ParentGroup = PGroupDropdown.SelectedValue;
        }

        void RefreshTables()
        {
            myRepeater.DataSource = repo.GetAll();
            myRepeater.DataBind();
            PGroupDropdown.DataSource = repo.GetAll().Select(x => x.Name);
            PGroupDropdown.DataBind();
        }
    }
}
