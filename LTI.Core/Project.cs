using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Core
{
    public class Project
    {
        [Key]
        public int PId { get; set; }

        [Required, StringLength(10)]
        public string PName { get; set; }
        
        [Required, StringLength(80)]
        public string PManager { get; set; }

        //public string[] SkillsRequired { get; set; }
        [Required, StringLength(80)]
        public string Skill1 { get; set; }

        [Required, StringLength(80)]
        public string Skill2 { get; set; }

        [Required, StringLength(80)]
        public string Skill3 { get; set; }

        public Project()
        {

        }
        public Project (int PId, string PName, string PManager, string Skill1, string Skill2, string Skill3)
        {
            this.PId = PId;
            
            this.PName = PName;

            this.PManager = PManager;

            //this.SkillsRequired = SkillsRequired;
            this.Skill1 = Skill1;

            this.Skill2 = Skill2;

            this.Skill3 = Skill3;
        }
    }
}
