using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SAHINBEKIR\\SQLEXPRESS01;database=DynamicBlogDb; integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.MessageSender)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.MessageReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Writer>? Writers { get; set; }
        public DbSet<NewsLetter>? NewsLetters { get; set; }
        public DbSet<BlogRaiting>? BlogRaitings { get; set; }
        public DbSet<Notification>? Notifications { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Message2>? Message2s { get; set; }

    }
    // Migration Commands
    /*
    ->add-migration migname
    ->remove-migration for re-do
    ->update-database
    */
    // Database BlogRating Triggers SQL Command
    /*
    Create Trigger AddBlogInRaitingTable
    On Blogs
    After Insert
    As
    Declare @ID int
    Select @ID=BlogID from inserted
    Insert Into BlogRaitings (BlogID,BlogTotalScore,BlogRaitingCount)
    Values (@ID,0,0)
    */

    /*
    Create Trigger AddScoreInComment
    On Comments
    After Insert
    As
    Declare @ID int
    Declare @Score int
    Declare @RaitingCount int
    Select @ID=BlogID, @Score=BlogScore from inserted
    Update BlogRaitings Set BlogTotalScore=BlogTotalScore+@Score, BlogRaitingCount+=1
    Where BlogID=@ID
    */
}
