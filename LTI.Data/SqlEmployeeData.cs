using LTI.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LTI.Data
{
    public class SqlEmployeeData : IEmployeeData
    {

        private readonly LTIDbContext db;

        public SqlEmployeeData(LTIDbContext db)
        {
            this.db = db;
        }
        public Employee Add(Employee newEmployee)
        {
            db.Add(newEmployee);
            return newEmployee;
        }

        public int Commit()
        {
            return db.SaveChanges();
            
        }

        public Employee Delete(int id)
        {
            var emp = GetEmpById(id);
            if(emp != null)
            {
                db.Remove(emp);
            }
            return emp;
        }

        public int GetCountOfEmployees()
        {
            return db.AT_Employees.Count();
        }

        public Employee GetEmpById(int id)
        {
            return db.AT_Employees.Find(id); //find method searches for tuple when primary key is given
        }

        public IEnumerable<Employee> GetEmployeeBySkill(string skill)
        {
            var query = from e in db.AT_Employees
                        where e.Skills.StartsWith(skill) || string.IsNullOrEmpty(skill)
                        orderby e.EId
                        select e;

            return query;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var enitity = db.Attach(updatedEmployee);
            enitity.State = EntityState.Modified;
            return updatedEmployee;
        }
    }
}
