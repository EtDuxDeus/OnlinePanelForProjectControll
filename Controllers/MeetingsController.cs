using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Controllers
{
	public class MeetingsController : Controller
	{
        private readonly DataManager dataManager;

        public MeetingsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Meetings.GetMeeting(id));
            }
            List<Meeting> meetings = dataManager.Meetings.GetMeetings().ToList();
            foreach (var meeting in meetings)
            {
                meeting.Devs = dataManager.MeetingDevs.GetAssignedDevelopers(meeting.Id).ToList();
            }
            return View(meetings.AsQueryable());
        }
    }
}
