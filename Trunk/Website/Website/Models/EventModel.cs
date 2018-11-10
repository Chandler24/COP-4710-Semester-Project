using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class EventModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Month { get; set; }

        public string Description { get; set; }

        public RatingEnum Rating { get; set; }
    }
}