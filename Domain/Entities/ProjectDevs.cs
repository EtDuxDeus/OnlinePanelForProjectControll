using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class ProjectDevs
	{
		[Required]
		public Guid Id { get; set; }
		public Guid ProjectId { get; set; }
		public ProjectItem Project { get; set; }
		public string DevId { get; set; }
		public Developer DeveloperItem {get;set;}
	}
}
