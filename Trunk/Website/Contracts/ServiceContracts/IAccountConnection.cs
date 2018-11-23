using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountConnection
    {
        List<UserType> GetUserTypes();

        void AddUser(SignupRequest request);

        SignInResponse SignIn(SignInRequest request);
    }
}
