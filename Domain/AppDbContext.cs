using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TextField> TextFields { get; set; }
		public DbSet<ProjectItem> ProjectItems { get; set; }
		public DbSet<IdentityUser> IdentityUser { get; set; }
		public DbSet<ProjectTask> ProjectTasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ProjectTask>().HasKey(x => x.TaskID);
			modelBuilder.Entity<ProjectTask>().HasOne(x=>x.ProjectItem).WithMany(x=>x.ProjectTasks).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ProjectTask>().HasData(new ProjectTask
			{
				TaskID = new Guid("a37182eb-dabb-43e0-8952-c662fa5e634e"),
				ProjectId = new Guid("713DCD88-126D-4671-1ED1-08DA40A5C328"),
				TaskName = "Тест Тасков",
				TaskDescription = "Опис таску"
			});
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "8af10569-b018-4fe7-a380-7d6a14c70b74",
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
				Name = "user",
				NormalizedName = "USER"
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIl.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b",
				UserName = "user",
				NormalizedUserName = "USER",
				Email = "user@email.com",
				NormalizedEmail = "USER@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "userpassword"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "8af10569-b018-4fe7-a380-7d6a14c70b74",
				UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "f917fd6d-a7f9-4212-bbe7-c193cf061ef0",
				UserId = "451219dc-97d0-4f3a-90d3-a6b3a0d36c6b"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});
			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("ccc0d57c-b438-499c-964b-1a542a908894"),
				CodeWord = "PageProjects",
				Title = "Проекты"
			});
			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
