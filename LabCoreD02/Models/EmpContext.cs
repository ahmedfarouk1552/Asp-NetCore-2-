using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCoreD02.Models;
using Microsoft.EntityFrameworkCore;

namespace LabCoreD02.Models
{
    public class EmpContext :DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> option) : base(option)
        {
          
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<department> Departments { get; set; }

    }
}
