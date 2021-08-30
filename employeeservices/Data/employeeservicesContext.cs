using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using employeeservices.models;

namespace employeeservices.Data
{
    public class employeeservicesContext : DbContext
    {
        public employeeservicesContext (DbContextOptions<employeeservicesContext> options)
            : base(options)
        {
        }

        public DbSet<employeeservices.models.Employee> Employee { get; set; }
    }
}
