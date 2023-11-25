using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public class TablePanel
    {
        Panel main;
        public String REQPermission { get;}
        public TablePanel(Panel p, String REQPermission)
        {
            this.REQPermission= REQPermission;
            main = p;
        }

        public TableCell ConvertToCell()
        {
            var c = new TableCell();
            c.Controls.Add(main);
            return c;
        }

    }
}