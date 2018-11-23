using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class SaveRsoRequest
    {
        public string Name { get; set; }

        public int University { get; set; }

        public string Description { get; set; }

        public List<string> Members { get; set; }

        public string AdminEmail { get; set; }
    }
}
