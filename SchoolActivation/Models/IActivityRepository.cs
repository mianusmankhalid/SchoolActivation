using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolActivation.Models
{
	public interface IActivityRepository
	{
		IEnumerable<Activity> GetAllActivities();

		Activity GetActivityById(int activityId);

		void AddActivity(Activity activity);

		void UpdateActivity(Activity activity);
	}
}
