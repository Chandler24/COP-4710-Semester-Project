using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class UniversityResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PrimaryAddress { get; set; }

        public string SecondaryAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public int NumberOfStudents { get; set; }

        public string Description { get; set; }
    }
}
