using LTI.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Data
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetEmployeeBySkill(string skill);
        Employee GetEmpById(int id);

        Employee Update(Employee updatedEmployee);

        int Commit();
        Employee Add(Employee newEmployee);
        Employee Delete(int id);

        int GetCountOfEmployees();

        /*string GetProject(string skill);*/


    }
}
