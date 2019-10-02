using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsApplications.Models
{
    public class Post
    {
        public string link { get; set; }
        public string text { get; set; }
        public int viewcount { get; set; }
        public string source { get; set; }

        public Post()
        {
            link = "";
            text = "";
            viewcount = 0;
            source = "";
        }
    }
}