using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class SaveEventRequest
    {
        public string Name { get; set; }

        public int Type { get; set; }

        public int Category { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public int Location { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int EventAdmin { get; set; }

        public int HostUniversity { get; set; }

    }
}
