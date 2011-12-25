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

        // TODO rename to PasswordSalt, but don't lose all data!
        [StringLength(LengthName)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the color which identify the user.
        /// </summary>
        public string Color { get; set; }

        // TODO add IsAdmin field

        public DateTime RegistrationDate { get; set; }

        public int UserStatsId { get; set; }
        public UserStats UserStats { get; set; }
    }
}