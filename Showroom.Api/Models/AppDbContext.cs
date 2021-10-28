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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhotoPath = "images/Untitled.png"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                FirstName = "John",
                LastName = "Wayne",
                PhotoPath = "images/Untitled1.png"
            });
        }
    }
}
