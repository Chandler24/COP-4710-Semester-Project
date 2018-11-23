using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRsoConnection
    {
        void SaveRso(SaveRsoRequest request);

        List<RegisteredStudentOrganization> GetAllRsos();

        bool CheckIfUserIsInRso(int userId, int rsoId);

        void JoinRso(int rsoId, int userId);
    }
}
