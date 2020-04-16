﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IRoutine
    {
        Task<List<RoutineName>> GetAllRoutineNames();
    }
}
