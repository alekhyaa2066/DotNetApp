using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Project
{
    public class ProjectDetailsModel : PageModel
    {
        private readonly IProjectData projectData;

        [TempData]
        public string UpdateMessage1 { get; set; }

        [TempData]
        public string AddMessage1 { get; set; }


        public LTI.Core.Project Project { get; set; }

        public ProjectDetailsModel(IProjectData projectData)
        {
            this.projectData = projectData;
        }
        public IActionResult OnGet(int projectId)
        {

            Project = projectData.GetPrjById(projectId);
            if (Project == null)
            {
                return RedirectToPage("NotFound");
            }
            else
                return Page();
        }
    }
}
