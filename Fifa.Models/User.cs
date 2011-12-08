using System.ComponentModel.DataAnnotations;

namespace Fifa.Models
{
    public class User
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}