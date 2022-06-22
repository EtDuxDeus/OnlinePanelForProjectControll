using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFMeetingsRepository : IMeetingsRepository
	{
		public readonly AppDbContext context;
		public EFMeetingsRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<Meeting> GetMeetings()
		{
			return context.Meetings;
		}

		public Meeting GetMeeting(Guid id)
		{
			return context.Meetings.FirstOrDefault(x => x.Id == id);
		}

		public void SaveMeeting(Meeting entity)
		{
			if(!context.Meetings.Any(x=>x.Id == entity.Id))
			{
				context.Entry(entity).State = EntityState.Added;
			}
			else
			{
				context.Entry(entity).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteMeeting(Guid id)
		{
			context.Meetings.Remove(new Meeting() { Id = id });
			context.SaveChanges();
		}
	}
}
