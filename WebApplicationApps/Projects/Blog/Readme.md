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

 8. * `Services `
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
      
 10. * `Insert, Update and Delete with Ajax and JQuery`
 11.* `Identity` : `https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0`
 * Data :
     * Dependecies : `<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.8" />`
     * DbContext
     * remove :  public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
     * Inherit : IdentityDbContext<User,Role,UserClaim,UserLogin,UserRole,UserLogin,RoleClaim,,UserToken,int>
  * Entities :
      * Dependecies : `<PackageReference Include="Microsoft.Extensions.Identity.Stores" Version="5.0.8" />`
      * User : IdetityUser<int>
      * Role : IdetityRole<int>
      * UserRole : IdetityUserRole<int>
      * UserLogin : IdetityUserLogin<int>
      * UserToken : IdetityUserToken<int>
      * UserClaim : IdetityUserClaim<int>
      * RoleClaim : IdetityRoleClaim<int>
  * Data :
    *Configurations
      * User
      * Role
      * UserRole
      * UserLogin
      * UserToken
      * UserClaim
      * RoleClaim
  * Services :
      * Dependecies : `<PackageReference Include="Microsoft.AspNetCore.Identity" Version="2.2.0" />`
      * ServicesCollectionExtensions : LoadMyServices
          * services.AddIdentity<User, Role>();
  * Data :
      * Remove Database from SQL server
      * Remove Migrations folder
      * Commneted Seed Data
      * Migrations :
          * dotnet ef migrations add InitialCreate
          * dotnet ef database update

  * Services : IdentityOptions
      * ServicesCollectionExtensions : LoadMyServices


                      // user password options
                       ` options.Password.RequireDigit = true; // default true
                         options.Password.RequiredLength = 6; // deafult 6
                         options.Password.RequiredUniqueChars = 1; // default 1
                         options.Password.RequireNonAlphanumeric = true; // default true
                         options.Password.RequireLowercase = true; // default true
                         options.Password.RequireUppercase = true; //default true
                         // email options
                         // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-5.0
                         options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                         options.User.RequireUniqueEmail = true;`


        * MVC :
          * Middlewares :
            * Authentication, // who are you ?
            * Authorization,  // 403 permissions
            * SessionMiddleware :app.UseSession();
          * Service Container :
            * services.AddSession();
            * CoockieAuthentication :



                       `services.ConfigureApplicationCookie(options =>
                       {
                           options.LoginPath = new PathString("/Admin/User/Login");
                           options.LogoutPath = new PathString("/Admin/User/Logout");
                           options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
                           options.Cookie = new CookieBuilder()
                           {
                               
                               Name = "BlogProject",
                               /*
                                * Asagidaki js kodu ile web page uzerindeki cookie melumatlarini elde etmek mumkundur.
                                *
                                * {
                                *  var cookie=document.cookie;
                                *  window.alert(cookie);
                                * }
                                *
                                * Lakin http-only cookie-lere bu qeder asan reach ede bilmirik.
                                * bu tip attack-lar XSS (Cross Site Scripting) adlanir.
                                */
                               HttpOnly = true,
                               /*
                                * Cross site Request Forgery 'CSRF' attackinin qarshisini almaq ucun istifade edilir,
                                * web app-e userlerden elave kiminse her hanssa bir appden her hansisa bir userin cookie
                                * melumatindan istifade ederek request ata bilmesinin qarshisini alir.
                                */
                               SameSite = SameSiteMode.Strict,
                               /*
                                * sameAsRequest hem http hem https requestleri qebul edir .
                                * Duzgun yeni productionda olan app-da  CookieSecurePolicy.Always olmalidir. her zaman https request.
                                */
                               SecurePolicy = CookieSecurePolicy.SameAsRequest,
                           };
                           options.SlidingExpiration = true;
                           options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                           
                       });`  


          * `admin`
            * Controllers
              * UserController/Actions
                * Inject IUserService to UserController
                * Index
                * Create
                * Update
                * Delete
                * Refresh
            * Views
              * Index
              * _CreatePartial
              * _UpdatePartial
            * wwwroot
              * js/admin
                * user.js
        * Services
          * IUserService
            * GetAllAsync
          * UserManager
        * Shared
          * Localization
            * BaseLocalization
              * properties -> Custom Tool : PublicResXFileCodeGenerator (Resource: https://stackoverflow.com/questions/1333356/changing-resource-files-resx-namespace-and-access-modifier)
        * Entities
          * Dtos
            * GetBaseListDto<T>
            * UserListDto : GetBaseListDto<T>
            * CategoryListDto : GetBaseListDto<T>
            * UserAddDto
            * UserUpdateDto
        
        * `File Upload (resource : https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0)`
          * Shared


           ```<ItemGroup>
		        <FrameworkReference Include="Microsoft.AspNetCore.App" />
	          </ItemGroup>```


            * Extensions
              * DateTimeExtensions
                * FullDateTimeStingWithUnderscore
            * Helpers
              * IImageHelper > ImageHelper > UploadedImageDto
                * UploadImage
            * ServiceCollectionExtensions
              * services.AddSingleton<IImageHelper, ImageHelper>();
          * Services
            * UserService
              * Inject IImageHelper to UserService
        * Services
          * UserProfile > CreateMap<UserAddDto, User>();  CreateMap<User, UserUpdateDto>(); CreateMap<UserUpdateDto, User>();
        * Mvc
          * StartUp > UserProfile
          * UserController
            * Create   [ValidateAntiForgeryToken] // CSRF
            * GetAll   (for Refresh btn)
            * Delete   
            * Update  
        * Refactoring
          * EfRepositoryBase
            * GetAsync : remove predicate condition
            * Field : private Context >>> protected Context

        * Auth : Let's Complete Our Login Process with SignInManager and Authorize Attribute
          * Entities
            * Auth/LoginDto
          * MVC
            * Controllers
              * BaseAdminController


                            ```csharp
                            /// <summary>
                            /// All admin controllers inherit from this
                            /// </summary>
                            [Area("Admin")]
                            [Authorize] // Auth attr
                            public class BaseAdminController : Controller
                            {
                            }
                            ```

              * AuthController
                * Login
            * Views
              * Shared
                * _LoginLayout.cshtml (resource: assets/dist/login.html)
              * Auth
                * Login.cshtml
          * Services
            * IAuthService : AuthManager --> Injected SignManager
              * Login

        * Let's Add First Users While Creating Database With Fluent API Configuration
          * Fluent api hasData ( admin, editor, member)
            - User 
            - Role 
            - User Role 

        * Let's Add Our New Configurations to the Database with Migration Operations
            - remove Migrations
            - remove DataBase
            - dotnet ef migrations add InitialCreate
            - dotnet ef databse update

        * Let's Add and Activate Role Based Authorization in Our Application : role-based auth
          - [Authorize(Roles="Admin")]
          - [AllowAnonymous]
            * Home/Category/User Controllers

        * Let's Create Our Required Page for 403 - Access Denied Error
          * AuthController
            * AccessDenied

        * Let's Make Our Admin Menu Dynamic by Refreshing it as a View Component
          * MVC
            * ViewComponents
              * LeftSideBarViewComponent.cs - inherit ViewComponent - injected SignInManager<User>
                * Method : InvokeAsync
            * Models 
              * UserWithRolesViewModel
            * Views / Shared / Components
              * LeftSideBar / Default.cshtml - @model UserWithRolesViewModel
         
        * Let's Revise User Menu on TopBar as a ViewComponent
          * MVC
            * ViewComponents
              * DashboardUserTopBarViewComponent.cs - inherit ViewComponent - injected SignInManager<User>
                * Method : InvokeAsync
            * Models 
              * UserViewModel
            * Views / Shared / Components
              * DashboardUserTopBar / Default.cshtml - @model UserViewModel

        * Let's Complete Our Logout Process with SignInManager
          * AuthController
            * Logout => await _signInManager.SignOutAsync();

        * Let's Create UpdateProfile View and Action
          * UserController
            * UpdateProfile

        * Shared / Extensions / EnumExtensions : GetDisplayName
        * Let's Create Our ChangePassword View and Action
          * UserController
            * ChangePassword
          * DTO/ UserChangePasswordDto
          * Services 
            * ServiceCollectionExtensions
              * services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            * UserService 
              * Task<IResult> ChangePasswordAsync(UserChangePasswordDto dto);
            * UserManager
              * injected private readonly IHttpContextAccessor _httpContextAccessor;     


