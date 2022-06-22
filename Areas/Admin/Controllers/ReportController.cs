using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using Microsoft.AspNetCore.Hosting;
using OnlinePanelForProjectsControl.Domain;
using OnlinePanelForProjectsControl.Domain.Entities;

namespace OnlinePanelForProjectsControl.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReportsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostingEnvironment;
		public ReportsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
		{
			this.dataManager = dataManager;
			this.hostingEnvironment = hostingEnvironment;
		}

		public async Task<IActionResult> Index(Guid id)
		{
			string directory = Directory.GetCurrentDirectory().ToString();
			PdfFont font = PdfFontFactory.CreateFont(directory + "/wwwroot/fonts/times-new-roman-cyr.ttf");
			MemoryStream ms = new MemoryStream();
			PdfWriter writer = new PdfWriter(ms);
			PdfDocument pdfDocument = new PdfDocument(writer);
			Document document = new Document(pdfDocument,PageSize.A4.Rotate());
			writer.SetCloseStream(false);
			document.SetFont(font);
			ProjectItem projectItem = dataManager.ProjectItems.GetProjectItemById(id);

			List<ProjectTask> projectTasks = dataManager.ProjectTasks.GetAllAsignedTasks(projectItem.Id).ToList();
			double done = 0;
			int undone = 0;
			string percent;
			for(int i = 0; i < projectTasks.Count; i++)
			{
				if (projectTasks[i].isFinished) done++;
				else undone++;
			}
			if(undone == 0)
			{
				percent = "100%";
			}
			else
			{
				percent = Math.Round(((done / projectTasks.Count)*100), 2).ToString() +"%";
			}
			string status;
			if (undone > 0&projectTasks.Count!=0)
			{
				status = "В розробці";
			}
			else
			{
				status = "Завершений";
			}
			document.Add(new Paragraph(projectItem.Title).SetTextAlignment(TextAlignment.CENTER));

			Table table = new Table(4, false);

			Cell cellStatus = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Статус проекта"));
			Cell cellFinishPercent = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Процент готовності проекту"));	
			Cell cellMissedDays = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Відхилення від назначеної дати"));
			Cell cellUsedHoursOfWork = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Кількість витраченого часу"));	
			Cell CellDoneTasks = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(status));
			Cell CellOfFinishedWork = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(percent));
			string missedDateMessage;
			if (projectItem.PlannedDateOfEnd > DateTime.UtcNow)
			{
				missedDateMessage= "Залишилось: "+(projectItem.PlannedDateOfEnd - DateTime.UtcNow).Days.ToString()+" дні"; ;
			}
			else
			{
				missedDateMessage = "До кінця сроку: "+(projectItem.PlannedDateOfEnd - DateTime.UtcNow).Days.ToString().Trim('-')+"Дні";
			}
			Cell CellMissedEndTime = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(missedDateMessage));
			int estimatedTime = 0;
			int spendedTime = 0;
			for(int i = 0; i< projectTasks.Count; i++)
			{
				estimatedTime += projectTasks[i].EstimatedTime;
				spendedTime += projectTasks[i].SpendedTime;
			}

			Cell CellSpendedTime = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Витрачено часу: "+ spendedTime+"/" +estimatedTime+" годин"));


			table.AddCell(cellStatus);		
			table.AddCell(cellFinishPercent);
			table.AddCell(cellMissedDays);
			table.AddCell(cellUsedHoursOfWork);
			table.AddCell(CellDoneTasks);
			table.AddCell(CellOfFinishedWork);
			table.AddCell(CellMissedEndTime);
			table.AddCell(CellSpendedTime);

			Table TaskTable = new Table(4, false);
			table.UseAllAvailableWidth();
			document.Add(table);
			document.Add(new Paragraph());
			document.Add(new Paragraph("Задачі проекту").SetTextAlignment(TextAlignment.CENTER));
			Cell cellTaskNameHead = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Назва задачі"));
			Cell cellTaskTimeHead = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Витрачений/Запланований час"));
			Cell cellTaskStatusHead = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Статус задачі"));
			Cell cellDeveloperHead = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Розробник"));

			TaskTable.AddCell(cellTaskNameHead);
			TaskTable.AddCell(cellTaskTimeHead);
			TaskTable.AddCell(cellTaskStatusHead);
			TaskTable.AddCell(cellDeveloperHead);

			foreach (var task in projectTasks)
			{
				Cell cellTaskName = new Cell(1,1)
					.SetBackgroundColor(ColorConstants.WHITE)
					.SetTextAlignment(TextAlignment.CENTER)
					.Add(new Paragraph(task.TaskName));	
				Cell cellTaskTime = new Cell(1,1)
					.SetBackgroundColor(ColorConstants.WHITE)
					.SetTextAlignment(TextAlignment.CENTER)
					.Add(new Paragraph(task.SpendedTime+"/"+task.EstimatedTime));
				string taskstatus;
				if (task.isFinished) taskstatus = "Виконано";
				else taskstatus = "В розробці";
				Cell cellTaskStatus = new Cell(1,1)
					.SetBackgroundColor(ColorConstants.WHITE)
					.SetTextAlignment(TextAlignment.CENTER)
					.Add(new Paragraph(taskstatus));
				Cell cellDeveloper = new Cell(1,1)
					.SetBackgroundColor(ColorConstants.WHITE)
					.SetTextAlignment(TextAlignment.CENTER)
					.Add(new Paragraph(dataManager.IdentityUsers.GetUserById(task.DeveloperId).UserName));

				TaskTable.AddCell(cellTaskName);
				TaskTable.AddCell(cellTaskTime);
				TaskTable.AddCell(cellTaskStatus);
				TaskTable.AddCell(cellDeveloper);
			}
			TaskTable.UseAllAvailableWidth();
			document.Add(new Paragraph());
			document.Add(TaskTable);

			document.Add(new Paragraph("Продуктивність розробників").SetTextAlignment(TextAlignment.CENTER));

			Table devTable = new Table(4, false);

			Cell cellDevNameTitle = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Розробник"));
			Cell cellWorkEficiencyTitle = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Відсоток виконаних задач"));
			Cell cellAssignedTasks = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Кількість назначених задач"));
			Cell cellSpendedTime = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph("Затрачений час розробника"));

			devTable.AddCell(cellDevNameTitle);
			devTable.AddCell(cellWorkEficiencyTitle);
			devTable.AddCell(cellAssignedTasks);
			devTable.AddCell(cellSpendedTime);

			List<Developer> Devs = dataManager.ProjectDevs.GetAllDevelopersFromProject(projectItem.Id).ToList();

			foreach(var dev in Devs)
			{
				Cell cellDevName = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(dev.UserName));
				List<ProjectTask> assignedTask = projectTasks.Where(x => x.DeveloperId == dev.Id).ToList();
				List<ProjectTask> donedTask = assignedTask.Where(x => x.isFinished == true).ToList();
				int devSpendedTime = 0;
				string doneWork;
				for(int i = 0; i < assignedTask.Count; i++)
				{
					devSpendedTime += assignedTask[i].SpendedTime;
				}
				double percentOfDoneWork = 0;

				if (donedTask.Count==0)
				{
					percentOfDoneWork = 0;
				}
				else
				{
					percentOfDoneWork = Math.Round(((double)donedTask.Count / (double)assignedTask.Count) * 100, 2);
				}
				doneWork = percentOfDoneWork.ToString().Trim('-') + "%";
				Cell cellDevEfficiency = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(doneWork));
				Cell cellDevAssignedTasks = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(assignedTask.Count.ToString()));		
				Cell cellDevSpendedTime = new Cell(1, 1)
				.SetBackgroundColor(ColorConstants.WHITE)
				.SetTextAlignment(TextAlignment.CENTER)
				.Add(new Paragraph(devSpendedTime.ToString()));


				devTable.AddCell(cellDevName);
				devTable.AddCell(cellDevEfficiency);
				devTable.AddCell(cellDevAssignedTasks);
				devTable.AddCell(cellDevSpendedTime);
			}
			devTable.UseAllAvailableWidth();
			document.Add(devTable);

			document.Close();
			byte[] byteInfo = ms.ToArray();
			ms.Write(byteInfo, 0, byteInfo.Length);
			ms.Position = 0;
			FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
			//fileStreamResult.FileDownloadName = "NorthwindProducts.pdf";

			return fileStreamResult;
		}
	}
}
