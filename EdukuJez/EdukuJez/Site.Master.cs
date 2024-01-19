using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class SiteMaster : MasterPage
    {
        const String LOGIN_SITE = "Default.aspx";
        public UsersRepository userRepo = new UsersRepository();
        public GroupUsersRepository grUsRepo = new GroupUsersRepository();
        public GroupsRepository groupRepo = new GroupsRepository();
        private List<User> children = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.IsInSession() )
            {
                var session = UserSession.GetSession();
                ProfilePanel.Visible = true;
                ProfileNameLabel.Text = session.UserName;
                ProfileSurnameLabel.Text = session.UserSurname;

               // if (session.UserGroups.Any(x => x.Name == "Rodzice")) //jesli zalogowany jest rodzicem
                {
                    if(Session["childrenList"] == null)
                    {
                        var group = session.user.Educates.FirstOrDefault(); //grupa ktora uczy zalogowany - na razie zwraca nulla
                        group = new Group(); //tymczasowo - zmazac
                        group.Id = 4; //tymczasowo - zmazac
                        List<int> usersId = grUsRepo.Table.Where(g => g.Group.Id == group.Id).Select(g => g.User.Id).ToList(); //id uczniow z grupy
                        children = userRepo.Table.Where(x => usersId.Contains(x.Id)).ToList();
                        Session["childrenList"] = children;
                        ChildrenDropDownList.Items.Add("Wybierz dziecko");
                    }
                    else
                       children = (List<User>)Session["childrenList"];
                    if (Session["checked_child"] == null)
                        ChildrenDropDownList.Items.Add("Wybierz dziecko");
                    foreach (var child in children) //dodanie dzieci do ChildrenDropDownList
                    {
                        ChildrenDropDownList.Items.Add(child.UserName);
                    }
                    if (!IsPostBack && Session["checked_child"] != null)
                    {
                        ChildrenDropDownList.SelectedValue = (String)Session["checked_child"] ;
                    }
                    ChildrenDropDownList.Visible = true; //pokaz liste dzieci
                    ChildButton.Visible = true;
                }
            }
            else
            {

                //Response.Redirect(LOGIN_SITE);
                ProfilePanel.Visible = false;
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            UserSession.EndSession(new Page());
            Response.Redirect(LOGIN_SITE);
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangingPassword.aspx");
        }

        protected void ChildButton_Click(object sender, EventArgs e)
        {
            if (ChildrenDropDownList.SelectedValue == "Wybierz dziecko")
                return;
            if(ChildrenDropDownList.Items.FindByText("Wybierz dziecko") != null)
                ChildrenDropDownList.Items.FindByText("Wybierz dziecko").Enabled = false;
            foreach (var i in children)
            {
                if (i.UserName == ChildrenDropDownList.SelectedValue)
                {
                    UserSession.GetSession().checkedChild = userRepo.Table.FirstOrDefault(x => x.Id == i.Id);
                    Session["checked_child"] = UserSession.GetSession().checkedChild.UserName;
                    Page.Response.Redirect(Page.Request.Url.ToString());//odswierzenie strony, bo zmiana dziecka
                    return;
                }
            }

        }
    }
}