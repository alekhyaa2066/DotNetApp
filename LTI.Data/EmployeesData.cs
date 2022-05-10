using LTI.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTI.Data
{
    public class EmployeesData : IEmployeeData
    {
        readonly List<Employee> employees;

        public EmployeesData()
        {
            employees = new List<Employee>
            {
                new(1001, "Akshitha", DeliveryUnits.Consumer_Services, 2,"Terraform" , "9807652134" ),
                new(1002, "Lauv", DeliveryUnits.Banking_and_Financial, 1, ",Net", "609812543" ),
                new(1003, "Noor", DeliveryUnits.Insurance, 3, "DevOps", "8502413657" ),
                new(1004, "Krish", DeliveryUnits.Manufacturing, 4, "Java", "90783671249" ),
                new(1005, "Jones", DeliveryUnits.Media_Entertainment, 2, "Marketing", "709123457" ),
                new(1006, "Hari", DeliveryUnits.Oil_Gas, 1, "Angular", "9573452066" )

             
            };
        }
        public IEnumerable<Employee> GetEmployeeBySkill(string skill=null) //parameter can be optional so that displays all the projects in the db
        {
            
            return from e in employees
                   where string.IsNullOrEmpty(skill) || e.Skills.Equals(skill)
                   orderby e.EId
                   select e;
        }

        public int Commit()
        {
            return 0;
        }
        public Employee GetEmpById(int id)
        {
            return employees.SingleOrDefault(e => e.EId == id);
        }

        public Employee Add(Employee newEmployee)
        {
            employees.Add(newEmployee); //List.Add()
            newEmployee.EId = employees.Max(e => e.EId) + 1; //Lists Max Operator
            return newEmployee;
        }
        public Employee Update(Employee updatedEmployee)
        {
            var employee = employees.SingleOrDefault(e => e.EId == updatedEmployee.EId);
            if(employee != null)
            {
                employee.EName = updatedEmployee.EName;
                employee.Skills = updatedEmployee.Skills;
                employee.MobileNo = updatedEmployee.MobileNo;
                employee.DU = updatedEmployee.DU;
                employee.Experience = updatedEmployee.Experience;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.EId == id);
            if(employee != null)
            {
                employees.Remove(employee); //List.Remove
            }

            return employee;
        }

        public int GetCountOfEmployees() 
        {
            return employees.Count(); //List.Count
        }

        /*public string GetProject(string skill)
        {
            Project =  from p in employees
                   where string.IsNullOrEmpty(skill) || e.Skills.Equals(skill)
                   orderby e.EId
                   select e;

            return Project;
        }*/
    }
}
