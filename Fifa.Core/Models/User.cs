using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string PasswordSalt { get; set; }

        public int Role { get; set; }

        public string Color { get; set; }

        public bool IsAdmin
        {
            get
            {
                return (Role & 1) > 0;
            }
        }

        public DateTime RegistrationDate { get; set; }

        public ICollection<UserStats> UserStats { get; set; }

        //это часть тупости из репозитария
        private UserStats _LastUserStats;
        public UserStats LastUserStats
        {
            get
            {
                if (_LastUserStats == null)
                {
                    if (UserStats == null || UserStats.Count == 0)
                    {
                        _LastUserStats = new UserStats();
                    }
                    else
                    {
                        _LastUserStats = UserStats.OrderByDescending(x => x.CalcDate).FirstOrDefault();
                    }
                }
                return _LastUserStats;
            }
        }
    }
}