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
  
    ![UnitOfWork](https://user-images.githubusercontent.com/44087592/145341493-9c120be7-e264-4e07-9ad2-a67cb4b01151.png)

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
      * Dependencies
        * install AutoMapper lib
      * AutoMapper / Profiles
        * Profile
          * CreateMap<>
      * Extensions
        * ServiceCollectionExtensions
          * method : LoadMyServices
            *  services.AddDbContext<BlogContext>();
            *  services.AddScoped<IUnitOfWork, UnitOfWork>();
            *  services.AddScoped<ICategoryService, CategoryManager>();
            *  services.AddScoped<IPostService, PostManager>();
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
      
 9.  * `MVC`
        * add reference Service layer
        * `install  AutoMapper.Extensions.Microsoft.DependencyInjection`
        * `install  Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 5.0.12`
        * `Startup`
          * `ContainerService`
            * method: ConfigureService
              * `services.LoadMyService();`
              * `services.AddAutoMapper(typeof(CategoryProfile), typeof(PostProfile);`
              * `services.AddControllersWithViews().AddRazorRuntimeCompilation();`
          * `Pipeline`
            * method : `Configure`
              * app.UseEndpoints
                * `endpoints.MapAreaControllerRoute(
                  name:"Admin",
                  areaName:"Admin",
                  pattern:"Admin/{controller}/{action=Index}/{id?}");`
                * 
                * endpoints.MapDefaultControllerRoute();
              * `env.IsDevelopment()`
                * `app.UseStatusCodePages();`
              * `app.UseStaticFiles();` 
              *
        * `Controllers `
          * HomeController
        * `Views`
          * Home
            * Index.cshtml
          * Shared
            * Add Razor Layout : `_Layout.cshtml`
          * Razor View Start : `_ViewStart.cshtml`
            * `@{
              Layout = "_Layout";
              }`
          * Razor View Import :` _ViewImports.cshtml`
            * `@addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
        * `Areas  / Admin`
          * `Controllers` - attr : `[Area("Admin")]`
            * HomeController
            * CategoryController
          * `Views`
            * Home
                * Index.cshtml
            * Category
                * Index.cshtml : 
              
                  * template - datatable `https://datatables.net/`
                  * DataTables Custom Button: `https://datatables.net/extensions/buttons/examples/initialisation/custom.html`
                  * DataTables Bootstrap 4 Button: `https://datatables.net/extensions/buttons/examples/styling/bootstrap4.html`
                  * Custom Button Configurations : 
                  
                                ` $(document).ready(function() {
                                        $('#entitiesDataTable').DataTable( {
                                            dom:
                                                "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
                                                "<'row'<'col-sm-12'tr>>" +
                                                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
                                                    buttons: [
                                                        {
                                                            text: 'Create',
                                                            className:'btn',
                                                            action: function ( e, dt, node, config ) {
                                                                alert( 'Button create' );
                                                            }
                                                        },
                                                        {
                                                            text: 'Refresh',
                                                            className:'btn btn-warning',
                                                            action: function ( e, dt, node, config ) {
                                                                alert( 'Button refresh' );
                                                            }
                                                        }
                                                    ] 
                                            } );
                                        } );`
                     scripts :
                      
                     `<script src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>`
                     `<script src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>`

                     styles :

                     `<link href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous"/>`
                     `<link href="https://cdn.datatables.net/buttons/2.1.0/css/buttons.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous"/>`
                  
                  * Error result : 
            * `Shared`
                * Add Razor Layout : _Layout.cshtml
                  * Let's Add Our Theme for Admin Area and Integrate it on Layout 
                  * [Template resource ](https://drive.google.com/file/d/1zIWs6U0uvrnpFVWXiOG8oXZmaI19HAk5/view?usp=sharing)
                  * Let's Add Required PartialView and RenderSection Sections on Admin Layout
                    * `@await Html.PartialAsync("_LayoutScriptsPartial");`
                    *` @await Html.PartialAsync("_LayoutStylesPartial");`
                    * `<partial name="_LayoutLeftSideBarNavPartial" />`
                      * NavBar Icons:
                        * Categories : `fas-fa-th-list`
                        * Posts : `fas fa-file-alt`
                        * Comments : `fas fa-comments`
                        * Roles : `fas fa-user-shield`
                        * Users : `fas fa-users`
                      
                        * [icons ](https://fontawesome.com/v5.15/icons?d=gallery&p=2&s=solid&m=free)
                      * [how-to-render-a-partial-view-in-asp-net-core](https://nitishkaushik.com/how-to-render-a-partial-view-in-asp-net-core/)
                    * `@await RenderSectionAsync("Scripts",false);`
                * Razor View Start : _ViewStart.cshtml
                    * `@{
                      Layout = "_Layout";
                      }`
                * Razor View Import : _ViewImports.cshtml
                    *` @addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
          * `wwwroot` : static files
            * assets
            * js
            * css
      

