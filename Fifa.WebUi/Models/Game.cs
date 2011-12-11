using System.ComponentModel.DataAnnotations; 
namespace Fifa.WebUi.Models
{ 
	public class Game
	{
		public int Id {get; set;}
		[Required]
		public string PlayerA {get; set;}
		[Required]
		public string PlayerB {get; set;}
		public string TeamA {get; set;}
		public string TeamB {get; set;}
		[Required]
		public string ScoreA {get; set;}
		[Required]
		public string ScoreB {get; set;}
		public System.DateTime Date {get; set;}
	}
}