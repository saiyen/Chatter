using Repository_Layer.DtoModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository_Layer.DatabaseContexts
{
    public class ChatContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local); Database=ChatDB; Integrated Security=true; MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(
                            user =>
                            {
                                user.Property(x => x.Id).ValueGeneratedOnAdd();
                                user.Property(x => x.FirstName).HasMaxLength(25);
                            })
                            .Entity<UserEntity>().ToTable("User")
                                .HasQueryFilter(user => !user.IsDeleted);

            modelBuilder.Entity<MessageEntity>(
                message =>
                {
                    message.Property(x => x.Id).ValueGeneratedOnAdd();
                    message.Property(x => x.Content).HasMaxLength(125);
                })
                .Entity<MessageEntity>().ToTable("Message")
                    .HasQueryFilter(message => !message.IsDeleted)
                    .HasOne(m => m.Sender);

            modelBuilder.Entity<MessageRecipientEntity>()
                .HasKey(x => new { x.MessageId, x.RecipientId });

            modelBuilder.Entity<MessageRecipientEntity>().ToTable("MessageRecipient")
                .HasOne(msgRC => msgRC.Users)
                .WithMany(usr => usr.MessageRecipient)
                .HasForeignKey(msgRC => msgRC.RecipientId);

            modelBuilder.Entity<MessageRecipientEntity>()
                .HasOne(msgRC => msgRC.Messages)
                .WithMany(msg => msg.MessageRecipient)
                .HasForeignKey(msgRC => msgRC.MessageId);
        }
    }
}
