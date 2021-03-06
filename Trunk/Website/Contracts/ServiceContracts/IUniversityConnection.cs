﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUniversityConnection
    {
        void AddUniversity(SaveUniversityRequest request);

        List<UniversityResponse> GetAllUniversities();
    }
}
