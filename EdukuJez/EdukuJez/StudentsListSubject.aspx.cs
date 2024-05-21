using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class StudentsListSubject : System.Web.UI.Page
    {
        const String SUBJECT_CONTENT_SITE = "SubjectContentPage.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(SUBJECT_CONTENT_SITE);
        }
    }
}