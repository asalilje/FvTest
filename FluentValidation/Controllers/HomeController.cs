using System;
using System.Web.Mvc;
using FVTest.Models;

namespace FVTest.Controllers
{
    public class HomeController : Controller
    {
	    readonly string[] _codes = new [] {"Hotel", "Flight", ""};

		public ActionResult Index()
		{
			var model = new Deviation {Types = _codes, PeriodFromDate = DateTime.Now.ToShortDateString(), PeriodToDate = DateTime.Now.ToShortDateString()};
			return View(model);
		}


		[HttpPost]
		public ActionResult Index(Deviation deviation)
		{
			if(!ModelState.IsValid)
				return View(deviation);
			return RedirectToAction("Index");
		}

    }
}
