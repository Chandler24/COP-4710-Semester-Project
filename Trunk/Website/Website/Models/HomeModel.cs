using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class HomeModel
    {
        public List<EventModel> Events { get; set; }

        public int SelectedEventType { get; set; }

        [DisplayName("Event Type")]
        public List<EventType> EventTypes { get; set; }
    }
}