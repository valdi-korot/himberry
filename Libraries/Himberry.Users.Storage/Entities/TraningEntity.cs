using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himberry.Users.Storage.Entities
{
    [Table("Trainings")]
    public sealed class TraningEntity
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string DayOfWeek { get; set; }
        public TimeSpan AvgDuration { get; set; }
        public string Intensity { get; set; }
    }
}