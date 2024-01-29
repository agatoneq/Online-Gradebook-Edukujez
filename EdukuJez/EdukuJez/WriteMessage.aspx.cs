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
        private MessageGroupsRepository MGRepo = new MessageGroupsRepository();
        private UsersRepository userRepo = new UsersRepository();
        private GroupsRepository groupRepo = new GroupsRepository();
        private GroupUsersRepository groupUsersRepo = new GroupUsersRepository();
        private 

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
                    DropDownList.Items.Add(users.UserName +" "+ users.UserSurname);

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
            DateTime Time = DateTime.Now;
           

            String[] parts = Name.Split(' ');

            if (CheckSendText(Topic) && CheckSendText(Message))
            {
                if (userRepo.Table.Any(x => x.UserName == parts[0]) && userRepo.Table.Any(x => x.UserSurname == parts[1]))
                {
                    try
                    {
                        var query = new Message() { Topic = Topic, Content = Message, DateTime = Time };

                        userRepo.Table.First(x => x.UserName == User_name).Sends.Add(query);


                        User u = userRepo.Table.First(x => x.UserName == parts[0] && x.UserSurname == parts[1]);
                        var MU = new MessageUsers();
                        query.Recipients = new List<MessageUsers>() { MU };
                        u.MessagesUsers = new List<MessageUsers>() { MU };


                        userRepo.Update();


                        InfoLabel.Text = "Wiadomość wysłana";
                    }
                    catch
                    {
                        InfoLabel.Text = "Wiadomość nie wysłana";
                    }




                }
                else if (groupRepo.Table.Any(x => x.Name == Name))
                {

                    try
                    {


                        var query = new Message() { Topic = Topic, Content = Message, DateTime = Time };
                        userRepo.Table.First(x => x.UserName == User_name).Sends.Add(query);
                        query.IsGroupMsg = true;


                        Group g = groupRepo.Table.First(x => x.Name == Name);
                        var MG = new MessageGroups();
                        query.GroupRecipients = new List<MessageGroups>() { MG };
                        g.Messages = new List<MessageGroups>() { MG };


                        messageRepo.Insert(query);
                        groupRepo.Update();
                        userRepo.Update();

                        InfoLabel.Text = "Wiadomość wysłana";
                    }
                    catch
                    {
                        InfoLabel.Text = "Wiadomość nie wysłana błąd wysyłania";
                    }



                    //   }

                }
                else
                {
                    InfoLabel.Text = "Wiadomość nie wysłana, nie istnieje taka grupa lub użytkownik";
                }
            }
            else InfoLabel.Text = "Wiadomość jest pusta";

        }
        protected void SelectedIndexChanged(object sender, EventArgs e)
        {

            NameBox.Text = DropDownList.SelectedValue;
        }

        private bool CheckSendText(string input)
        {
            return !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
        }

    }
}