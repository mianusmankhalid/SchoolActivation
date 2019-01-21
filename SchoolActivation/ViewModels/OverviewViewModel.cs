using System.Collections.Generic;

namespace SchoolActivation.ViewModels
{
	public class OverviewViewModel
	{
		public List<SpecificCityViewModel> Cities { get; set; }
		public string Title { get; set; }
		public int MiloPacksReceived { get; set; }
		public int MiloPackDistributed { get; set; }
		public int FootballReceived { get; set; }
		public int FootballDistributed { get; set; }
		public int WristbandReceived { get; set; }
		public int WristbandDistributed { get; set; }
	}
}
