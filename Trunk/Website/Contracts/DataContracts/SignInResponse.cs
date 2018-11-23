using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class SignInResponse
    {
        public int UserId { get; set; }

        public UserTypeEnum UserType { get; set; }
    }
}
