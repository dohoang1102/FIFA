namespace Fifa.Core.Models
{
    public class Tournament : BaseEntity
    {
        [StringLength(LengthName)]
        public string Name { get; set; }
    }
}