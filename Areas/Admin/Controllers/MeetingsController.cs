using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Models;
using OnlinePanelForProjectsControl.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class MeetingsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostingEnvironment;
		public MeetingsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
		{
			this.dataManager = dataManager;
			this.hostingEnvironment = hostingEnvironment;
		}
		public IActionResult Index()
		{
            List<Meeting> meetings = dataManager.Meetings.GetMeetings().ToList();
            foreach(var meeting in meetings)
			{
                meeting.Devs = dataManager.MeetingDevs.GetAssignedDevelopers(meeting.Id).ToList();
			}
            return View(meetings.AsQueryable());
		}
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Meeting { DateOfMeet = DateTime.UtcNow } : dataManager.Meetings.GetMeeting(id);
            MeetingViewModel model = new MeetingViewModel();
            model.MeetingRef = entity;
            model.SelectedDevs = new MultiSelectList(dataManager.IdentityUsers.GetAllUsers(),"Id","UserName");
            model.devsId = new List<string>();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(MeetingViewModel model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (model.MeetingRef.Id == default) model.MeetingRef.Id = Guid.NewGuid();
                dataManager.Meetings.SaveMeeting(model.MeetingRef);
                List<MeetingDevs> newDevs = new List<MeetingDevs>();
                List<MeetingDevs> devsToDelete = new List<MeetingDevs>();
                if (model.devsId != null)
                {
                    foreach (var userId in model.devsId)
                    {
                        if (!dataManager.MeetingDevs.GetAllMeetingDevs(model.MeetingRef.Id).Any(x => x.DevId == userId & x.MeetingId == model.MeetingRef.Id))
                        {
                            newDevs.Add(new MeetingDevs()
                            {
                                DevId = userId,
                                Developer = dataManager.IdentityUsers.GetUserById(userId),
                                MeetingId = model.MeetingRef.Id,
                                Meeting = model.MeetingRef
                            });
						}
						else
						{
                            newDevs.Add(dataManager.MeetingDevs.GetAllMeetingDevs(model.MeetingRef.Id).FirstOrDefault(x => x.MeetingId == model.MeetingRef.Id & x.DevId == userId));
                        }
                    }

                    devsToDelete = dataManager.MeetingDevs.GetAllMeetingDevs(model.MeetingRef.Id).ToList();
                    devsToDelete = devsToDelete.Except(newDevs).ToList();
                    dataManager.MeetingDevs.DeleteMeetingDevs(devsToDelete);
                    dataManager.MeetingDevs.SaveMeetingDevs(newDevs, model.MeetingRef);
				}
				else
				{
                    devsToDelete = dataManager.MeetingDevs.GetAllMeetingDevs(model.MeetingRef.Id).ToList();
                    dataManager.MeetingDevs.DeleteMeetingDevs(devsToDelete);
                }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
		{
            dataManager.Meetings.DeleteMeeting(id);
            return RedirectToAction(nameof(MeetingsController.Index), nameof(MeetingsController).CutController());
		}

        public IActionResult Show(Guid id)
		{
            return View(dataManager.Meetings.GetMeeting(id));
		}
    }
}
