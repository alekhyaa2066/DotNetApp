using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Shared.ViewComponents
{
    public class TotalProjectsViewComponent : ViewComponent
    {
        private readonly IProjectData projData;

        public TotalProjectsViewComponent (IProjectData projData)
        {
            this.projData = projData;
        }

        public IViewComponentResult Invoke()
        {
            var count = projData.GetCountOfProjects();
            return View(count); //count acts as a model here and unlike returning the page we retirn a model
            //View is responsible for displaing count
        }

    }
}
