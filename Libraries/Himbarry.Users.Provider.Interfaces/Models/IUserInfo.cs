using Himbarry.Users.Provider.Interfaces.Enums;
using System;
using System.Collections.Generic;

namespace Himbarry.Users.Provider.Interfaces.Models
{
    public interface IUserInfo
    {
        DateTime BirthDay { get; set; }
        float Weight { get; set; }
        float Height { get; set; }
        string FirstName { get; set; }
        Gender Gender { get; set; }
        TypeWork TypeWork { get; set; }
        Purpose Purpose { get; set; }
        IReadOnlyCollection<ITraning> Tranings { get; }

        int SleepTime { get; set; }
        int WorkTime { get; set; }
        int ActiveTime { get; set; }
        int PassiveTime { get; set; }

        void AddTraining(DayOfWeek dayOfWeek, TimeSpan avgDuration, Intensity intensity);
        void DeleteTrainings(IReadOnlyCollection<ITraning> tranings);
        IPersonNutrients CalculateNutrients(DateTime date);
    }
}
