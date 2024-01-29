using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Repositories
{
    public class AttachmentsRepository : ARepository<Attachment>
    {
        public AttachmentsRepository()
        {
            Table = Context.Attachments;
        }

        public List<Attachment> GetAll()
        {
            return Table.ToList();
        }
    }
}