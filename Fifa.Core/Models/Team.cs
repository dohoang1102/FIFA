using System.ComponentModel.DataAnnotations;

namespace Fifa.Core.Models
{
    public class Team : BaseEntity
    {
        [StringLength(LengthName)]
        public string Name { get; set; }
    }
}