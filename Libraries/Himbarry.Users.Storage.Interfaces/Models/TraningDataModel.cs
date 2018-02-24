using System;
using Himbarry.Users.Storage.Interfaces.Enums;

namespace Himbarry.Users.Storage.Interfaces.Models
{
    public sealed class TraningDataModel
    {
        public string UserId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan AvgDuration { get; set; }
        public IntensityData Intensity { get; set; }
    }
}
