using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class PostRepository : ARepository<Post>
    {
        public PostRepository()
        {
            Table = Context.Posts;
        }



        public List<Post> GetAll()
        {
            return Table.ToList();
        }
    }
}