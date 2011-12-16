using System;

namespace Fifa.Core.Models
{
    public class Comment: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        [StringLength(LengthText)]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}