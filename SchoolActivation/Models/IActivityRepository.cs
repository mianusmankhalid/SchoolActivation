using System.Collections.Generic;

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
