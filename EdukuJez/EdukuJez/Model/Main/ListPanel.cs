using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public class ListPanel : ICustomPanel
    {
        Panel main;
        public String REQPermission { get; }
        public ListPanel(Panel p)
        {
            this.REQPermission = REQPermission;
            main = p;
        }

        public void AttachToCell(TableCell tc)
        {
            tc.Controls.Add(main);
        }
    }
}