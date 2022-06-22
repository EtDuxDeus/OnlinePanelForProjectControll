using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OnlinePanelForProjectsControl.Service;
using OnlinePanelForProjectsControl.Domain.Repositories.Abstract;
using OnlinePanelForProjectsControl.Domain.Repositories.EntityFramework;
using OnlinePanelForProjectsControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlinePanelForProjectsControl.Domain.Entities;

namespace OnlinePanelForProjectsControl
{
	public class Startup
	{
		public IConfiguration  Configuration { get; }
		public Startup(IConfiguration configuration) => Configuration = configuration;
		public void ConfigureServices(IServiceCollection services)
		{
			Configuration.Bind("Project", new Config());

			services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
			services.AddTransient<IProjectItemsRepository, EFProjectItemsRepository>();
			services.AddTransient<IProjectTasksRepository, EFProjecTasksRepository>();
			services.AddTransient<IDevelopersRepository, EFDevelopersRepository>();
			services.AddTransient<IMeetingsRepository, EFMeetingsRepository>();
			services.AddTransient<IReportsRepository, EFReportsRepository>();
			services.AddTransient<IMeetingDevsRepository, EFMeetingDevsRepository>();
			services.AddTransient<IProjectDevsRepository, EFProjectDevsRepository>();
			services.AddTransient<DataManager>();

			services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

			services.AddIdentity<Developer, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 6;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "myCompanyAuth";
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			services.AddAuthorization(x =>
			{
				x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
				x.AddPolicy("UserArea", policy => { policy.RequireRole("user"); });
			});

			services.AddControllersWithViews(x=>
			{
				x.Conventions.Add(new AdminAreaAutorization("Admin", "AdminArea"));
			})
			.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
			.AddSessionStateTempDataProvider();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapAreaControllerRoute("admin", "ADMIN", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
