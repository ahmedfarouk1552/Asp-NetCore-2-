using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCoreD02.Models
{
    public class department
    {
        public department()
        {
            employees = new List<Employee>();
        }
        public int id { get; set; }
        public string dept_name { get; set; }
        public string location { get; set; }
        public virtual List<Employee> employees { get; set; }

    }
}
