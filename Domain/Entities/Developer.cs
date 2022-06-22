using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class Developer : IdentityUser
	{
		public List<ProjectTask> AssignedTasks { get; set; }
		//public List<ProjectItem> AssignedProjects { get; set; }
		//public List<Meeting> PlannedMeetings { get; set; }
	}
}
