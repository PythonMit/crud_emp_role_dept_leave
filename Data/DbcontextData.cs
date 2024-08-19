using crud_emp_role_dept_leave.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace crud_emp_role_dept_leave.Data
{
    public class DbcontextData : DbContext
    {
        public DbcontextData(DbContextOptions<DbcontextData> options)
      : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                { 
                    RoleId=1,
                    RoleName = "Admin",
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "software devloper",
                },
                 new Role
                 {
                     RoleId = 3,
                     RoleName = "Hr",
                 },
                 new Role
                 {
                     RoleId = 4,
                     RoleName = "Designer",
                 }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    Deptname  = "Back end",
                },
                new Department
                {
                    DepartmentId = 2,
                    Deptname = "Front end",
                },
                 new Department
                 {
                     DepartmentId = 3,
                     Deptname = "Hr",
                 },
                 new Department
                 {

                     DepartmentId = 4,
                     Deptname = "Graphics Designer",
                 }
            );
        }

    }
}
