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
        private AttachmentsRepository repoA = new AttachmentsRepository();
        private Attachment a = new Attachment();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var c in a.AttachmentContentType)
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
            List<Attachment> subjectList = repoA.Table.Include(s => s.Subject).ToList();
            Subject subject = subjectList.Where(s=> s.Subject.Id == SubjectManager.Subject.Id).Select(x => x.Subject).ToList().FirstOrDefault();
            a.Subject = subject;
            a.Name = TextBoxAttachmentName.Text;
            a.ContentType = DropDownListAttachmentContentType.SelectedItem.Text;
            a.Text = TextBoxAttachmentLink.Text;
            repoA.Insert(a);
            LabelInfo.Text = "Dodano materiał";
            LabelInfo.Visible = true;
        }
    }
}