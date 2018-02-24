using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himberry.Users.Storage.Entities
{
    [Table("UserInfo")]
    public sealed class UserInfoEntity
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(20)]
        public string Purpose { get; set; }
        [Required]
        [MaxLength(20)]
        public string TypeWork { get; set; }

        [Required]
        public int SleepTime { get; set; }
        [Required]
        public int WorkTime { get; set; }
        [Required]
        public int ActiveTime { get; set; }
        [Required]
        public int PassiveTime { get; set; }

        public List<TraningEntity> Tranings { get; set; }

    }
}