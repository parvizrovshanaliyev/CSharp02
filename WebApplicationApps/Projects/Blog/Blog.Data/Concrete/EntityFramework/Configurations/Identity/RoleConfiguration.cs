using Blog.Data.Concrete.EntityFramework.Context;
using Blog.Entities.Concrete;
using Blog.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Blog.Data.Concrete.EntityFramework.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles", BlogDbContext.IDENTITY_SCHEMA);

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.NormalizedName).HasMaxLength(50);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();


            const string guid = "e654aabb-22f6-44c2-ac8b-189b01d33ebc";

            var roles = new List<Role>()
            {
                new Role
                {
                    Name = RoleConstant.Category_Create,
                    NormalizedName = RoleConstant.Category_Create.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Category_Read,
                    NormalizedName = RoleConstant.Category_Read.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Category_Update,
                    NormalizedName = RoleConstant.Category_Update.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Category_Delete,
                    NormalizedName = RoleConstant.Category_Delete.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Post_Create,
                    NormalizedName = RoleConstant.Post_Create.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Post_Read,
                    NormalizedName = RoleConstant.Post_Read.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Post_Update,
                    NormalizedName = RoleConstant.Post_Update.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Post_Delete,
                    NormalizedName = RoleConstant.Post_Delete.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name =RoleConstant.User_Create,
                    NormalizedName = RoleConstant.User_Create.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.User_Read,
                    NormalizedName = RoleConstant.User_Read.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.User_Update,
                    NormalizedName = RoleConstant.User_Update.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.User_Delete,
                    NormalizedName = RoleConstant.User_Delete.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Role_Create,
                    NormalizedName = RoleConstant.Role_Create.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Role_Read,
                    NormalizedName = RoleConstant.Role_Read.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Role_Update,
                    NormalizedName = RoleConstant.Role_Update.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Role_Delete,
                    NormalizedName = RoleConstant.Role_Delete.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Comment_Create,
                    NormalizedName = RoleConstant.Comment_Create.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Comment_Read,
                    NormalizedName = RoleConstant.Comment_Read.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Comment_Update,
                    NormalizedName = RoleConstant.Comment_Update.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.Comment_Delete,
                    NormalizedName = RoleConstant.Comment_Delete.ToUpper(),
                    ConcurrencyStamp = guid
                },
                new Role
                {
                    Name = RoleConstant.AdminArea_Home_Read,
                    NormalizedName = "ADMINAREA_HOME_READ",
                    ConcurrencyStamp = guid
                },
                new Role()
                {
                    Name = RoleConstant.SuperAdmin,
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = guid,
                }
            };

            int counter = 1;
            roles.ForEach(role =>
            {
                role.Id = counter;
                counter++;
            });
            builder.HasData(roles);
        }
    }
}