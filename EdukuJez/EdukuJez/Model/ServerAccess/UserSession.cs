using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public class UserSession
    {
        const String LOGIN_SITE = "Default.aspx";
        static UserSession _instance;
        public User user { get; private set; }
        public int UserId { get { return user.Id; } }
        public string UserName { get { return user.UserName; } }
        public string UserSurname { get { return user.UserSurname; } }
        public List<Group> UserGroups { get; private set;  }
        public string UserLogin { get { return user.UserLogin; } }
        public string UserPassword { get { return user.UserPassword; } }
        public User checkedChild { get; set; }
        UserSession(User user)
        {
            this.user = user;
            //Wszystkie grupy urzytkownika
            var UserId = this.UserId;
            GroupUsersRepository groupUserRepo = new GroupUsersRepository();
            List<GroupUser> groupUserList = groupUserRepo.Table.Include(u => u.User).Include(g => g.Group).ToList();
            List<Group> result = groupUserList.Where(x => x.User.Id == UserId).Select(x => x.Group).ToList();
            UserGroups = new List<Group>();

            // Jeśli grupa ma rodzica, rekurencyjnie dodaj wszystkich rodziców
            foreach (var g in result)
            {
                UserGroups.AddRange(GetAllParentGroups(g.ParentGroup));
            }
            UserGroups=UserGroups.Distinct().ToList();
        }
        public static UserSession GetSession()
        {
            return _instance;
        }
        public static bool CheckPermission(String requiredGroupName)
        {
            bool isInGroup = UserSession.GetSession().UserGroups.Any(x => x.Name == requiredGroupName);
            return isInGroup;
        }
        public static bool CheckPermission(Group requiredGroup)
        {
            bool isInGroup = UserSession.GetSession().UserGroups.Any(x => x.Id == requiredGroup.Id);
            return isInGroup;
        }
        public void ChangeSitePermissionCheck(Page sender)
        {
            //tu dać sprawdzanie dostępu do strony
        }
        public static bool EnterNewSession(User user)
        {
            _instance = new UserSession(user);
            return true;
        }
        public static bool IsInSession()
        {
            if (_instance == null)
                return false;
            else
                return true;
        }
        public static void EndSession(Page sender)
        {
            _instance = null;
        }
        public List<Group> GetAllParentGroups(Group group)
        {
            List<Group> result = new List<Group>();
            if (group == null)
                return result;

            // Dodaj bieżącą grupę do listy wynikowej
            result.Add(group);

            // Jeśli grupa ma rodzica, rekurencyjnie dodaj wszystkich rodziców
            if (group.ParentGroup != null)
            {
                result.AddRange(GetAllParentGroups(group.ParentGroup));
            }

            return result;
        }
    }
}