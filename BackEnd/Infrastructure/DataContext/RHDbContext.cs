using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.DataContext
{
    public class RHDbContext : DbContext
    {
        public RHDbContext(DbContextOptions<RHDbContext> options)
            : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Instructors).WithMany(i => i.Courses)
        //        .Map(t => t.MapLeftKey("CourseID")
        //            .MapRightKey("PersonID")
        //            .ToTable("CourseInstructor"));
        //}

       

    }
}
