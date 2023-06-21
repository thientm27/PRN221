using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Models;

namespace RazorPagesDemoYoutube.Data
{
    public class CourseDbContext : IdentityDbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
            :base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

    }
}
