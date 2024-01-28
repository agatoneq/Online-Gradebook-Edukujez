using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.Main
{
    public interface ICustomPanel
    {
        void AttachToCell(TableCell t);
    }
}
