using Chats.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chats.DAL.Configurations
{
    public class ChatEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.ReceiverId).IsRequired();
            builder.Property(c => c.SenderId).IsRequired();

            builder.HasOne(c => c.Sender)
                   .WithMany(u => u.Chats)
                   .HasForeignKey(c => c.SenderId);
        }
    }
}
