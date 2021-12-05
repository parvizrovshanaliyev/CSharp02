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
 3. #`Data`

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
    
 4. * `FluentApi - Mapping  `
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


5. * UnitOfWork design pattern
    * IUnitOfWork
    * UnitOfWork
       
 6. * `EF CORE CLI` 
    * Powershell : `dotnet tool install --global dotnet-ef --version 5.0.0-preview.7.20365.15`
    * Powershell last version : `dotnet tool install --global dotnet-ef`
    * 
    * create initial migration 
      * `dotnet ef migrations add InitialCreate`
      * `dotnet ef database update`
    * `Package Manager Console : visual studio` 
    * install : `Microsoft.EntityFrameworkCore.Tools`
    * 
    * create initial migration 
      * `Add-Migration InitialCreate`
      * `Update-Database`
 
 7. * `Result` : Shared/Utilities/Results
      * IResult 
      * Result 
      * IDataResult<out T> 

 8.  * `Services `
      * Abstract 
        * ICategoryService
          * GetAsync
          * GetAllAsync
          * GetAllByNonDeletedAsync
          * AddAsync
          * UpdateAsync
          * DeleteAsync
          * HardAsync
        * IPostService
          * GetAsync
          * GetAllAsync
          * GetAllByNonDeletedAsync
          * GetAllByNonDeletedAndActiveAsync
          * GetAllByCategoryAsync
          * AddAsync
          * UpdateAsync
          * DeleteAsync
          * HardAsync
      * Concrete
        * CategoryManager
        * PostManager
     
   * `Shared` / Entities / Abstract
      * GetBaseDto 
   * `Entities`
     * Dtos : 
       * AddDto
       * UpdateDto
       * ListDto
       * DataAnnotations : using System.ComponentModel.DataAnnotations;
       * [Required(ErrorMessage = "{0 is required")]
       * [DisplayName("Category Name")]
       * [MaxLength(70,ErrorMessage = "{0} should not be larger than {1} characters. ")]
       * [MinLength(3,ErrorMessage = "{0} must not be less than {1} characters.")]
       * [DisplayFormat(ApplyFormatInEditMode = true)]
       * [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
      

