using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Project
{
    public class EditProjectModel : PageModel
    {

        private readonly IProjectData ProjData;

        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public LTI.Core.Project Proj { get; set; }

        public EditProjectModel(IProjectData ProjData, IHtmlHelper htmlHelper)
        {
            this.ProjData = ProjData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? projectId)
        {
            if (projectId.HasValue)
            {
                Proj = ProjData.GetPrjById(projectId.Value);
            }
            else
            {
                Proj = new LTI.Core.Project();
            }
            if(Proj == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            if (Proj.PId > 0)
            {
                TempData["UpdateMessage1"] = "Projcts Details Updated Successfully";
                ProjData.Update(Proj);
            }
            else
            {
                TempData["AddMessage1"] = "New Project Added";
                ProjData.Add(Proj);
            }

            ProjData.Commit();

            return RedirectToPage("./ProjectDetails", new { projectId = Proj.PId });
        }
    }
}
