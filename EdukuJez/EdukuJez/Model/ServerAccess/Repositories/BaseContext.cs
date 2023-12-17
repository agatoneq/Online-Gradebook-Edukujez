using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez.Repositories
{
    public class BaseContext : DbContext 
    {
        public DbSet<ClassC> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja połączenia z bazą danych
            optionsBuilder.UseSqlServer(ServerClient.CONSTRING);
        }

    }
}