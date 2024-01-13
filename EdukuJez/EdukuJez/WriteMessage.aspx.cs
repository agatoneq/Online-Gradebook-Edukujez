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
    public partial class WriteMessage : System.Web.UI.Page
    {
        private MessageUsersRepository MURepo = new MessageUsersRepository();
        private MessageRepository messageRepo = new MessageRepository();
        private PostRepository postRepo = new PostRepository();
        private MessageGroupsRepository MGRepo = new MessageGroupsRepository();
        private UsersRepository userRepo = new UsersRepository();
        private GroupsRepository groupRepo = new GroupsRepository();
        private GroupUsersRepository groupUsersRepo = new GroupUsersRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList.Items.Clear();
                var groupList = groupRepo.Table.ToList();
                var userList = userRepo.Table.ToList();

                foreach (User users in userList)
                {
                    if(users.UserName!= UserSession.GetSession().UserName)
                    DropDownList.Items.Add(users.UserName + users.UserSurname);

                }
                foreach (Group group in groupList)
                {

                    DropDownList.Items.Add(group.Name);

                }
            }
        }

        protected void SendMessage(object sender, EventArgs e)
        {
            String Name = NameBox.Text; // z tego będzie id do kogo
            String Topic = TopicBox.Text;
            String Message = MessageBox.Text;
            String User_name = UserSession.GetSession().UserName;

            String[] parts = Name.Split(' ');

            if (userRepo.Table.Any(x => x.UserName == parts[0])&& userRepo.Table.Any(x => x.UserSurname == parts[1]))
            {
                var query = new Message() { Topic = Topic, Content = Message };

                userRepo.Table.First(x => x.UserName == User_name).Sends.Add(query);
                userRepo.Update();
            }
            else if(groupRepo.Table.Any(x => x.Name == Name))
            {
                var userList = groupUsersRepo.Table.Include(x => x.User).Include(g => g.Group).Where(g => g.Group.Name == Name).Select(x =>x.User).ToList();


                var query = new Message() { Topic = Topic, Content = Message };

                foreach (User users in userList)
                {

                        userRepo.Table.First(x => x.UserName == User_name).Sends.Add(query);
                        userRepo.Update();
                    

                }

            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {

            NameBox.Text = DropDownList.SelectedValue;
        }

    }
}