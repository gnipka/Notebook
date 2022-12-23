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
        public ApplicationContext()
        {
            Database.Migrate();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = NotebookDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                    Password = @"\u0001\0\u0018\u0002\u0016\u0004\u0003\u0005",
                    GraphKeyPoints = null,
                    KeyboardPoints = null,
                    PathToImage = "",
                    DeltaPixels = 10,
                    AmountOfAttempt = 3,
                    DateRegister = new DateTime(2022, 12, 23, 17, 33, 13),
                    Note = null,
                    NoteId = 1,
                    HasGraphKey = false,
                    HasKeyboard = false, 
                    CodePhrase = "",
                });
            // qak - ключ гаммирования по данному времени

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<GraphKeyPoint> GraphKeyPoints { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<KeyboardPoint> KeyboardPoints { get; set; }
    }
}
