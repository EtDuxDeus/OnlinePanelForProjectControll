using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models.ViewComponents
{
	public class UserListViewComponent : ViewComponent
	{
		private readonly DataManager dataManager;

		public UserListViewComponent(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult((IViewComponentResult)View("Default", dataManager.IdentityUsers.GetAllUsers()));
		}
	}
}
