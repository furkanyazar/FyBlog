using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class MvcCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MvcCore;Trusted_Connection=true");

            //optionsBuilder.UseSqlServer(@"Server=tcp:fymvcdemo.database.windows.net,1433;Initial Catalog=MvcCore;Persist Security Info=False;User ID=furkan;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.SenderMessages)
                .HasForeignKey(z => z.SenderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.ReceiverMessages)
                .HasForeignKey(z => z.ReceiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
