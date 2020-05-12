using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Attendance.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<User> users { get; set; }

        public ModelContext() { }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}