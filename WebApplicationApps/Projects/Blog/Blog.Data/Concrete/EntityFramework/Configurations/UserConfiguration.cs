using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(a => a.Id);// primary key
            builder.Property(a => a.Id).ValueGeneratedOnAdd();// auto incremented
           
            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();  

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Username)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(a => a.Username)
                .IsUnique();

            builder.Property(a => a.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(a => a.Email)
                .IsUnique();
            builder.Property(a => a.PasswordHash)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
            builder.Property(a => a.Bio)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(a => a.Avatar)
                .HasMaxLength(250)
                .IsRequired();
            // relations
            builder
                .HasOne<Role>(i => i.Role)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.RoleId);

            // seed 
            var entity = new User()
            {
                Id = 1,
                RoleId = 1,
                FirstName = "System",
                LastName = "User",
                Username = "system.user",
                Email = "system.user@gmail.com" ,
                Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
            };
            entity.SetCreatedByName("InitialCreate");
            entity.SetModifiedByName("InitialCreate");
            entity.SetEmailConfirmed(true);
            entity.SetPassword("system@.@user");

            builder.HasData(entity);
        }
    }
}