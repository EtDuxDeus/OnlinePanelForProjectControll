using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IProjectTasksRepository
	{
		ProjectTask GetProjectTaskById(Guid Id);
		IQueryable<ProjectTask> GetAllAsignedTasks(Guid ProjectId);
		void SaveProjectTask(ProjectTask entity);
		void DeleteTask(Guid taskId);
	}
}
