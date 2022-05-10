using LTI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Data
{
    public class SqlProjectData : IProjectData
    {
        private readonly LTIDbContext db;

        public SqlProjectData(LTIDbContext db)
        {
            this.db = db;
        }
        public Project Add(Project newProject)
        {
            db.Add(newProject);
            return newProject;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Project Delete(int projectId)
        {
            var proj = GetPrjById(projectId);
            if(proj != null)
            {
                db.Remove(proj);
            }
            return proj;
        }

        public int GetCountOfProjects()
        {
            return db.AT_Employees.Count();
        }

        public Project GetPrjById(int pid)
        {
            return db.AT_Projects.Find(pid);
        }

        public IEnumerable<Project> GetProjectsBySkill(string skill)
        {
            var query = from p in db.AT_Projects
                        where p.Skill1.Equals(skill) || p.Skill2.Equals(skill) || p.Skill3.Equals(skill) || string.IsNullOrEmpty(skill)
                        orderby p.PId
                        select p;
            return query;
        }

        public Project Update(Project updatedProject)
        {
            var entity = db.Attach(updatedProject);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedProject;
        }
    }
}
