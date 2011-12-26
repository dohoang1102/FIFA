using System;
using System.ComponentModel.DataAnnotations;

namespace Fifa.Core.Models
{
    public class UserStats : BaseEntity
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int Games { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        public decimal WinRate { get; set; }

        public decimal Elo { get; set; }

        public DateTime CalcDate { get; set; }
    }
}