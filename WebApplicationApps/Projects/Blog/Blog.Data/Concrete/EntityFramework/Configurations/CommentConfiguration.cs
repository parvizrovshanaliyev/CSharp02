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
            builder.Property(a => a.Text)
                .HasMaxLength(1000)
                .IsRequired();
            
            // relations
            builder
                .HasOne<Post>(i => i.Post)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.PostId);

            //seed
            //var entity = new Comment()
            //{
            //    Id = 1,
            //    PostId = 1,
            //    Text = "lorem ipsum sit amet sasj"
            //};
            //entity.SetCreatedByName("InitialCreate");
            //entity.SetModifiedByName("InitialCreate");
            //builder.HasData(entity);
        }
    }
}