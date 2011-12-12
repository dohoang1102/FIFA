using System;
using System.ComponentModel.DataAnnotations;

namespace Fifa.WebUi.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public User PlayerA { get; set; }

        [Required]
        public User PlayerB { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }

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