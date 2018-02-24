using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Himberry.Service.Contrcts.IncomingContracts.Users.Enums;

namespace Himberry.Service.Contrcts.IncomingContracts.Users
{
    public sealed class UserInfoIncomingContract
    {
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public float Weight { get; set; }
        public float Height { get; set; }
        public string FirstName { get; set; }
        public GenderContract Gender { get; set; }
        public TypeWorkContract TypeWork { get; set; }
        public PurposeContract Purpose { get; set; }
        public DistributedTimeDayContract DistributedTime { get; set; }
        public List<TraningContract> Tranings { get; set; }
    }

}