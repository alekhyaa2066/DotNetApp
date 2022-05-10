using LTI.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTI.Data
{
    public class ProjectsData : IProjectData
    {
        readonly List<Project> projects;

       List<Project> reqProject = new List<Project>();

        public ProjectsData()  //creating a constructor and assigning or initialising the values for properties of Project
        {
            projects = new List<Project>
            {
                //new ("p001", "EY", "Shyam", new string[] {".Net", "Angular", "SQL" }),
                new (001, "EY", "Shyam", ".Net", "Angular", "SQL" ),
                new (002, "PnG", "Alex", "Java", "Python", ".Net" ),
                new (003, "CB", "Amit", "Terraform", "Ansible", "Azure" ),
                new (004, "MS", "Leena", "AzDevOps", "Jenkins", ".Net"),
                new (005, "JJ", "Joseph", "Ansible", "Powershell", "SQL")

            };
        }


        public IEnumerable<Project> GetProjectsBySkill(string skill = null)
        {
            //List<Project> reqProject = new();

                if(skill != null)
                {
                    foreach(Project proj in projects)
                    {
                        if(proj.Skill1.Equals(skill) || proj.Skill2.Equals(skill) || proj.Skill3.Equals(skill))
                        {
                            reqProject.Add(proj);
                        }
                    }
                }
                else
                {
                    reqProject = projects;
                }
          
            return reqProject;

        }

        public int Commit()
        {
            return 0;
        }

        Project IProjectData.GetPrjById(int pid)
        {
            return projects.SingleOrDefault(p => p.PId == pid);
        }

        public Project Add(Project newProject)
        {
            projects.Add(newProject);
            newProject.PId = projects.Max(p => p.PId) + 1;
            return newProject;
        }

        public Project Update(Project updatedProject)
        {
            var project = projects.SingleOrDefault(p => p.PId == updatedProject.PId);
            if(project != null)
            {
                project.PName = updatedProject.PName;
                project.PManager = updatedProject.PManager;
                project.Skill1 = updatedProject.Skill1;
                project.Skill2 = updatedProject.Skill2;
                project.Skill3 = updatedProject.Skill3;
            }

            return project;
        }

        public Project Delete(int projectId)
        {
            var project = projects.FirstOrDefault(p => p.PId == projectId);
            if(project != null)
            {
                projects.Remove(project);
            }
            return project;
        }

        public int GetCountOfProjects()
        {
            return projects.Count(); //List.Count
        }
    }
}
