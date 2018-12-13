using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBackOffice.Models
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext (DbContextOptions<CompanyDbContext> options)
            : base(options) {}

        public DbSet<Employee> Employees { get; set; }
    }
}
