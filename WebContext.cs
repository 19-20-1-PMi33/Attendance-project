using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attendance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Attendance
{
    public class WebContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<IdentityUser> users { get; set; }
        public DbSet<Attend> attendances { get; set; }
        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
