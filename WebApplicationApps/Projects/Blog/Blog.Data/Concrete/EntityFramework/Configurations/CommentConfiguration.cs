using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.ToTable("Comments");

            builder.HasKey(a => a.Id);// primary key
            builder.Property(a => a.Id).ValueGeneratedOnAdd();// auto incremented
            builder.Property(a => a.Content)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.UserId)
                .IsRequired(false);

            builder.Property(a => a.PostId)
                .IsRequired();

            // relations
            builder
                .HasOne(i => i.Post)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(i => i.User)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}