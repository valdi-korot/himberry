using System;
using Himberry.Service.Contrcts.IncomingContracts.Users.Enums;

namespace Himberry.Service.Contrcts.IncomingContracts.Users
{
    public sealed class TraningContract
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan AvgDuration { get; set; }
        public IntensityContract Intensity { get; set; }
    }
}
