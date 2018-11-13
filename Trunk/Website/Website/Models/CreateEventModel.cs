using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class CreateEventModel
    {
        [DisplayName("Event Name")]
        public string Name { get; set; }

        [DisplayName("Event Category")]
        public List<EventCategory> EventCategories { get; set; }

        public int SelectedCategory { get; set; }

        [DisplayName("Host University")]
        public List<University> Universities { get; set; }

        public int SelectedUniversity { get; set; }

        [DisplayName("Event Type")]
        public List<EventType> EventTypes { get; set; }

        public int SelectedEventType { get; set; }

        [DisplayName("Event Description")]
        public string Description { get; set; }

        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }

        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }

        [DisplayName("Start Time")]
        public string StartTime { get; set; }

        [DisplayName("End Time")]
        public string EndTime { get; set; }

        [DisplayName("Event Date")]
        public string Date { get; set; }
    }

    public class EventCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class University
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EventType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}