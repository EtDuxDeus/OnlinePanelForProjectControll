using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFReportsRepository: IReportsRepository
	{
		public readonly AppDbContext context;
		public EFReportsRepository(AppDbContext context)
		{
			this.context = context;
		}
	}
}
