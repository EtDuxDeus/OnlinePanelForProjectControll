using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IProjectDevsRepository
	{
		public IQueryable<ProjectItem> GetProjectsByUserId(string userId);
		public IQueryable<ProjectDevs> GetAllProjectDevs(Guid projectId);
		public IQueryable<ProjectDevs> GetAllProjectDevs(string userId);
		public IQueryable<Developer> GetAllDevelopersFromProject(Guid projectId);
		public void SaveProjectDev(ProjectDevs entity);
		public void DeleteProjectDev(Guid projectId,string userId);
	}
}
