using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolActivation.Models;
using SchoolActivation.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolActivation.Controllers
{
	public class ActivityController : Controller
	{
		private readonly IActivityRepository _activityRepository;

		public ActivityController(IActivityRepository activityRepository)
		{
			_activityRepository = activityRepository;
		}

		public IActionResult Index()
		{
			var activities = _activityRepository.GetAllActivities().OrderBy(p => p.Date);

			var activityViewModel = new ActivityViewModel()
			{
				Activities = activities.ToList(),
				Title = "Welcome to School Activity Program"
			};

			return View(activityViewModel);
		}

		public IActionResult Details(int id)
		{
			var activity = _activityRepository.GetActivityById(id);
			if (activity == null)
				return NotFound();

			return View(activity);
		}

		public IActionResult StartActivity()
		{
			return View();
		}

		[HttpPost]
		public IActionResult StartActivity(Activity activity)
		{
			if (ModelState.IsValid)
			{
				activity.StartDate = DateTime.Now;
				_activityRepository.AddActivity(activity);
				return RedirectToAction("FinishActivity", new { id = activity.Id });
			}
			return View(activity);
		}

		public IActionResult EndActivity()
		{
			var activities = _activityRepository.GetAllActivities().OrderByDescending(p => p.Date).Where(a => a.EndDate.Year < 1990);

			var activityViewModel = new ActivityViewModel()
			{
				Activities = activities.ToList(),
				Title = "Activities"
			};

			return View(activityViewModel);
		}

		public IActionResult FinishActivity(int id)
		{
			var activity = _activityRepository.GetActivityById(id);
			if (activity == null)
				return RedirectToAction("Index");

			return View(activity);
		}

		[HttpPost]
		public IActionResult FinishActivity(Activity activity)
		{
			if (ModelState.IsValid)
			{
				activity.EndDate = DateTime.Now;
				_activityRepository.UpdateActivity(activity);
				return RedirectToAction("Index");
			}
			return View(activity);
		}
	}
}
