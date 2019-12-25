using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL.Entities;

namespace VogCodeChallenge.API.DAL
{
    public class ApplicationDbContext : IdentityDbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(x => x.department)
            .WithMany()
            .HasForeignKey(x => x.departmentToken);
            modelBuilder.Entity<Employee>()
            .HasOne(x => x.company)
            .WithMany()
            .HasForeignKey(x => x.companyToken);

            modelBuilder.Entity<Department>()
            .HasOne(x => x.company)
            .WithMany()
            .HasForeignKey(x => x.companyToken);

            base.OnModelCreating(modelBuilder);
        }
    }
}
