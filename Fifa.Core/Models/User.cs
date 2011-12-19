using System;
using System.ComponentModel.DataAnnotations;

namespace Fifa.Core.Models
{
    public class User : BaseEntity
    {
        [StringLength(LengthName)]
        public string Login { get; set; }

        [StringLength(LengthName)]
        public string Name { get; set; }

        [StringLength(LengthName)]
        public string PasswordHash { get; set; }

        [StringLength(LengthName)]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int UserStatsId { get; set; }
        public UserStats UserStats { get; set; }
    }
}