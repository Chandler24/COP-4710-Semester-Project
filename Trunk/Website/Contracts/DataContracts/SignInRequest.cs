using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class SignInRequest
    {
        public string Password { get; set; }

        public string Username { get; set; }
    }
}
