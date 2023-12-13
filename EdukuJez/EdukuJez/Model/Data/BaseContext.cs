using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using EdukuJez.Repositories;
using EdukuJez;

namespace EdukuJez
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ClassC> ClassC { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjView> SubjView { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja połączenia z bazą danych
            optionsBuilder.UseSqlServer(ServerClient.CONSTRING);
        }
    }
}