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
            return context.ProjectItems.FirstOrDefault(x => x.Id == id);
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
