using Microsoft.EntityFrameworkCore;
using WebViewContact.Models.Domain;

namespace WebViewContact.WebViewContact.Data
{
    public class WebViewDbContext : DbContext
    {
        public WebViewDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-one relationship
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.AppUser)
                .WithOne(a => a.Contact)
                .HasForeignKey<Contact>(c => c.AppUserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
