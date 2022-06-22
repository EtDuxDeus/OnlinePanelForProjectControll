using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
	public class IdentityUserController : Controller
	{
		public readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostingEnvironment;
		public IdentityUserController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
		{
			this.dataManager = dataManager;
			this.hostingEnvironment = hostingEnvironment;
		}

        public IActionResult Index()
		{
            return View(dataManager.IdentityUsers.GetAllUsers());
		}

        public IActionResult Show()
		{
            return View();
		}


        public IActionResult Edit(Guid id)
        {
            RegisterViewModel entity = new RegisterViewModel();
            if(id != default)
			{
                var user = dataManager.IdentityUsers.GetUserById(id.ToString());
                entity.Id = id;
                entity.UserName = user.UserName;
                entity.Email = user.Email;
                entity.Password = String.Empty;
                entity.PhoneNumber = user.PhoneNumber;
			}
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(RegisterViewModel model)
        {
			if (ModelState.IsValid)
            {
                Developer user;
                if (model.Id == default)
                {
                    user = new Developer();
                    user.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    user = dataManager.IdentityUsers.GetUserById(model.Id.ToString());
                }
                user.UserName = model.UserName;
                user.NormalizedUserName = model.UserName.ToUpper();
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
                user.PhoneNumber = model.PhoneNumber;
                user.SecurityStamp = string.Empty;
                if(model.Password != default)
				{
                    user.PasswordHash = new PasswordHasher<Developer>().HashPassword(null, model.Password);
				}
                dataManager.IdentityUsers.SaveUser(user);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            dataManager.IdentityUsers.DeleteUser(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
