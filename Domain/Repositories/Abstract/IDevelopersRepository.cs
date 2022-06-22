using Microsoft.AspNetCore.Identity;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.Abstract
{
	public interface IDevelopersRepository
	{
		Developer GetUserByName(string userName);
		Developer GetUserById(string userId);
		IQueryable<Developer> GetAllUsers();
		void SaveUser(Developer user);
		void DeleteUser(string userId);
	}
}
