using System;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Models;

namespace Himbarry.Users.Provider.Models
{
    public sealed class Traning : ITraning
    {
        private int _count;
        private TimeSpan _avgDuration;
        private Intensity _intensity;

        internal bool isChanged = false;

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != _count)
                {
                    _count = value;
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
            set
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
            set
            {
                if (value != _intensity)
                {
                    _intensity = value;
                    isChanged = true;
                }
            }
        }
    }
}
