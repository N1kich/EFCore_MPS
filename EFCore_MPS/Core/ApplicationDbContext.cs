using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.Core
{
    class ApplicationDbContext: DbContext
    {
        private const string _connectionString = @"Data Source=DESKTOP-Q7UDDS1\SQLEXPRESS;Initial Catalog=mps;Integrated Security=True";

        ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
