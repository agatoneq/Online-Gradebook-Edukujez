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
            p.CssClass = "Main-Panel";
            p.BackColor = System.Drawing.Color.Red;
            p.BorderColor = Color.Black;
            p.BorderStyle = BorderStyle.Double;
            Panel inner = new Panel() { CssClass = "Main-Label-Panel" };
            Literal title = new Literal();
            title.Text = att.Name;
            inner.Controls.Add(title);
            p.Controls.Add(inner);
            ImageButton img = new ImageButton();
            img.CssClass = "Main-Panel-Image";
            img.ImageUrl = "~/Imgs/Arrow_left.png";
            img.Click += (sender, e) => onClickMethod(att, e);
            // Dodajemy kontrolkę Image do kontrolki Panel
            p.Controls.Add(img);

            return new ListPanel<Attachment>(p, att);
        }

    }
}