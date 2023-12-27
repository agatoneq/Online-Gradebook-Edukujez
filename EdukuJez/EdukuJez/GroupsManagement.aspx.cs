using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public partial class GroupsManagement : System.Web.UI.Page
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
            var parentName = MainGroupList.SelectedValue;
            ng.ParentGroup = repo.Table.First(x => x.Name==parentName );
            repo.Insert(ng);
        }

        void RefreshTables()
        {
            List<Group> groups = repo.Table.ToList();
            myRepeater.DataSource = groups;
            myRepeater.DataBind();
            MainGroupList.DataSource = groups.Select(x => x.Name);
            MainGroupList.DataBind();
        }
    }
}
