namespace Fifa.Models
{
    public class Game : BaseEntity
    {
        public int PlayerAId { get; set; }
        public User PlayerA { get; set; }

        public int PlayerBId { get; set; }
        public User PlayerB { get; set; }

        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }

        public int TeamAId { get; set; }
        public Team TeamA { get; set; }

        public int TeamBId { get; set; }
        public Team TeamB { get; set; }
    }
}