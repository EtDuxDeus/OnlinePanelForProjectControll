using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IMeetingDevsRepository
	{
		IQueryable<MeetingDevs> GetAllMeetingDevs(Guid meetingId);
		IQueryable<MeetingDevs> GetAllMeetingDevs(string userId);

		IQueryable<Developer> GetAssignedDevelopers(Guid meetingId);
		IQueryable<Meeting> GetAssignedMeetings(string userId);
		void SaveMeetingDev(MeetingDevs entity);
		void SaveMeetingDevs(List<MeetingDevs> selectedDevs, Meeting meetingId);
		void DeleteMeetingDev(Guid meetingId, string userId);
		void DeleteMeetingDevs(List<MeetingDevs> devsToDelete);
	}
}
