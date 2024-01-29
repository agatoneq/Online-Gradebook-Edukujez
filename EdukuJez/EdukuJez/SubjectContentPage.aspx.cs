using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Model.Main;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public partial class SubjectContentPage : Page
    {
        const String SUBJECT_SITE = "SubjectPage.aspx";
        const String ADD_ATTACHMENT_SITE = "AddAttachment.aspx";
        Subject presentedSubject;
        protected void Page_load(object sender, EventArgs e)
        {
            presentedSubject = SubjectManager.Subject;
            if (presentedSubject is null)
                Response.Redirect(SUBJECT_SITE);

            if (!IsPostBack)
            {
                if(UserSession.CheckPermission(UserSession.TEACHER_GROUP) == true)
                {
                    NewAttachmentButton.Visible = true;
                    NewActivityButton.Visible = true;
                }
            }
            SubjectNameLabel.Text = presentedSubject.SubjectName;
            //var a = new Attachment() {Name="Łubudubu" };
            //var p = PanelFactory.MakeAttachmentListPanel(this.ShowAttachment, a);
            //AttachmentTable.Rows.Add(p.ConvertToRow());   //odkomentować do testu
            FillTables();
        }
        protected void ShowAttachment(object sender, EventArgs e)
        {
            Attachment attachment = (Attachment)sender;
            Response.Redirect(attachment.Text);
        }
        protected void ShowActivity(object sender, EventArgs e)
        {
            Activity attachment = (Activity)sender;
        }
        private void FillTables()
        {
            AttachmentTable.Rows.Clear();
            ActivitesTable.Rows.Clear();
            if (presentedSubject.Attachments.Count == 0)
            {
                var r = new TableRow();
                var c = new TableCell();
                c.Controls.Add(new Literal() { Text = "Brak materiałów" });
                r.Cells.Add(c);
                AttachmentTable.Rows.Add(r);
            }
            else
            {
                foreach (var a in presentedSubject.Attachments)
                {
                    var p = PanelFactory.MakeAttachmentListPanel(this.ShowAttachment, a);
                    AttachmentTable.Rows.Add(p.ConvertToRow());
                }
            }
            if (presentedSubject.Activites.Count == 0)
            {
                var r = new TableRow();
                var c = new TableCell();
                c.Controls.Add(new Literal() { Text = "Brak aktywności" });
                r.Cells.Add(c);
                ActivitesTable.Rows.Add(r);
            }
            else
            {
                foreach (var a in presentedSubject.Activites)
                {
                    var p = PanelFactory.MakeActivityListPanel(this.ShowActivity, a);
                    AttachmentTable.Rows.Add(p.ConvertToRow());
                }
            }
        }

        protected void NewAttachmentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ADD_ATTACHMENT_SITE);
        }

        protected void NewActivityButton_Click(object sender, EventArgs e)
        {

        }
    }
}