using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using LTI.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Employee
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeData EmpData;

        private readonly IHtmlHelper htmlHelper;

        [BindProperty] //after clicking save button it populates info. binding for post method
        public LTI.Core.Employee Emp { get; set; }

        public IEnumerable<SelectListItem> DU { get; set; }

        public EditEmployeeModel(IEmployeeData EmpData, IHtmlHelper htmlHelper)
        {
            this.EmpData = EmpData;
            this.htmlHelper = htmlHelper;
        }

        //OnGet responds to a get request presents the form to user
        public IActionResult OnGet(int? employeeId) //making it nullable so that can create a new employee
        {
            DU = htmlHelper.GetEnumSelectList<DeliveryUnits>();
            if (employeeId.HasValue) //for updating the emp data if an id is passed
            {
                Emp = EmpData.GetEmpById(employeeId.Value);
            }
            else //else initialiss a new empty employee, so will be editing a new empty employee
            {
                Emp = new LTI.Core.Employee();
            }
            if(Emp == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost() //responds to a Post and take form ino and try to save into data source
        {
            //ModelState["Location"].Errors
            //ModelState["Location"].AttemptedValue
            if (!ModelState.IsValid) //checks if all the info that passed via Model Binding is valid for the model " Emp "
            {
                DU = htmlHelper.GetEnumSelectList<DeliveryUnits>(); 
                return Page();
            }

            if(Emp.EId > 0)
            {
                TempData["UpdateMessage"] = " Employee Details Updated Successully."; //Tempdata is a data structure kind of dictionary, stores temporarily the data provided and lost later.
                EmpData.Update(Emp);
            }
            else
            {
                TempData["AddMessage"] = " New Employee Added Successully.";
                EmpData.Add(Emp);
            }

            EmpData.Commit();
            
            return RedirectToPage("./EmployeeDetails", new { employeeId = Emp.EId });//url parameter to reach the details page with and shows info with specified id
        }
    
    }
}
