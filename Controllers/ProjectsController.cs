using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Controllers
{
	public class ProjectsController : Controller
	{
        private readonly DataManager dataManager;

        public ProjectsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                var project = dataManager.ProjectItems.GetProjectItemById(id);
                if(project.ProjectTasks == null)
				{
                    project.ProjectTasks = dataManager.ProjectTasks.GetAllAsignedTasks(project.Id).ToList();
				}
                return View("Show", dataManager.ProjectItems.GetProjectItemById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageProjects");
            return View(dataManager.ProjectItems.GetProjectItems());
        }
    }
}
