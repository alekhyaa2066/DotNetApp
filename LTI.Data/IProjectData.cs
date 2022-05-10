using LTI.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Data
{
    public interface IProjectData
    {
        IEnumerable<Project> GetProjectsBySkill(string skill);
        //IEnumerable is an interfaces and has just one method called GetEnumerator.
        //If we want to implement enumerator logic in any collection class, it needs to implement IEnumerable interface (either generic or non-generic).

        public Project GetPrjById(int pid);

        int Commit();

        Project Add(Project newProject);

        Project Update(Project updatedProject);

        Project Delete(int projectId);

        int GetCountOfProjects();
    }
}
