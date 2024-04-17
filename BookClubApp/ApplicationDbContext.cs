using BookClubApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Book>();
                //.HasMany(u => u.Books)
                //.WithMany(b => b.Users)
                //.UsingEntity(j => j.ToTable("UserBooks"));
        }
    }
}
