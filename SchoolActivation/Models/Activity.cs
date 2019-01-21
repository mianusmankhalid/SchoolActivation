using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolActivation.Models
{
	public class Activity
	{
		public int Id { get; set; }
		[Required]
		public string ActivityId { get; set; }
		[Required]
		[Display(Name = "Name of Institute")]
		public string InstituteName { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public int Packs { get; set; }
		[Required]
		public int Football { get; set; }
		[Required]
		public int WristBand { get; set; }
		public string ImageUrl { get; set; }
		public int StrengthOfStudent { get; set; }
		public int Participation { get; set; }
		public int WristBandDistributed { get; set; }
		public int FootballDistributed { get; set; }
		public bool IsCanteen { get; set; }
		public bool IsFootballTeam { get; set; }
		public bool IsCoach { get; set; }
		public string CoachName { get; set; }
		public string CoachPhone { get; set; }

	}
}
