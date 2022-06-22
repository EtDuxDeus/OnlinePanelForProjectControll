using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models;
using OnlinePanelForProjectsControl.Service;
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

		public IActionResult Edit(Guid id, Guid projectId)
		{
			ProjectTask task = dataManager.ProjectTasks.GetProjectTaskById(id);
			ProjectTaskViewModel model = new ProjectTaskViewModel() { ProjectTaskReference = task };
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(ProjectTaskViewModel model)
		{
			if (ModelState.IsValid)
			{
				ProjectTask task = dataManager.ProjectTasks.GetProjectTaskById(model.ProjectTaskReference.TaskID);
				task.SpendedTime = model.ProjectTaskReference.SpendedTime;
				task.isFinished = model.ProjectTaskReference.isFinished;
				task.TaskDescription = model.ProjectTaskReference.TaskDescription;

				dataManager.ProjectTasks.SaveProjectTask(task);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
	}
}
