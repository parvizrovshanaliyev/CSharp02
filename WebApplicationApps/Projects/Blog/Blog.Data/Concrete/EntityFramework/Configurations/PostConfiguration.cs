using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(a => a.Id); // primary key
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); // auto incremented
            builder.Property(a => a.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(a => a.Content)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
            builder.Property(a => a.Date)
                .IsRequired();
            builder.Property(a => a.SeoAuthor)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(a => a.SeoDescription)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(a => a.SeoTags)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(a => a.ViewsCount)
                .IsRequired();
            builder.Property(a => a.CommentCount)
                .IsRequired();
            builder.Property(a => a.Thumbnail)
                .HasMaxLength(250)
                .IsRequired();


            // relations
            builder
                .HasOne(i => i.Category)
                .WithMany(i => i.Posts)
                .HasForeignKey(i => i.CategoryId);

            builder
                .HasOne(i => i.User)
                .WithMany(i => i.Posts)
                .HasForeignKey(i => i.UserId);

            // seed
            //var entity = new Post()
            //{
            //    Id = 1,
            //    UserId = 1,
            //    CategoryId = 1,
            //    Title = "C# 9.0",
            //    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //    Thumbnail = "Default.jpg",
            //    SeoDescription = "C# 9.0",
            //    SeoAuthor = "Admin",
            //    SeoTags = "c#, C#, C# 9.0, .Net5, ",
            //    Date = DateTime.Now,
            //    ViewsCount = 100,
            //    CommentCount = 1,
            //};
            //entity.SetCreatedByName("InitialCreate");
            //entity.SetModifiedByName("InitialCreate");
            //builder.HasData(entity);
        }
    }
}