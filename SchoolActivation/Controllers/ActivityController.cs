using Microsoft.AspNetCore.Mvc;
using SchoolActivation.Models;
using SchoolActivation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
			var activities = _activityRepository.GetAllActivities().Where(a => a.EndDate.Year > 1990);
			var specificCityCollection = activities
				.GroupBy(l => l.City)
				.Select(cl => new SpecificCityViewModel
					{
						City = cl.First().City,
						TotalSchools = cl.Count(),
						TotalStrength = cl.Sum(c => c.StrengthOfStudent),
						TotalParticipation = cl.Sum(c => c.Participation),
						SampleDistributed = cl.Sum(c => c.Packs),
						FootballDistributed = cl.Sum(c => c.FootballDistributed),
						WristbandDistributed = cl.Sum(c => c.WristBandDistributed),
					}).ToList();
			var overviewViewModel = new OverviewViewModel()
			{
				Cities = specificCityCollection,
				Title = "Milo School Activation Program 2019",
				MiloPacksReceived = activities.Sum(a => a.Packs),
				MiloPackDistributed = activities.Sum(a => a.Packs),
				FootballReceived = activities.Sum(a => a.Football),
				FootballDistributed = activities.Sum(a => a.FootballDistributed),
				WristbandReceived = activities.Sum(a => a.WristBand),
				WristbandDistributed = activities.Sum(a => a.WristBandDistributed)
			};

			return View(overviewViewModel);
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

		public IActionResult Report()
		{
			var activities = _activityRepository.GetAllActivities().OrderByDescending(p => p.Date);

			var activityViewModel = new ActivityViewModel()
			{
				Activities = activities.ToList(),
				Title = "Milo School Acitvation Full Report 2019"
			};

			return View(activityViewModel);
		}
	}
}
