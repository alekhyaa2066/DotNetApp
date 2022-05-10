using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Employee
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly IEmployeeData empData;
        public LTI.Core.Employee emp { get; set; }

        public DeleteEmployeeModel(IEmployeeData empData)
        {
            this.empData = empData;
        }
        public IActionResult OnGet(int employeeId)
        {
            emp = empData.GetEmpById(employeeId);
            if (emp == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        public IActionResult OnPost(int employeeId)
        {
            var employee = empData.Delete(employeeId);
            empData.Commit();

            if (employee == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["DeleteMessage"] = $"{employee.EName} deleted";
            return RedirectToPage("./Employees");


        }
    }
}