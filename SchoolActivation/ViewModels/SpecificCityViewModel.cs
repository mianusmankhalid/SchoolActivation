using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolActivation.ViewModels
{
	public class SpecificCityViewModel
	{
		public string City { get; set; }
		public int TotalSchools { get; set; }
		public int TotalStrength { get; set; }
		public int TotalParticipation { get; set; }
		public int SampleDistributed { get; set; }
		public int FootballDistributed { get; set; }
		public int WristbandDistributed { get; set; }
	}
}
