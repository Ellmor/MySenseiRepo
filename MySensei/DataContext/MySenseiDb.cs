using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MySensei.DataContext
{
    using Models;
    
    public class MySenseiDb : DbContext
    {
        public MySenseiDb()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                     .HasMany(u => u.OfferedCourses)
                     .WithMany(c => c.Users)
                     .Map(uc =>
                     {
                         uc.MapLeftKey("UserId");
                         uc.MapRightKey("CourseId");
                         uc.ToTable("OfferedCourses");
                     });

            modelBuilder.Entity<User>()
                     .HasMany(u => u.TakenCourses)
                     .WithMany(c => c.Users)
                     .Map(uc =>
                     {
                         uc.MapLeftKey("UserId");
                         uc.MapRightKey("CourseId");
                         uc.ToTable("Participation");
                     });

            modelBuilder.Entity<Course>()
                     .HasMany(c => c.Tags)
                     .WithMany(t => t.Courses)
                     .Map(ct =>
                     {
                         ct.MapLeftKey("CourseId");
                         ct.MapRightKey("TagId");
                         ct.ToTable("CourseTag");
                     });
        }
    }
}
