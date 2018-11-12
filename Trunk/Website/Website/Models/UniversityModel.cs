using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class UniversityModel
    {
        [Required]
        [DisplayName("University Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Address Line 1")]
        public string PrimaryAddress { get; set; }
        
        [DisplayName("Address Line 2")]
        public string SecondaryAddress { get; set; }

        [Required]
        [DisplayName("City / Town")]
        public string City { get; set; }

        [Required]
        [DisplayName("State / Province / Region")]
        public string State { get; set; }

        [Required]
        [DisplayName("Zip / Postal Code")]
        public string Zip { get; set; }

        [Required]
        [DisplayName ("Number of Students")]
        public int NumberOfStudents { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}