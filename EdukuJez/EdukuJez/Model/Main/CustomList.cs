using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public class CustomList
    {
        public Table Table { get; private set; } = new Table();
        public List<ICustomPanel>  PanelList {get; private set;} = new List<ICustomPanel>();

        public void Clear()
        {
            Table = new Table();
        }
        public Table LoadList()
        {
            foreach (var p in PanelList)
            {
                TableRow row = new TableRow();
                var tc = new TableCell();
                p.AttachToCell(tc);
                row.Controls.Add(tc);
            }
            return Table;
        }
    }
}