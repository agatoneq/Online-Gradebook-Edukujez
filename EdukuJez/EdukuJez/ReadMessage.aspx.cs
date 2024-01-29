using EdukuJez.Model.Main;
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
            if(Hidden.Value == "1")
            {
                LoadGetData();
            }
            else if (Hidden.Value == "2")
            {
               LoadSendData();
            }
        }
        protected void btnCzytaj_Click(object sender, EventArgs e)
        {
            LoadGetData();

            Hidden.Value = "1";
        }

        protected void btnCzytajWys_Click(object sender, EventArgs e)
        {
            LoadSendData();


            Hidden.Value = "2";

        }


        private void LoadGetData()
        {
            MainTable.Rows.Clear();

            var messListGetUser = MU.Table.Include(x => x.User).Include(m => m.Message).ThenInclude(x => x.Sender).Where(x => x.User.Id == CurrentUser.UserId).Select(m =>m.Message);
            foreach (Message message in messListGetUser)
            {
                AddTableRow(PanelFactory.MakePanelMessage(message.Topic, this, LoadTextToRead, message));


            }


            var userGroupList = GURepo.Table.Include(x => x.User).Include(g => g.Group).Where(g => g.User.Id == CurrentUser.UserId).Select(x => x.Group).ToList();

            foreach (Group group in userGroupList)
            {
             var messListGetGroup = MGRepo.Table.Include(x => x.Group).Include(m => m.Message).ThenInclude(x => x.Sender).Where(x => x.Group.Id == group.Id).Select(m => m.Message);
                foreach(Message message in messListGetGroup)
                {
                    AddTableRow(PanelFactory.MakePanelMessage(message.Topic, this, LoadTextToRead, message));

                }
            }


        }


        private void LoadSendData()
        {
            MainTable.Rows.Clear(); 
            
            var messListSend = messRepo.Table.Include(x => x.Sender).Where(x => x.Sender.Id == CurrentUser.UserId);

            foreach (Message message in messListSend)
            {

                AddTableRow(PanelFactory.MakePanelMessage(message.Topic, this, LoadTextToRead, message));


            }
        }


        void LoadTextToRead(object sender, EventArgs e)
        {

            Message mess = (Message)sender;
            TextBox.Text = " Nadawca:" +mess.Sender.UserName + mess.Sender.UserSurname+ "\n \n"+mess.Content + " \n \n Data wysłania wiadomości: " + mess.DateTime;
        

        }




        private void AddTableRow(params ListPanel<Message>[] cells)
        {
            TableRow row = new TableRow();
            foreach (var t in cells)
            {
                row.Controls.Add(t.ConvertToCell());
            }
            MainTable.Rows.Add(row);
        }
    }
}