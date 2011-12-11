using System.ComponentModel.DataAnnotations; 
namespace Fifa.WebUi.Models
{ 
	public class Team
	{
		public int Id {get; set;}
		[StringLength(50)]
		[Required]
		public string Name {get; set;}
	}
}