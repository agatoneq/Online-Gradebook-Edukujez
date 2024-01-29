using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EdukuJez.Repositories;

namespace EdukuJez.Model.Main
{
    public class PanelFactory
    {
        public static TablePanel MakePanel(String Title, String color, String href, Page MainPage, String  permission="*")
        {
            Panel p = new Panel();
            p.CssClass = "Main-Panel";
            p.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            p.BorderColor = Color.Black;
            p.BorderStyle = BorderStyle.Double;
            Panel inner = new Panel() { CssClass = "Main-Label-Panel" };
            Literal title = new Literal();
            title.Text = Title;
            inner.Controls.Add(title);
            p.Controls.Add(inner);
            ImageButton img = new ImageButton();
            img.CssClass = "Main-Panel-Image";
            img.ImageUrl = "~/Imgs/Arrow_left.png";
            img.Click += (s, args) => { MainPage.Response.Redirect(href); };
            // Dodajemy kontrolkę Image do kontrolki Panel
            p.Controls.Add(img);

            return new TablePanel(p, permission);
        }
        public static ListPanel<Attachment> MakeAttachmentListPanel(Action<object, EventArgs> onClickMethod, Attachment att)
        {
            Panel p = new Panel();
            p.CssClass = "Subject-Main-Panel";
            p.BackColor = System.Drawing.Color.OrangeRed;
            p.BorderColor = Color.Black;
            p.BorderStyle = BorderStyle.Double;
            Panel inner = new Panel() { CssClass = "Subject-Label-Panel" };
            Literal title = new Literal();
            title.Text = att.Name;
            inner.Controls.Add(title);
            p.Controls.Add(inner);
            ImageButton img = new ImageButton();
            img.CssClass = "Subject-Panel-Image";
            img.ImageUrl = "~/Imgs/Arrow_left.png";
            img.Click += (sender, e) => onClickMethod(att, e);
            // Dodajemy kontrolkę Image do kontrolki Panel
            p.Controls.Add(img);

            return new ListPanel<Attachment>(p, att);
        }
        public static ListPanel<Activity> MakeActivityListPanel(Action<object, EventArgs> onClickMethod, Activity act)
        {
            Panel p = new Panel();
            p.CssClass = "Subject-Main-Panel";
            p.BackColor = System.Drawing.Color.LightBlue;
            p.BorderColor = Color.Black;
            p.BorderStyle = BorderStyle.Double;
            Panel inner = new Panel() { CssClass = "Subject-Label-Panel" };
            Literal title = new Literal();
            title.Text = act.Name;
            inner.Controls.Add(title);
            p.Controls.Add(inner);
            ImageButton img = new ImageButton();
            img.CssClass = "Subject-Panel-Image";
            img.ImageUrl = "~/Imgs/Arrow_left.png";
            img.Click += (sender, e) => onClickMethod(act, e);
            // Dodajemy kontrolkę Image do kontrolki Panel
            p.Controls.Add(img);

            return new ListPanel<Activity>(p, act);
        }

        public static ListPanel<Message> MakePanelMessage(String Title, Page MainPage,Action<object, EventArgs> onClickMethod, Message Mess)
        {
            Panel p = new Panel();
            p.CssClass = "Message-Panel";
            p.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            p.BorderColor = Color.Black;
            p.BorderStyle = BorderStyle.Double;
            Panel inner = new Panel() { CssClass = "Message-Label-Panel" };
            Literal title = new Literal();
            title.Text = Title;
            inner.Controls.Add(title);
            p.Controls.Add(inner);
            ImageButton img = new ImageButton();
            img.CssClass = "Message-Panel-Image";
            img.ImageUrl = "~/Imgs/blank.png";
            img.Click += (s, args) => onClickMethod(Mess, args) ;
            // Dodajemy kontrolkę Image do kontrolki Panel
            p.Controls.Add(img);

            return new ListPanel<Message>(p, Mess);
        }
    }
}