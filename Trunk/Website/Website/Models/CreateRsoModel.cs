using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class CreateRsoModel
    {
        [DisplayName("RSO Name")]
        public string Name { get; set; }

        [DisplayName("Host University")]
        public List<University> Universities { get; set; }

        public int SelectedUniversity { get; set; }

        [DisplayName("RSO Description")]
        public string Description { get; set; }

        [DisplayName("RSO Member #1")]
        public string Member1 { get; set; }

        [DisplayName("RSO Member #2")]
        public string Member2 { get; set; }

        [DisplayName("RSO Member #3")]
        public string Member3 { get; set; }

        [DisplayName("RSO Member #4")]
        public string Member4 { get; set; }

        [DisplayName("RSO Member #5")]
        public string Member5 { get; set; }
    }
}