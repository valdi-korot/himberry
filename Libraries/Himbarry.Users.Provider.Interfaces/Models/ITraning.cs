using System;
using Himbarry.Users.Provider.Interfaces.Enums;

namespace Himbarry.Users.Provider.Interfaces.Models
{
    public interface ITraning
    {
        int Count { get; set; }
        TimeSpan AvgDuration { get; set; }
        Intensity Intensity { get; set; }
    }
}
