using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTI.Core;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages.Employee
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeData empData; //creating an instance of IEmpData

        public ILogger<EmployeesModel> logger { get; private set; }

        public EmployeesModel(IEmployeeData empData, ILogger<EmployeesModel> logger)
        {
            this.empData = empData;
            this.logger = logger;
        }

        
        //A proprty in a Page model can function as an output model, input model or both, By adding [BindProperty] attribute.
        //
        //ModelBinding : Moves info from request into an input model(finds info that we need inside of request)
        // 1. Give input a "NAme" in html
        [BindProperty(SupportsGet = true)]
        public string ReqSkill { get; set; } 
        

        public IEnumerable<LTI.Core.Employee> Emps { get; set; }

        public void OnGet() //implementing onGet with search functionality
        {
            logger.LogError("Executing Employees");
            //HttpContext.Request.Query    ---> can use this to access the input from query string
            //But we used Model Binding
            Emps = empData.GetEmployeeBySkill(ReqSkill);
        }
    }
}
