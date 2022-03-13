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

# `Shared`

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

# `Entities`

* User,
* Role,
* Post,
* Category,
* Comment

`####################################################`
<br>

3. # `Data`

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

4.
    * `FluentApi - Mapping  `
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


5.
    * UnitOfWork design pattern
    * IUnitOfWork
    * UnitOfWork

![UnitOfWork](https://user-images.githubusercontent.com/44087592/145341493-9c120be7-e264-4e07-9ad2-a67cb4b01151.png)

6.
    * `EF CORE CLI`
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

7.
    * `Result` : Shared/Utilities/Results
        * IResult
        * Result
        * IDataResult<out T>

8.
    * `Services `
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
                    * services.AddDbContext<BlogContext>();
                    * services.AddScoped<IUnitOfWork, UnitOfWork>();
                    * services.AddScoped<ICategoryService, CategoryManager>();
                    * services.AddScoped<IPostService, PostManager>();
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

9.
    * `MVC`
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
                          name:"Admin", areaName:"Admin", pattern:"Admin/{controller}/{action=Index}/{id?}");`
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
                * `@{ Layout = "_Layout"; }`
            * Razor View Import :` _ViewImports.cshtml`
                * `@addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
        * `Areas / Admin`
            * `Controllers` - attr : `[Area("Admin")]`
                * HomeController
                * CategoryController
            * `Views`
                * Home
                    * Index.cshtml
                * Category
                    * Index.cshtml :

                        * template - datatable `https://datatables.net/`
                        * DataTables Custom
                          Button: `https://datatables.net/extensions/buttons/examples/initialisation/custom.html`
                        * DataTables Bootstrap 4
                          Button: `https://datatables.net/extensions/buttons/examples/styling/bootstrap4.html`
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
                        * `@{ Layout = "_Layout"; }`
                    * Razor View Import : _ViewImports.cshtml
                      *` @addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
            * `wwwroot` : static files
                * assets
                * js
                * css

10.
    * `Insert, Update and Delete with Ajax and JQuery`
      11.* `Identity` : `https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0`

* Data :
    * Dependecies : `<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.8" />`
    * DbContext
    * remove :  public DbSet<User> Users { get; set; } public DbSet<Role> Roles { get; set; }
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

13.
    * Let's Add, Update and Delete Posts
        * Let's Create Our Post/Index Page
        * Let's Create Our Post/Add Page and Styles Field (RenderSection)
        * Let's Add the jQuery Text Editor Library called Trumbowyg to our project :
            - Resources :  https://alex-d.github.io/Trumbowyg/   , https://cdnjs.com/libraries/Trumbowyg
              ```js  
              // scripts 
              <script src="https://cdnjs.cloudflare.com/ajax/libs/trumbowyg/2.20.0/trumbowyg.min.js"></script>
              <script src="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/colors/trumbowyg.colors.min.js" integrity="sha512-4QranVVhd9HLb3yDUL6q+zlHc5mEIcUrR5pfhdyyGzsqcH9vSROL0BgN8wW47mZ1tZ44tUvFkk/JXvhfNlzvHw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
              <script src="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/emoji/trumbowyg.emoji.min.js" integrity="sha512-PPEK09bmt7tQg/qdNokvbckNVB4EqXTu+qi4X/j9XoFag6YspjU5xO/FXXCEjBxo1+Z41oOFvIyz5QkjSuTNsQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
              <script src="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/fontfamily/trumbowyg.fontfamily.min.js" integrity="sha512-ha/jXUX4sZMHEvpHLtYOIvMDK8/a8ncRhAPSmQVUx/to+04w+zUBWWZHaPQMPt6qjx94V/lbE9ZEsTsb7F+sTw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
              <script src="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/fontsize/trumbowyg.fontsize.min.js" integrity="sha512-eYBhHjpFi6wk8wWyuXYYu54CRcXA3bCFSkcrco4SR1nGtGSedgAXbMbm3l5X4IVEWD8U7Pur9yNjzYu8n4aIMA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
        
              // styles 
              <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/ui/trumbowyg.min.css" integrity="sha512-nwpMzLYxfwDnu68Rt9PqLqgVtHkIJxEPrlu3PfTfLQKVgBAlTKDmim1JvCGNyNRtyvCx1nNIVBfYm8UZotWd4Q==" crossorigin="anonymous" referrerpolicy="no-referrer" />
              <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/colors/ui/trumbowyg.colors.min.css" integrity="sha512-aE073TwNBnCl/Y99fSlH/29MS7CzKgrliM9rTVDURKiiGvapXN+hTmept74zsbcadVEzJ2RtfcyEyzySiYeJuA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
              <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.25.1/plugins/emoji/ui/trumbowyg.emoji.min.css" integrity="sha512-xpR3G7LZbpAnoUgES2Xu2Z/mK8NwejLjJpNHQtmdU36yGP2AS5kgpflPwv6vEurEeruDcghOtHkWNsOkwVx2ig==" crossorigin="anonymous" referrerpolicy="no-referrer" />
              ``` 
              ```js   
              $(document).ready(function() {
                  $('#text-editor').trumbowyg({
                      btns: [
                          ['viewHTML'],
                          ['undo', 'redo'], // Only supported in Blink browsers
                          ['formatting'],
                          ['strong', 'em', 'del'],
                          ['superscript', 'subscript'],
                          ['link'],
                          ['insertImage'],
                          ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
                          ['unorderedList', 'orderedList'],
                          ['horizontalRule'],
                          ['removeformat'],
                          ['fullscreen'],
                          ['foreColor', 'backColor'],
                          ['emoji'],
                          ['fontfamily'],
                          ['fontsize']
                      ],
                      plugins: {
                          fontsize: {
                              sizeList: [
                                  '12px',
                                  '14px',
                                  '16px'
                              ]
                          }
                      }
                  });
              });
              ```
        * Let's Add the jQuery Library named Select2 to our project
            - Resources: https://select2.org/  , https://github.com/ttskch/select2-bootstrap4-theme
              ```js 
                  // styles 
                  <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" /> 
                  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@@ttskch/select2-bootstrap4-theme@x.x.x/dist/select2-bootstrap4.min.css">
   
                  // scripts 
                  <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script> 
             
                  // Initialize select2   
                  $(document).ready(function() {
                      $('.single-select-boxes').select2({
                          theme: "bootstrap4",
                          allowClear: true, 
                          placeholder: 'Select a category',
                      });
                  });
                 
              ``` 

        * Let's Add the jQuery UI Library and the DatePicker Plugin to our Project
            - Resources: https://jqueryui.com/datepicker/ , cdnjs.com/libraries/jqueryui/
              , https://jqueryui.com/themeroller/
              ```js
                 // styles 
                 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/flick/jquery-ui.min.css" integrity="sha512-Yx7L3AmO2yN7qIM1uM0Mqx6ld35SZj7oyG/gZ668QNvBzJsvoQebhFpsl1zEYVR6jtYCpXcCmewCuhvHrjDhog==" crossorigin="anonymous" referrerpolicy="no-referrer" />
                 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/flick/theme.min.css" integrity="sha512-VWoNiZ/8gXnhL2bMWHGku9Oy67OJa3bjHMgx82nBMJMBhS+ZTGxRdyonqW3K92FuhUIn+VR4rMTyuhJ9JhUmow==" crossorigin="anonymous" referrerpolicy="no-referrer" />   
                 // scripts 
                <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js" integrity="sha512-uto9mlQzrs59VwILcLiRYeLKPPbS/bT71da/OEBYEwcdNUk8jYIy+D176RYoop1Da+f9mvkYrmj5MCLZWEtQuA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
               
                 // Initialize datePicker
                 $(document).ready(function(){
                    $('#date-picker').datepicker({
                        dateFormat: 'yy-mm-dd',
                        autoclose: true
                 });
              ```
        * Let's Create Our Post Add Dto Class and Return It to the View
        * Let's Revise Our FileHelper/UploadImage() Method
          ```cs 
          // Extension Methods 
          public static class EnumExtensions{
              public static string GetDisplayName(this Enum enumValue)
              {   var displayName = enumValue.GetType()
                      .GetMember(enumValue.ToString())
                      .First()
                      .GetCustomAttribute<DisplayAttribute>()
                      .GetName();
                  displayName ??= enumValue.ToString();
                  return displayName;
              }
          } 
         
          // Enums
          public enum ImageSubDirectoryEnum
         
          {
              [Display(Name = "Users")]
              User,
              [Display(Name = "Posts")]
              Post,
          }
          
          // Methods
          Task<IResult<FileDto>> UploadImageAsync(IFormFile file, ImageSubDirectoryEnum subDirectoryEnum, string subDirectory=default, string otherName = default);  
         
          // subDirectory ??= subDirectoryEnum.GetDisplayName(); 
         
          // otherName ??= string.Empty; 
          // if otherName is not empty, remove whitespaces , invalidChars and replace them with '-'  
         
          // string extensions
          public static string RemoveInvalidChars(this string str)
          {
              return Regex.Replace(txt, @"[^a-zA-Z0-9_]", "").Replace(" ", "_");
          }
         
          ```
        * Let's Complete Our Post Addition Process with Our Post/Add Action
            * PostUpdateDto
            * GetUpdateDtoAsync();
        * Let's Complete our Post Update Process with Our Post/Update Action
        * Let's Complete our Post Delete Process with Our Post/Delete Action
        * Let's add ntoastnotify nuget package to our project
          ```cs  
          resources :  https://github.com/nabinked/NToastNotify
          // nuget package manager
          step 1. Install-Package ntoastnotify 
          step 2. add using NToastNotify;
          step 3. services Containers : services.AddControllersWithViews().AddNToastNotifyToastr();  
          step 4. middleware : app.UseNToastNotify();
          step 5. Layout : @await Component.InvokeAsync("NToastNotify");
         
                  @await Html.PartialAsync("_LayoutScriptsPartial");
          +       @await Component.InvokeAsync("NToastNotify");      +
                  @await RenderSectionAsync("Scripts",false); 
          step 6. Inject IToastNotification to our controllers 
          step 7. PostControler : 
          TempData.Add(ResultStatus.Success.GetDisplayName(), result.Message);
           replace with
           _toastNotification.AddSuccessToast(result.Message);~~~~
         
          ```
