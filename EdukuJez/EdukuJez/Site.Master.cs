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
                ShowUserProfile(session);

                if (IsParent(session))
                {
                    SetupChildrenDropdownList(session);
                }
            }
            else
            {
                HideUserProfile();
            }
        }

        private void ShowUserProfile(UserSession session)
        {
            ProfilePanel.Visible = true;
            ProfileNameLabel.Text = session.UserName;
            ProfileSurnameLabel.Text = session.UserSurname;
        }

        private bool IsParent(UserSession session)
        {
            // Check if the user is a parent (modify this condition based on your actual logic)
            return session.UserGroups.Any(x => x.Name == "Rodzice");
        }

        private void SetupChildrenDropdownList(UserSession session)
        {
            if (Session["childrenList"] == null)
            {
                InitializeChildrenList(session);
            }
            else
            {
                children = (List<User>)Session["childrenList"];
            }

            PopulateChildrenDropdownList();
            SetSelectedChildDropdownValue();
            ShowChildrenControls();
        }

        private void InitializeChildrenList(UserSession session)
        {
            var group = session.user.Educates.FirstOrDefault();
            group = new Group(); // Temporary - remove this line
            group.Id = 4; // Temporary - remove this line

            List<int> usersId = grUsRepo.Table.Where(g => g.Group.Id == group.Id).Select(g => g.User.Id).ToList();
            children = userRepo.Table.Where(x => usersId.Contains(x.Id)).ToList();
            Session["childrenList"] = children;
            ChildrenDropDownList.Items.Add("Wybierz dziecko");
        }

        private void PopulateChildrenDropdownList()
        {
            if (Session["checked_child"] == null)
            {
                ChildrenDropDownList.Items.Add("Wybierz dziecko");
            }

            foreach (var child in children)
            {
                ChildrenDropDownList.Items.Add(child.UserName);
            }
        }

        private void SetSelectedChildDropdownValue()
        {
            if (!IsPostBack && Session["checked_child"] != null)
            {
                ChildrenDropDownList.SelectedValue = (string)Session["checked_child"];
            }
        }

        private void ShowChildrenControls()
        {
            ChildrenDropDownList.Visible = true;
            ChildButton.Visible = true;
        }

        private void HideUserProfile()
        {
            ProfilePanel.Visible = false;
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
            {
                return;
            }

            if (ChildrenDropDownList.Items.FindByText("Wybierz dziecko") != null)
            {
                ChildrenDropDownList.Items.FindByText("Wybierz dziecko").Enabled = false;
            }

            foreach (var i in children)
            {
                if (i.UserName == ChildrenDropDownList.SelectedValue)
                {
                    UserSession.GetSession().checkedChild = userRepo.Table.FirstOrDefault(x => x.Id == i.Id);
                    Session["checked_child"] = UserSession.GetSession().checkedChild.UserName;
                    Page.Response.Redirect(Page.Request.Url.ToString()); // Refresh the page because of child change
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