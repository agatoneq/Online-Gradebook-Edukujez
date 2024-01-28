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
        Subject presentedSubject;
        protected void Page_load(object sender, EventArgs e)
        {
            presentedSubject = SubjectManager.Subject;
            if (presentedSubject is null)
                Response.Redirect(SUBJECT_SITE);

            if (!IsPostBack)
            {
                
            }
            SubjectNameLabel.Text = presentedSubject.SubjectName;
            var a = new Attachment() {Name="Łubudubu" };
            var p = PanelFactory.MakeAttachmentListPanel((s, b) => { return; }, a);
            AttachmentTable.Rows.Add(p.ConvertToRow());
        }
    }
}