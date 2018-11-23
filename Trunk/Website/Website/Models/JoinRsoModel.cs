using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class JoinRsoModel
    {
        public List<Rso> RegisteredStudentOrganizations { get; set; }
    }

    public class Rso
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}