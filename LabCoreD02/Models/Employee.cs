using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabCoreD02.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "*")]
        public int id { get; set; }

        [Required(ErrorMessage ="*")]
        
        public string name { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(20,30,ErrorMessage ="age must be beetween 20 and 30")]
        public int age { get; set; }
       
        [Required(ErrorMessage = "*")]
        public string address { get; set; }

        [Required(ErrorMessage = "*")]
        public int salary { get; set; }
        [ForeignKey ("departments")]
        public int deptid { get; set; }
        public virtual department departments { get; set; }

    }
}
