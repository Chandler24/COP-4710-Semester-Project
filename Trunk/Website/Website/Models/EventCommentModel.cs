using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class EventCommentModel
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        public int CommentId { get; set; }

        public int EventId { get; set; }
    }
}