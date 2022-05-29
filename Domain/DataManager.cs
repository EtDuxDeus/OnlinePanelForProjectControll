using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain
{
	public class DataManager
	{
		public ITextFieldsRepository TextFields { get; set; }
		public IProjectItemsRepository ProjectItems { get; set; }
		public IProjectTasksRepository ProjectTasks { get; set; }

		public DataManager(ITextFieldsRepository textFieldsRepository, IProjectItemsRepository projectItemsRepository, IProjectTasksRepository projectTasksRepository)
		{
			TextFields = textFieldsRepository;
			ProjectItems = projectItemsRepository;
			ProjectTasks = projectTasksRepository;
		}
	}
}
