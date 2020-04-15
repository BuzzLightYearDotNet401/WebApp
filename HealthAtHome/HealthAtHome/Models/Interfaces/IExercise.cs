﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IExercise
    {
        Task<List<Exercise>> GetAllExercises();

        Task<Exercise> GetExerciseByID(int id);
    }
}