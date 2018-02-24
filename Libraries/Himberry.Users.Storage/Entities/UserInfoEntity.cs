using System;
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

        int SleepTime { get; set; }
        int WorkTime { get; set; }
        int ActiveTime { get; set; }
        int PassiveTime { get; set; }

        public int? Count { get; set; }
        public TimeSpan? AvgDuration { get; set; }
        public string Intensity { get; set; }
    }
}