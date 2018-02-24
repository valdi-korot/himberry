using System;
using Himbarry.Users.Provider.Interfaces.Enums;

namespace Himbarry.Users.Provider.Interfaces.Models
{
    public interface ITraning
    {
        string UserId { get; }
        DayOfWeek DayOfWeek { get; }
        TimeSpan AvgDuration { get; }
        Intensity Intensity { get; }
    }
}
