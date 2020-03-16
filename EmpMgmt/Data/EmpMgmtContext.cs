using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.Models
{
    public class EmpMgmtContext : DbContext
    {
        public EmpMgmtContext (DbContextOptions<EmpMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<EmpMgmt.Models.Emp> Emp { get; set; }
    }
}
