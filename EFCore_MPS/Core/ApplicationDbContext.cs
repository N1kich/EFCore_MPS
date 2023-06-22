using EFCore_MPS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.Core
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<SupplierMp> Supplier { get; set; } = null;
        public DbSet<UnitMeasurementsMp> UnitMeasurements { get; set; } = null;
        public DbSet<TypeMp> TypeMps { get; set; } = null;

        public DbSet<RegistrationMpsView> RegistrationMps { get; set; } = null;
        private const string _connectionString = @"Server=DESKTOP-Q7UDDS1\SQLEXPRESS;Database=Mps";

        public ApplicationDbContext() => Database.EnsureCreated();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
