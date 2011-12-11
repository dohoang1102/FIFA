using System.ComponentModel.DataAnnotations; 
namespace Fifa.WebUi.Models
{ 
	public class User
	{
		public int Id {get; set;}
		[StringLength(50)]
		[Required]
		public string Name {get; set;}
		[Required]
		public string PasswordHash {get; set;}
		[Required]
		public string PasswordSalt {get; set;}
		public System.DateTime RegistrationDate {get; set;}
	}
}