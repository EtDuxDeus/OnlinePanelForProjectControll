using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Controllers;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models;
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
			entity.ProjectItem = dataManager.ProjectItems.GetProjectItemById(projectId);
			List<Developer> devs = new List<Developer>();
			devs = dataManager.ProjectDevs.GetAllDevelopersFromProject(entity.ProjectId).ToList();
			ProjectTaskViewModel model = new ProjectTaskViewModel { ProjectTaskReference = entity, SelectedDev = new SelectList(devs,"Id","UserName") };
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(ProjectTaskViewModel model, string devId)
		{
			if (ModelState.IsValid)
			{
				var dev = dataManager.IdentityUsers.GetUserById(devId);
				model.ProjectTaskReference.Developer = dev;
				model.ProjectTaskReference.DeveloperId = devId;
				dataManager.ProjectTasks.SaveProjectTask(model.ProjectTaskReference);
				return RedirectToAction(nameof(ProjectsController.Index), nameof(ProjectsController).CutController(), new { area = "default", id = model.ProjectTaskReference.ProjectId });
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
