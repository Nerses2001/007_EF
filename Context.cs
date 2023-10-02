using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_EF
{
    internal class Context: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "ManyToManyTest",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(x => new{ x.StudentId, x.CourseId});


            modelBuilder.Entity<StudentCourse>().HasOne(x => x.Student).WithMany(t => t.StudentCourses).HasForeignKey(fk => fk.StudentId);

            modelBuilder.Entity<StudentCourse>().HasOne(x => x.Course).WithMany(t => t.StudentCourses).HasForeignKey(fk => fk.CourseId);
        }

    }


}
