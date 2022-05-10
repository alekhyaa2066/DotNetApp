using System;
using System.ComponentModel.DataAnnotations;


namespace LTI.Core
{
    public class Employee
    {
        [Key]
        public int EId { get; set; }

        [Required, StringLength(80)] //To perform custom validation can implement IValidateObject
        public string EName { get; set; }

        [Required] //data annotations
        public DeliveryUnits DU { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required, StringLength(10)]
        public string MobileNo { get; set; }

        [Required, StringLength(80)]
        public string Skills { get; set; }

        public Employee()
        {

        }

        public Employee(int EId, string EName, DeliveryUnits DU, int Experience, string Skills, string MobileNo)
        {
            
            this.EId = EId;
            this.EName = EName;
            this.DU = DU;
            this.Experience = Experience;
            this.Skills = Skills;
            this.MobileNo = MobileNo;
            
        }
    }
}
