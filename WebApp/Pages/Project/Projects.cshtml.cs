using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Project
{
    public class ProjectsModel : PageModel
        //goal for a PageModel class is to respond for a http request (get, Post)
        //get request invokes the OnGet Method
    {
        private readonly IProjectData projData;

        public ProjectsModel(IProjectData projData)
        {
            this.projData = projData;
        }


        [BindProperty(SupportsGet = true)]
        public string ReqSkill { get; set; }

        public IEnumerable<LTI.Core.Project> Projs { get; set; }

        public void OnGet()
        {
            Projs = projData.GetProjectsBySkill(ReqSkill);
        }
    }
}
