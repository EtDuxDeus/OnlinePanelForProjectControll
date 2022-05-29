using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Controllers
{
	public class ProjectTaskController : Controller
	{
		private readonly DataManager dataManager;
		public ProjectTaskController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}
        public IActionResult Index(Guid id)
        {
            return View(dataManager.ProjectTasks.GetProjectTaskById(id));
        }
    }
}
