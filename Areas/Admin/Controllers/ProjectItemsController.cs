using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Controllers;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models.ViewComponents;
using OnlinePanelForProjectsControl.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class ProjectItemsController : Controller
	{
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProjectItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ProjectItem() { DateOfStart = DateTime.UtcNow, PlannedDateOfEnd=DateTime.UtcNow} : dataManager.ProjectItems.GetProjectItemById(id);
            if(entity.ProjectTasks == null)
			{
                entity.ProjectTasks = new List<ProjectTask>();
                entity.ProjectTasks = dataManager.ProjectTasks.GetAllAsignedTasks(entity.Id).ToList();
            }
            return View(entity);
        }

        [HttpPost]
        public IActionResult AddDeveloperToProject(Guid projectId, string devId)
        {
            var entity = dataManager.ProjectItems.GetProjectItemById(projectId);
            var dev = dataManager.IdentityUsers.GetUserById(devId);

            dataManager.ProjectDevs.SaveProjectDev(new ProjectDevs { Id = new Guid(), DevId = devId, DeveloperItem = dataManager.IdentityUsers.GetUserById(devId),
                ProjectId = projectId, Project = dataManager.ProjectItems.GetProjectItemById(projectId) });

            return RedirectToAction(nameof(ProjectsController.Index), nameof(ProjectsController).CutController(), new { area = "default" ,id=projectId});
		}

        [HttpPost]
        public IActionResult Edit(ProjectItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ProjectItems.SaveProjectItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ProjectItems.DeleteProjectItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
