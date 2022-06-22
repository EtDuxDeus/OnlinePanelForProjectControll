using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFProjecTasksRepository : IProjectTasksRepository
	{
		private readonly AppDbContext context;
		public EFProjecTasksRepository(AppDbContext context)
		{
			this.context = context;
		}
		public ProjectTask GetProjectTaskById(Guid Id)
		{
			return context.ProjectTasks.FirstOrDefault(x => x.TaskID == Id);
		}
		public IQueryable<ProjectTask> GetAllAsignedTasks(Guid projectId)
		{
			return context.ProjectTasks.Where(x=>x.ProjectId == projectId).Include(x=>x.ProjectItem);
		}

		public IQueryable<ProjectTask> GetAllDevAssignedTasks(string userId)
		{
			return context.ProjectTasks.Where(x => x.DeveloperId == userId).Include(x => x.Developer).Include(x =>x.ProjectItem);
		}

		public void SaveProjectTask(ProjectTask entity)
		{
			if (entity.TaskID == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void DeleteTask(Guid taskId)
		{
			context.ProjectTasks.Remove(new ProjectTask() { TaskID = taskId });
			context.SaveChanges();
		}
	}
}
