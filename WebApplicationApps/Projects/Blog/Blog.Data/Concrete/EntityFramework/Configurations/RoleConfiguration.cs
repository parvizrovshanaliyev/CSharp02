using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(a => a.Id);// primary key
            builder.Property(a => a.Id).ValueGeneratedOnAdd();// auto incremented
            builder.Property(a => a.Name)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(a => a.Description)
                .HasMaxLength(500)
                .IsRequired();


            // seed
            var entity = new Role()
            {
                Id = 1,
                Name = "Admin",
                Description = "BOSS",
            };
            entity.SetCreatedByName("InitialCreate");
            entity.SetModifiedByName("InitialCreate");

            builder.HasData(entity);
        }
    }
}