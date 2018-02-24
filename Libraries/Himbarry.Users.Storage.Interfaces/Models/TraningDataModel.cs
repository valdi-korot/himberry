using System;
using Himbarry.Users.Storage.Interfaces.Enums;

namespace Himbarry.Users.Storage.Interfaces.Models
{
    public class TraningDataModel
    {
        public int Count { get; set; }
        public TimeSpan AvgDuration { get; set; }
        public IntensityData Intensity { get; set; }
    }
}
