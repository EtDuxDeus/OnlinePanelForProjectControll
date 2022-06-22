using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFMeetingDevsRepository : IMeetingDevsRepository
	{
		public AppDbContext context;

		public EFMeetingDevsRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<MeetingDevs> GetAllMeetingDevs(Guid meetingId)
		{
			return context.MeetingDevs.Where(x => x.MeetingId == meetingId);
		}

		public IQueryable<MeetingDevs> GetAllMeetingDevs(string userId)
		{
			return context.MeetingDevs.Where(x => x.DevId == userId);
		}

		public IQueryable<Meeting> GetAssignedMeetings(string userId)
		{
			List<Meeting> meetings = new List<Meeting>();
			var meetingDevs = context.MeetingDevs.Where(x => x.DevId == userId);
			foreach(var meet in meetingDevs)
			{
				meetings.Add(context.Meetings.FirstOrDefault(x => x.Id == meet.MeetingId));
			}
			return meetings.AsQueryable<Meeting>();
		}
		public IQueryable<Developer> GetAssignedDevelopers(Guid meetingId)
		{
			List<Developer> devs = new List<Developer>();
			var meetginDevs = context.MeetingDevs.Where(x => x.MeetingId == meetingId);
			foreach(var user in meetginDevs)
			{
				devs.Add(context.IdentityUser.FirstOrDefault(x => x.Id == user.DevId));
			}
			return devs.AsQueryable<Developer>();
		}
		public void SaveMeetingDev(MeetingDevs entity)
		{
			if (context.MeetingDevs.Any(x => x.DevId == entity.DevId & x.MeetingId == entity.MeetingId))
			{
				return;
			}
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void SaveMeetingDevs(List<MeetingDevs> selectedDevs, Meeting meeting)
		{
			foreach(var dev in selectedDevs)
			{
				if(context.MeetingDevs.Any(x=>x.DevId == dev.DevId & x.MeetingId == dev.MeetingId))
				{
					continue;
				}
				if (dev.Id == default)
					context.Entry(dev).State = EntityState.Added;
				else
					context.Entry(dev).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteMeetingDev(Guid meetingId, string userId)
		{
			context.MeetingDevs.Remove(new MeetingDevs() { MeetingId = meetingId, DevId = userId });
			context.SaveChanges();
		}
		public void DeleteMeetingDevs(List<MeetingDevs> devsToDelete)
		{
			for(int i = 0; i < devsToDelete.Count; i ++)
			{
				context.MeetingDevs.Remove(devsToDelete[i]);
			}
			context.SaveChanges();
		}
	}
}
