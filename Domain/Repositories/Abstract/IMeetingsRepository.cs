using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IMeetingsRepository
	{
		IQueryable<Meeting> GetMeetings();
		Meeting GetMeeting(Guid id);
		void SaveMeeting(Meeting entity);
		void DeleteMeeting(Guid id);
	}
}
