namespace Showroom.Api.Models
{
    using Microsoft.EntityFrameworkCore;
    using Showroom.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 1,
                OwnerId = "200",
                Name = "Test 1",
                Description = "This is just a test, this should influence 90% of people.",
                ProjectType = ProjectType.GamePlay,
                ProjectPath = "Projects/TestProject1",
                ProjectThumbnail = "images/Untitled1.png",
                Rating = 0,
                Views = 0
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 2,
                OwnerId = "250",
                Name = "Test 2",
                Description = "This is description of test project number 2. This is also awesome project.",
                ProjectType = ProjectType.Showroom,
                ProjectPath = "Projects/TestProject2",
                ProjectThumbnail = "images/Untitled2.png",
                Rating = 0,
                Views = 0
            });
        }
    }
}
