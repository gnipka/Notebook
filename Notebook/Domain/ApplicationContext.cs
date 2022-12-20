using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Notebook.Models;

namespace Notebook.Domain
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = NotebookDb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 1,
                NoteText = "",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "login",
                    Password = @"\u001e\u000f\u001d\u001d\u0019\u0001\u001c\n", // "password" ^ "n" -> "\u001e\u000f\u001d\u001d\u0019\u0001\u001c\n"
                    GraphKeyPoints = null,
                    PathToImage = "",
                    DateRegister = DateTime.Now,
                    Note = null,
                    NoteId = 1,
                    HasGraphKey = false,
                });

            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<GraphKeyPoint> GraphKeyPoints { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
    }
}
