using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region Implementation of IEntityTypeConfiguration<Category>

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(i => i.Id); // primary key
            builder.Property(i => i.Id).ValueGeneratedOnAdd(); // auto increment

            builder.Property(i => i.Name)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasMaxLength(500)
                .IsRequired();

            // seed
            //var entities = new List<Category>()
            //{
            //    new()
            //    {
            //        Id = 1,
            //        Name = "C#",
            //        Description = "C#"
            //    },
            //    new()
            //    {
            //        Id = 2,
            //        Name = "C++",
            //        Description = "C++"
            //    },
            //    new()
            //    {
            //        Id = 3,
            //        Name = "JavaScript",
            //        Description = "JavaScript"
            //    }
            //};
            //entities.ForEach(i => {
            //    i.SetCreatedByName("InitialCreate");
            //    i.SetModifiedByName("InitialCreate");
            //});
            //builder.HasData(entities);
        }

        #endregion
    }
}