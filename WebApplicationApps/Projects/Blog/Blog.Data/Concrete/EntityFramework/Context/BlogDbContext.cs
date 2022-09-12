using Blog.Data.Concrete.EntityFramework.Configurations;
using Blog.Data.Concrete.EntityFramework.Configurations.Identity;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace Blog.Data.Concrete.EntityFramework.Context
{
    public class
        BlogDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public const string IDENTITY_SCHEMA = "Identity";
        public const string DEFAULT_SCHEMA = "dbo";

        #region .::dbSet::.

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        #endregion

        #region Overrides of DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=.;Database=BlogProject;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
            var connectionString = "Host=localhost;Port=5432;Database=BlogProject;Username=postgres;Password=Maykradexla2019;";
            optionsBuilder
                .UseNpgsql(connectionString,
                    x => x.MigrationsHistoryTable("__efmigrationshistory", "public"))
                .ReplaceService<IHistoryRepository, LoweredCaseMigrationHistoryRepository>()
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region identity

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());

            #endregion

            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        #endregion
    }

    public class LoweredCaseMigrationHistoryRepository : NpgsqlHistoryRepository
    {
        public LoweredCaseMigrationHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
        }
        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property(h => h.MigrationId).HasColumnName("migrationid");
            history.Property(h => h.ProductVersion).HasColumnName("productversion");
        }
    }
}