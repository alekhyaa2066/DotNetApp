using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Employee 
{
    public class EmployeeDetailsModel : PageModel
    {
        private readonly IEmployeeData employeeData;

        private readonly IProjectData projectData;
        public LTI.Core.Employee Employee { get; set; }

        IEnumerable<LTI.Core.Project> reqProject;

        [TempData] //binding with temp data so goes to the temp data structure and searches for a key with UpdateMessage. If finds assign it's prperty to string.
        public string UpdateMessage { get; set; }
        [TempData]
        public string AddMessage { get; set; }

        public string skill { get; set; }
        [BindProperty]
        public string projectName { get; set; }

        public EmployeeDetailsModel(IEmployeeData employeeData, IProjectData projectData)
        {
            this.employeeData = employeeData;
            this.projectData = projectData;
        }
        public IActionResult OnGet(int employeeId) 
        {    
            Employee = employeeData.GetEmpById(employeeId);

            if (Employee == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                skill = Employee.Skills;
                ViewData["Project"] =  Projects(skill);
                return Page();
            }
                
            //return Page(); returns the page assosciated with this model.

        }

        public string Projects(string skill)
        {
             reqProject = projectData.GetProjectsBySkill(skill);
             foreach(LTI.Core.Project p in reqProject)
             {
                projectName = p.PName;
             }
            
             //ViewData["Project"] = projectName;
             return projectName;
        }

    }
}
