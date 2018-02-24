using System;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Models;
using Himbarry.Users.Storage.Interfaces.Models;
using Himberry.Common.Helpers;

namespace Himbarry.Users.Provider.Models
{
    public sealed class Traning : ITraning
    {
        private DayOfWeek _dayOfWeek;
        private TimeSpan _avgDuration;
        private Intensity _intensity;

        internal bool isChanged = false;

        public string UserId { get; private set; }
        public DayOfWeek DayOfWeek
        {
            get
            {
                return _dayOfWeek;
            }
            internal set
            {
                if (value != _dayOfWeek)
                {
                    _dayOfWeek = value;
                    isChanged = true;
                }
            }
        }
        public TimeSpan AvgDuration
        {
            get
            {
                return _avgDuration;
            }
            internal set
            {
                if (value != _avgDuration)
                {
                    _avgDuration = value;
                    isChanged = true;
                }
            }
        }
        public Intensity Intensity
        {
            get
            {
                return _intensity;
            }
            internal set
            {
                if (value != _intensity)
                {
                    _intensity = value;
                    isChanged = true;
                }
            }
        }

        internal Traning(string userId, DayOfWeek dayOfWeek, TimeSpan avgDuration, Intensity intensity)
        {
            UserId = userId;
            _dayOfWeek = dayOfWeek;
            _avgDuration = avgDuration;
            _intensity = intensity;
            isChanged = true;
        }

        //public TraningDataModel Convert()
        //{
        //    var result = Converter.Convert<TraningDataModel, Traning>(this);
        //    return result;
        //}
    }
}
