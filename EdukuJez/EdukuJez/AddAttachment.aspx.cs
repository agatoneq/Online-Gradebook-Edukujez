using EdukuJez.Model.Main;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class AddAttachment : System.Web.UI.Page
    {
        const String SUBJECT_CONTENT_SITE = "SubjectContentPage.aspx";
        private SubjectsRepository repoS = new SubjectsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var c in Attachment.AttachmentContentType)
            {
                DropDownListAttachmentContentType.Items.Add(c);
            }
        }

        protected void ButtonAttachmentCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(SUBJECT_CONTENT_SITE);
        }

        protected void ButtonAttachmentAccept_Click(object sender, EventArgs e)
        {
            var subject = SubjectManager.Subject;
            Attachment a = new Attachment();
            a.Subject = subject;
            a.Name = TextBoxAttachmentName.Text;
            a.ContentType = DropDownListAttachmentContentType.SelectedItem.Text;
            a.Text = TextBoxAttachmentLink.Text;
            repoS.Table.FirstOrDefault(x => x.Id == subject.Id).Attachments.Add(a);
            repoS.Update();
            LabelInfo.Text = "Dodano materiał";
            LabelInfo.Visible = true;
            SubjectManager.ReloadSubject();
            Response.Redirect(SUBJECT_CONTENT_SITE);
        }
    }
}