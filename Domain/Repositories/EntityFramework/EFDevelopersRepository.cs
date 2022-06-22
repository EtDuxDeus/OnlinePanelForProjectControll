using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Controllers;
using OnlinePanelForProjectsControl.Domain.Entities;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework
{
	public class EFDevelopersRepository : IDevelopersRepository
	{
		public readonly AppDbContext context;
		public EFDevelopersRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<Developer> GetAllUsers()
		{
			return context.IdentityUser;
		}

		public Developer GetUserById(string userId)
		{
			return context.IdentityUser.FirstOrDefault(x => x.Id == userId.ToString());
		}

		public Developer GetUserByName(string userName)
		{
			return context.IdentityUser.FirstOrDefault(x => x.UserName == userName);
		}

		public void SaveUser(Developer user)
		{
			try
			{
				if (!context.IdentityUser.Any(x => x.Id == user.Id))
				{
					context.Entry(user).State = EntityState.Added;
				}
				else
				{
					context.Entry(user).State = EntityState.Modified;
				}
				context.SaveChanges();
			}
			catch(Exception e) { }
		}
		public void DeleteUser(string userId)
		{
			var user = GetUserById(userId);
			context.IdentityUser.Remove(user);
			context.SaveChanges();
		}
	}
}
