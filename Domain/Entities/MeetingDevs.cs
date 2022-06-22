using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class MeetingDevs
	{
		[Required]
		public Guid Id { get; set; }
		public Guid MeetingId { get; set; }
		public Meeting Meeting { get; set; }
		public string DevId { get; set; }
		public Developer Developer { get; set; }
	}
}
