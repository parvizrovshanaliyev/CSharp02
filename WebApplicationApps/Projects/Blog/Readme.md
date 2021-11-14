# Blog application : Project structure

Developing a Project with N-Tier Architecture
* Data
* Entities
* Services
* Shared
* Web UI MVC (Asp.Net Core MVC)

# Code First Approach with Entity Framework Core 5.0
# Detailed Database Configuration with Fluent API
# Generic Repository Design Pattern
# Unit of Work  Design Pattern
    



`####################################################`
<br>
#`Shared`
 * Entities - Domain
   - `EntityBase`
   - `IEntity` : Repository pattern istifade zamani istifade edilecek.
 * Data - Infrastructure
   * GenericRepository Pattern 
     * IEntityRepository<T>
         - GetAllAsync
         - GetAsync
         - AddAsync
         - UpdateAsync
         - DeleteAsync
         - AnyAsync
         - CountAsync
     * EfRepositoryBase<TEntity>
       * 
     * install Microsoft.EntityFrameworkCore 
 * Extensions
   * PasswordHasher


`####################################################`
<br>
#`Entities`
 * User,
 * Role,
 * Post,
 * Category,
 * Comment


`####################################################`
<br>
#`Data`

  * Abstract : Repositories
    * IUserRepository,
    * IRoleRepository,
    * IPostRepository,
    * ICategoryRepository,
    * ICommentRepository
  
  * Concrete : Repositories
    * UserRepository,
    * RoleRepository,
    * PostRepository,
    * CategoryRepository,
    * CommentRepository

  * DbContext
    * install Microsoft.EntityFrameworkCore
    * install Microsoft.EntityFrameworkCore.SqlServer
    * install Microsoft.EntityFrameworkCore.Design
    * BlogContext
      * DbSet
      * override OnConfiguring()
        * connectionString: optionsBuilder.UseSqlServer(@"connectionString")
      * override OnModelCreating()
        * modelBuilder.ApplyConfiguration(new UserConfiguration());
    
  * FluentApi - Mapping
    * IEntityTypeConfiguration
      * UserConfiguration,
        * builder.HasData -> Seed
      * RoleConfiguration,
        * builder.HasData -> Seed
      * PostConfiguration,
        * builder.HasData -> Seed
      * CategoryConfiguration,
        * builder.HasData -> Seed
      * CommentConfiguration
        * builder.HasData -> Seed



  * UnitOfWork design pattern
    * IUnitOfWork
    * UnitOfWork
                

  * EF CORE CLI 
    * create initial migration 
      * `dotnet ef migrations add InitialCreate`
      * `dotnet ef database update`
        
 

 