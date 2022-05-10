using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Shared.ViewComponents
{
    public class TotalEmployeesViewComponent : ViewComponent
        //view component doesn't respond to http requests
        //View Component can be used from anywhere, any page in app
    {
        private readonly IEmployeeData empData;
        public TotalEmployeesViewComponent(IEmployeeData empData)
        {
            this.empData = empData;
        }

        public IViewComponentResult Invoke()
        {
            var count = empData.GetCountOfEmployees();
            return View(count);
        }
    }
}
