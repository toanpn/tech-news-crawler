using NewsApplications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsApplications.ViewModel
{
    public class ListPosts
    {
        public List<Post> listPosts { get; set; }
        public ListPosts()
        {
            listPosts = new List<Post>();
        }
    }
}