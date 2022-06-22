using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlinePanelForProjectsControl.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Index()
		{
			return View(dataManager.ProjectItems.GetProjectItems());
		}
	}
}
