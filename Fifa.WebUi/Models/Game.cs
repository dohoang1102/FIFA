using System;
using System.ComponentModel.DataAnnotations;

namespace Fifa.WebUi.Models
{
    public class Game
    {
        public int Id { get; set; }

        public virtual User PlayerA { get; set; }
        public virtual User PlayerB { get; set; }

        public int PlayerAId { get; set; }
        public int PlayerBId { get; set; }

        public virtual Team TeamA { get; set; }
        public virtual Team TeamB { get; set; }

        public int TeamAId { get; set; }
        public int TeamBId { get; set; }

        [Required]
        public int ScoreA { get; set; }

        [Required]
        public int ScoreB { get; set; }

        public DateTime Date { get; set; }

        public Game()
        {
            Date = DateTime.Now;
        }
    }
}