using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models.ViewComponents;
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
                ProjectItemViewModel model = new ProjectItemViewModel();
                model.ProjectItem = dataManager.ProjectItems.GetProjectItemById(id);
                if(model.ProjectItem.ProjectTasks == null)
				{
                    model.ProjectItem.ProjectTasks = dataManager.ProjectTasks.GetAllAsignedTasks(model.ProjectItem.Id).ToList();
				}
                if(model.ProjectItem.Devs == null)
				{
                    model.ProjectItem.Devs = dataManager.ProjectDevs.GetAllProjectDevs(model.ProjectItem.Id).ToList();
                    model.AssignedDevs = dataManager.ProjectDevs.GetAllDevelopersFromProject(model.ProjectItem.Id).ToList();
				}
                List<Developer> selList = dataManager.IdentityUsers.GetAllUsers().ToList();
                for(int i = 0; i< model.AssignedDevs.Count; i++)
				{
                    selList.Remove(dataManager.IdentityUsers.GetUserById(model.AssignedDevs[i].Id));
				}
                model.NewDev = new SelectList(selList, "Id","UserName");
                return View("Show", model);
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageProjects");
            return View(dataManager.ProjectItems.GetProjectItems());
        }
    }
}
