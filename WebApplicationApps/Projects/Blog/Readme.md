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


