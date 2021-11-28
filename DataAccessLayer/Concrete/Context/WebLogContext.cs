using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context
{
    public class WebLogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("server=YAHYAERDOGAN\\SQLEXPRESS;database=WebLogDatabase; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.MessageOfSender)
                .WithMany(y => y.MessageSender)
                .HasForeignKey(z => z.MessageSenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<Message>()
                .HasOne(x => x.MessagesOfReceiver)
                .WithMany(y => y.MessageReceiver)
                .HasForeignKey(z => z.MessageReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
