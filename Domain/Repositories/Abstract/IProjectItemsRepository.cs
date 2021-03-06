using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IProjectItemsRepository
	{
		IQueryable<ProjectItem> GetProjectItems();
		ProjectItem GetProjectItemById(Guid id);
		public IQueryable<ProjectItem> GetAssignedProjects(string userId);
		void SaveProjectItem(ProjectItem entity);
		void DeleteProjectItem(Guid id);
	}
}
