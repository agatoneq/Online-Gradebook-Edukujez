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
        const String MAIN_SITE = "Main.aspx";
        public UsersRepository userRepo = new UsersRepository();
        public GroupUsersRepository grUsRepo = new GroupUsersRepository();
        public GroupsRepository groupRepo = new GroupsRepository();
        private List<User> children = new List<User>();
        protected override void OnInit(EventArgs e)
        {
            // Wywołaj oryginalną implementację OnInit z klasy bazowej
            base.OnInit(e);

            // Dodatkowe operacje inicjalizacyjne
            // ...
            string currentPage = Request.Url.Segments.LastOrDefault();

            if (currentPage != null && !UserSession.IsInSession())
            {
                if (!currentPage.Equals("Default", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect(LOGIN_SITE);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.IsInSession())
            {
                var session = UserSession.GetSession();
                ProfilePanel.Visible = true;
                ProfileNameLabel.Text = session.UserName;
                ProfileSurnameLabel.Text = session.UserSurname;
                if (UserSession.CheckPermission(UserSession.PARENT_GROUP) == true) //jesli zalogowany jest rodzicem
                {
                    List<int> usersId = new List<int>();
                    if (Session["childrenList"] == null)
                    {
                        Group group = groupRepo.Table.FirstOrDefault(x => x.Name == UserSession.GetSession().UserLogin); //grupa, ktorej nazwa jest login zalogowanego uzytkownika-grupa w ktorej sa dzieci zalogowanego
                        if (group != null)
                        { 
                        usersId = grUsRepo.Table.Where(g => g.Group.Id == group.Id).Select(g => g.User.Id).ToList(); //id uczniow z grupy
                        children = userRepo.Table.Where(x => usersId.Contains(x.Id)).ToList();
                        Session["childrenList"] = children;
                        ChildrenDropDownList.Items.Add("Wybierz dziecko");
                        }
                    }
                    else
                    {
                        children = (List<User>)Session["childrenList"];
                        if (Session["checked_child"] == null && ChildrenDropDownList.SelectedValue != "Wybierz dziecko")
                            ChildrenDropDownList.Items.Add("Wybierz dziecko");
                    }

                    if ((ChildrenDropDownList.Items.Count == 1 && ChildrenDropDownList.Items[0].Value == "Wybierz dziecko") || (ChildrenDropDownList.Items.Count == 0))
                    {
                        foreach (var child in children) //dodanie dzieci do ChildrenDropDownList
                        {
                            ChildrenDropDownList.Items.Add(child.UserName);
                        }
                    } 
                    if (!IsPostBack && Session["checked_child"] != null)
                    {
                        ChildrenDropDownList.SelectedValue = (String)Session["checked_child"];
                    }
                    ChildrenDropDownList.Visible = true; //pokaz liste dzieci
                    ChildButton.Visible = true;
                }
            }
            else
            {
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
            if (ChildrenDropDownList.Items.FindByText("Wybierz dziecko") != null)
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(MAIN_SITE);
        }
    }
}