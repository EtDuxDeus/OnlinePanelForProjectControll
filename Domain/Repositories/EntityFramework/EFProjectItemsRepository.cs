using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
    public class EFProjectItemsRepository : IProjectItemsRepository
    {
        private readonly AppDbContext context;
        public EFProjectItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ProjectItem> GetProjectItems()
        {
            return context.ProjectItems;
        }

        public ProjectItem GetProjectItemById(Guid id)
        {
            var entity = context.ProjectItems.FirstOrDefault(x => x.Id == id);
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public IQueryable<ProjectItem> GetAssignedProjects(string userId)
		{
            return context.ProjectTasks.Where(x => x.DeveloperId == userId).Select(x => x.ProjectItem);
		}

        public void SaveProjectItem(ProjectItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProjectItem(Guid id)
        {
            context.ProjectItems.Remove(new ProjectItem() { Id = id });
            context.SaveChanges();
        }
	}
}
