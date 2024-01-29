using EdukuJez.Model.ServerAccess.Repositories;
using EdukuJez.Repositories;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EdukuJez
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        private MessageRepository messRepo = new MessageRepository();
        private MessageGroupsRepository MGRepo = new MessageGroupsRepository();    
        private MessageUsersRepository MU = new MessageUsersRepository();
        private UsersRepository user = new UsersRepository();
        private GroupUsersRepository GURepo = new GroupUsersRepository();
        UserSession CurrentUser = UserSession.GetSession();



        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCzytaj_Click(object sender, EventArgs e)
        {
            LoadGetData();
            DropDownList.Visible = true;
            TextBox.Visible = true;
            TopicLabelGet.Visible = true;
            TopicLabelSend.Visible = false;

            LoadTextToRead();
        }

        protected void btnCzytajWys_Click(object sender, EventArgs e)
        {
            LoadSendData();
            DropDownList.Visible = true;   
            TextBox.Visible = true;
            TopicLabelSend.Visible = true;
            TopicLabelGet.Visible = false;

            LoadTextToRead();
        }


        private void LoadGetData()
        {
            DropDownList.Items.Clear();

            var messListGetUser = MU.Table.Include(x => x.User).Include(m => m.Message).Where(x => x.User.Id == CurrentUser.UserId).Select(m =>m.Message);
            foreach (Message message in messListGetUser)
            {
                ListItem item = new ListItem(message.Topic, message.Id.ToString());

                DropDownList.Items.Add(item);

            }
            var userGroupList = GURepo.Table.Include(x => x.User).Include(g => g.Group).Where(g => g.User.Id == CurrentUser.UserId).Select(x => x.Group).ToList();

            foreach (Group group in userGroupList)
            {
             var messListGetGroup = MGRepo.Table.Include(x => x.Group).Include(m => m.Message).Where(x => x.Group.Id == group.Id).Select(m => m.Message);
                foreach(Message message in messListGetGroup)
                {
                    ListItem item = new ListItem(message.Topic, message.Id.ToString());

                    DropDownList.Items.Add(item);
                }
            }


        }


        private void LoadSendData()
        {

            DropDownList.Items.Clear();
            var messListSend = messRepo.Table.Where(x => x.Sender.Id == CurrentUser.UserId);

            foreach (Message message in messListSend)
            {
                ListItem item = new ListItem(message.Topic, message.Id.ToString());

                DropDownList.Items.Add(item);

            }
        }


        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTextToRead();
        }

        void LoadTextToRead()
        {
            if(DropDownList.SelectedValue != "")
            { 
                var CurrentTopic = int.Parse(DropDownList.SelectedValue);


            Message CurrentContent = messRepo.Table.FirstOrDefault(x => x.Id == CurrentTopic);
            TextBox.Text = CurrentContent.Content;
        }
            else TextBox.Text = " Brak Wiadomości"; 
        }
    }
}