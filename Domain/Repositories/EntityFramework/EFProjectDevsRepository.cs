using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFProjectDevsRepository : IProjectDevsRepository
	{
		public AppDbContext context;
		public EFProjectDevsRepository(AppDbContext context)
		{
			this.context = context;
		}
		public void SaveProjectDev(ProjectDevs entity)
		{
			if (context.ProjectDevs.Any(x => x.DevId == entity.DevId & x.ProjectId == entity.ProjectId)) { return; }
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void DeleteProjectDev(Guid projectId,string userId)
		{
			context.ProjectDevs.Remove(new ProjectDevs() { ProjectId = projectId, DevId = userId });
		}

		public IQueryable<ProjectDevs> GetAllProjectDevs(Guid projectId)
		{
			return context.ProjectDevs.Where(x => x.ProjectId == projectId);
		}

		public IQueryable<ProjectDevs> GetAllProjectDevs(string userId)
		{
			return context.ProjectDevs.Where(x => x.DevId == userId);
		}

		public IQueryable<Developer> GetAllDevelopersFromProject(Guid projectId)
		{
			var projectDevs = context.ProjectDevs.Where(x => x.ProjectId == projectId);
			List<Developer> devs = new List<Developer>();
			foreach(var dev in projectDevs)
			{
				devs.Add(context.IdentityUser.FirstOrDefault(x => x.Id == dev.DevId));
			}
			return devs.AsQueryable<Developer>();
		}

		public IQueryable<ProjectItem> GetProjectsByUserId(string userId)
		{
			throw new NotImplementedException();
		}
	}
}
