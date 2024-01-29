using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public class ListPanel<T>
    {
        public T Entity { get; set; }
        Panel main;
        public ListPanel(Panel p, T entity)
        {
            main = p;
            Entity = entity;
        }

        public TableCell ConvertToCell()
        {
            var c = new TableCell();
            c.Controls.Add(main);
            return c;
        }
        public TableRow ConvertToRow()
        {
            var c = new TableCell();
            var r = new TableRow();
            c.Controls.Add(main);
            r.Cells.Add(c);
            return r;
        }
    }
}