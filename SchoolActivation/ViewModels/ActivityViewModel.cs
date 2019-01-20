using SchoolActivation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolActivation.ViewModels
{
	public class ActivityViewModel
	{
		public List<Activity> Activities { get; set; }
		public string Title { get; set; }
	}
}
