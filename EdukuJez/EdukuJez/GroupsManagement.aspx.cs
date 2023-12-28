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
        readonly GroupsRepository groupRepo = new GroupsRepository();
        readonly GroupsRepository userGroupRepo = new GroupsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshTables();
            
        }

        protected void AddNewGroupButton_Click(object sender, EventArgs e)
        {
            var ng = new Group();
            ng.Name = NewGroupTextBox.Text;
            var parentName = MainGroupList.SelectedValue;
            ng.ParentGroup = groupRepo.Table.First(x => x.Name==parentName );
            groupRepo.Insert(ng);
        }

        protected void DeleteGroupButton_Click(object sender, EventArgs e)
        {
        }

        void RefreshTables()
        {
            List<Group> groups = groupRepo.Table.ToList();
            myRepeater.DataSource = groups;
            myRepeater.DataBind();


            MainGroupList.DataSource = groups.Where(x => x.ParentGroup == null).Select(x => x.Name);
            MainGroupList.DataBind();
        }
    }
}
