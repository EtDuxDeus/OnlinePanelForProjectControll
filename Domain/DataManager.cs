using Microsoft.AspNetCore.Identity;
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
		public IDevelopersRepository IdentityUsers { get; set; }
		public IMeetingsRepository Meetings { get; set; }
		public IReportsRepository Reports { get; set; }
		public IMeetingDevsRepository MeetingDevs { get; set; }
		public IProjectDevsRepository ProjectDevs { get; set; }

		public DataManager(ITextFieldsRepository textFieldsRepository, IProjectItemsRepository projectItemsRepository, IProjectTasksRepository projectTasksRepository, IDevelopersRepository usersRepository,
			IMeetingsRepository meetings ,IReportsRepository reports,IMeetingDevsRepository meetingDevs, IProjectDevsRepository projectDevs)
		{
			TextFields = textFieldsRepository;
			ProjectItems = projectItemsRepository;
			ProjectTasks = projectTasksRepository;
			IdentityUsers = usersRepository;
			Meetings = meetings;
			Reports = reports;
			MeetingDevs = meetingDevs;
			ProjectDevs = projectDevs;
		}
	}
}
