using ClassroomManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClassroomManager.Api.Infrastructure 
{
    public class ClassromDataConext : DbContext
    {
        public ClassromDataConext() : base("Classroom")
        {
        }

        public IDbSet<Class> Classes { get; set; }
        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet <Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1 Teacher  many Classes
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithOptional(@c => @c.Teacher)
                .HasForeignKey(@c => @c.TeacherId);

            // 1 Student many Enrollments
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            // 1 Class many Enrollments 
            modelBuilder.Entity<Class>()
                .HasMany(@c => @c.Enrollments)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.ClassId);

            //Compound Key
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.ClassId, e.StudentId });
        }
    }
}