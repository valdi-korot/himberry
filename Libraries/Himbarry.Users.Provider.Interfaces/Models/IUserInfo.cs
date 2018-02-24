using Himbarry.Users.Provider.Interfaces.Enums;
using System;

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
        ITraning Traning { get; }

        int SleepTime { get; set; }
        int WorkTime { get; set; }
        int ActiveTime { get; set; }
        int PassiveTime { get; set; }

        void SetTraining(int count, TimeSpan avgDuration, Intensity intensity);
    }
}
