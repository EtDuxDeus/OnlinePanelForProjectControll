using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProjectTasksController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostEnvironment;
		public ProjectTasksController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
		{
			this.dataManager = dataManager;
			this.hostEnvironment = hostEnvironment;
		}

		public IActionResult Edit(Guid id, Guid projectId)
		{
			var entity = id == default ? new ProjectTask() : dataManager.ProjectTasks.GetProjectTaskById(id);
			entity.ProjectId = projectId;
			entity.ProjectItem = dataManager.ProjectItems.GetProjectItemById(projectId); ;
			return View(entity);
		}
		[HttpPost]
		public IActionResult Edit(ProjectTask model)
		{
			if (ModelState.IsValid)
			{
				dataManager.ProjectTasks.SaveProjectTask(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
		public IActionResult Delete(Guid id)
		{
			dataManager.ProjectTasks.DeleteTask(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}
