using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace EdukuJez.Repositories
{
    public class BaseContext : DbContext 
    {
        static BaseContext _instance;
        public DbSet<ClassC> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageGroups> MessageGroups { get; set; }
        public DbSet<MessageUsers> MessageUsers { get; set; }
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
                .HasOne(u => u.Post)
                .WithOne(p => p.User)
                .HasForeignKey<Post>(p => p.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserLogin)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(u => u.SubjectName)
                .IsUnique();
        }
    }
}