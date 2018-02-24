using Himbarry.Users.Storage.Interfaces.Enums;
using System;
using System.Collections.Generic;

namespace Himbarry.Users.Storage.Interfaces.Models
{
    public sealed class UserInfoDataModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public GenderData Gender { get; set; }
        public PurposeData Purpose { get; set; }
        public TypeWorkData TypeWork { get; set; }
        public int SleepTime { get; set; }
        public int WorkTime { get; set; }
        public int ActiveTime { get; set; }
        public int PassiveTime { get; set; }

        public List<TraningDataModel> Tranings { get; set; }
    }
}
