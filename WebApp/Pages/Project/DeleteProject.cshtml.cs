using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebApp.Pages.Project
{
    public class DeleteProjectModel : PageModel
    {
        private readonly IProjectData projData;
        public LTI.Core.Project proj { get; set; }

        public DeleteProjectModel(IProjectData projData)
        {
            this.projData = projData;
        }

        public IActionResult OnGet(int projectId)
        {
            proj = projData.GetPrjById(projectId);
            if (proj == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            var project = projData.Delete(projectId);
            projData.Commit();

            if (project == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["DeleteMessage1"] = $"{project.PName} deleted";
            return RedirectToPage("./Projects");
        }
    }
}
