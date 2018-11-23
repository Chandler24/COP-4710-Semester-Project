using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class AddCommentRequest
    {
        public int UserId { get; set; }

        public int EventId { get; set; }

        public string Comment { get; set; }
    }
}
