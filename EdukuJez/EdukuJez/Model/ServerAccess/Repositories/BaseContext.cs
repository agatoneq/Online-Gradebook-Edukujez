﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace EdukuJez.Repositories
{
    public class BaseContext : DbContext 
    {
        static BaseContext _instance;
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<ClassC> Classes { get; set; }
        public DbSet<ClassUsers> ClassUsers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeFormula> GradeFormulas { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageGroups> MessageGroups { get; set; }
        public DbSet<MessageUsers> MessageUsers { get; set; }
        public DbSet<Remark> Remark { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserParent> UserParents { get; set; }
        public static BaseContext GetContext()
        {
            if (_instance == null)
            {
                _instance = new BaseContext();
            }
            return new BaseContext();
        }


        public BaseContext()
        {
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja połączenia z bazą danych
            optionsBuilder.UseSqlServer(ServerClient.CONSTRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserLogin)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(u => u.SubjectName)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.TeacherGroup)
                .WithMany(g => g.SubjectsTeachers)
                .HasForeignKey(s => s.TeacherGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.StudentGroup)
                .WithMany(g => g.SubjectsStudents)
                .HasForeignKey(s => s.StudentGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(s => s.Users)
                .WithMany(g => g.Grades)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(s => s.Teacher)
                .WithMany(g => g.SubmittedGrades)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Remark>()
                .HasOne(s => s.Student)
                .WithMany(g => g.Remarks)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Remark>()
                .HasOne(s => s.Submitter)
                .WithMany(g => g.SubmittedRemarks)
                .HasForeignKey(s => s.SubmitterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GradeFormula>()
                .HasOne(u => u.Activity)
                .WithOne(p => p.formula)
                .HasForeignKey<Activity>(p => p.FormulaId);

            modelBuilder.Entity<UserParent>()
                .HasOne(s => s.Student)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserParent>()
                .HasOne(s => s.Parent)
                .WithMany(g => g.Parents)
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Substitution>()
                .HasOne(u => u.Class)
                .WithOne(p => p.Substitution)
                .HasForeignKey<ClassC>(p => p.SubstitutionId);
        }
    }
}