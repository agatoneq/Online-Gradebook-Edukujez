using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EdukuJez.Repositories;

using Image = System.Web.UI.WebControls.Image;

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
            if (att.ContentType==Attachment.IMAGE)
                p.BackColor = System.Drawing.Color.Olive;
            else
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
            if (att.ContentType == Attachment.PAGE)
            {
                p.BackColor = System.Drawing.Color.LightGreen;
                Image myImage = new Image();
                myImage.ImageUrl = "~/Imgs/Arrow_left.png";
                myImage.AlternateText = "Sample Image";
                myImage.CssClass = "Subject-Panel-Image";

                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl = att.Text;
                myLink.Target = "_blank";
                myLink.Controls.Add(myImage);
                myLink.CssClass = "Subject-Panel-Image";
                p.Controls.Add(myLink);
            }
            else
            {
                img.Click += (sender, e) => onClickMethod(att, e);
                p.Controls.Add(img);
            }
            // Dodajemy kontrolkę Image do kontrolki Panel

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
        private static void OpenNewTab(string url)
        {
            string script = $@"
        <script type='text/javascript'>
            window.open('{url}', '_blank');
        </script>";

            new Page().Response.Write(script);
        }
    }
}