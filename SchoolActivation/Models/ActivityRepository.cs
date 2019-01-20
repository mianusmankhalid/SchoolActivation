using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolActivation.Models
{
	public class ActivityRepository: IActivityRepository
	{
		private readonly AppDbContext _appDbContext;

		public ActivityRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<Activity> GetAllActivities()
		{
			return _appDbContext.Activities;
		}

		public Activity GetActivityById(int activityId)
		{
			return _appDbContext.Activities.FirstOrDefault(p => p.Id == activityId);
		}

		public void AddActivity(Activity activity)
		{
			_appDbContext.Activities.Add(activity);
			_appDbContext.SaveChanges();
		}

		public void UpdateActivity(Activity activity)
		{
			_appDbContext.Activities.Update(activity);
			_appDbContext.SaveChanges();
		}
	}
}
