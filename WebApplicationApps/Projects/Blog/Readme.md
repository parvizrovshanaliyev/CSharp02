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
      
 10. * `Insert, Refresh, Update and Delete with Ajax and JQuery`
        * Refactoring :
          * IEntityRepository   
            * return : Task<T> , add, update, delete
          * Services 
            * `CategoryManager`
                * `public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto dto, string createdByName)`
                * `public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto dto, string modifiedByName)`
                * `public async Task<IDataResult<CategoryDto>> DeleteAsync(int id, string modifiedByName)`
            * inject automapper to categoryManager
        * `admin`: CategoryController : Actions
            * Index
            * Refresh
            * Create
            * Update
            * Delete
        * `admin`: Views : Actions
            * Category
                * _CreatePartial
                * _UpdatePartial
                * Modal :`https://getbootstrap.com/docs/4.5/components/modal/`
        * `Ajax` :
             * `toastr https://github.com/CodeSeven/toastr`
             *  `sweetalert package https://sweetalert2.github.io/ <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>`
             * DataTable


                                //#region datatable
                                $('#entitiesDataTable').DataTable({
                                    dom:
                                        "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
                                        "<'row'<'col-sm-12'tr>>" +
                                        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
                                    buttons: [
                                        {
                                            text: 'Create',
                                            attr: {
                                                id: "btnCreate"
                                            },
                                            className: 'btn',
                                            action: function (e, dt, node, config) {
                                            }
                                        },
                                        {
                                            text: 'Refresh',
                                            className: 'btn btn-warning',
                                            action: function (e, dt, node, config) {
                                                refreshData();
                                            }
                                        }
                                    ]
                                });
                                //#endregion datatable



             * Create


                                //#region create modal
                                $(function () {
                                    const url = 'Category/Create';
                                    const modalPlaceHolderDiv = $('#modalPlaceHolder');
                                    $('#btnCreate').click(function () {

                                        // ajax. getting partial view
                                        $.get(url).done(function (response) {
                                            modalPlaceHolderDiv.html(response);
                                            modalPlaceHolderDiv.find('.modal').modal('show');
                                        });
                                    });
                                    //#region create : ajax. post
                                    modalPlaceHolderDiv.on('click',
                                        '#btnSave',
                                        function (event) {
                                            event.preventDefault();
                                            const form = $('#form');
                                            const actionUrl = form.attr('action');
                                            const data = form.serialize();
                                            $.post(actionUrl, data)
                                                .done(function (response) {
                                                    const viewModel = response;
                                                    const formBody = $('.modal-body', viewModel.partial);
                                                    modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
                                                    const isValid = formBody.find('[name="IsValid"]').val() === 'True';
                                                    if (isValid) {
                                                        modalPlaceHolderDiv.find('.modal').modal('hide');
                                                        const entity = viewModel.dto.entity;
                                                        // template literals
                                                        const newTableRowString = createNewRowStringTemplate(entity)
                                                        const newTableRowObject = $(newTableRowString);
                                                        newTableRowObject.hide();
                                                        $('#entitiesDataTable').append(newTableRowObject);
                                                        newTableRowObject.fadeIn(2500);
                                                        toastr.success(`${viewModel.dto.message}`, 'Success');
                                                    } else {
                                                        let summaryText = '';
                                                        $('#validationSummary > ul > li').each(function () {
                                                            let text = $(this).text();
                                                            summaryText = `* ${text}\n`;
                                                        });
                                                        toastr.warning(summaryText);
                                                    }
                                                });
                                        });
                                    //#endregion ajax. post
                                });
                                //#endregion create modal



             * Update
                               
                      
                                //#region update
                                $(function () {
                                const url = 'Category/Update';
                                const modalPlaceHolderDiv = $('#modalPlaceHolder');
                                $(document).on('click', '.btn-update', function (event) {
                                    event.preventDefault();
                                    const id = $(this).attr('data-id');
                                    // ajax. getting partial view
                                    $.get(url, { id: id })
                                        .done(function (response) {
                                            modalPlaceHolderDiv.html(response);
                                            modalPlaceHolderDiv.find('.modal').modal('show');
                                        })
                                        .fail(function() {
                                            toastr.error('Error!');
                                        });
                                });
                                //#region  : ajax. post
                                modalPlaceHolderDiv.on('click',
                                    '#btnUpdate',
                                    function (event) {
                                        event.preventDefault();
                                        const form = $('#form');
                                        const actionUrl = form.attr('action');
                                        const data = form.serialize();
                                        $.post(actionUrl, data)
                                            .done(function (response) {
                                                const viewModel = response;
                                                const formBody = $('.modal-body', viewModel.partial);
                                                modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
                                                const isValid = formBody.find('[name="IsValid"]').val() === 'True';
                                                if (isValid) {
                                                    modalPlaceHolderDiv.find('.modal').modal('hide');
                                                    const entity = viewModel.dto.entity;
                                                    // template literals
                                                    const newTableRowString = createNewRowStringTemplate(entity);
                                                   
                                                    const newTableRowObject = $(newTableRowString);
                                                    console.log(`newRow`);
                                                    console.log(newTableRowObject);
                                                    newTableRowObject.hide();
                                                    const currentRow = $(`[name="${entity.id}"]`);
                                                    console.log(`currentRow`);
                                                    console.log(currentRow);
                                                    currentRow.replaceWith(newTableRowObject);
                                                    newTableRowObject.fadeIn(3500);
                                                    toastr.success(`${viewModel.dto.message}`, 'Success');
                                                } else {
                                                    let summaryText = '';
                                                    $('#validationSummary > ul > li').each(function () {
                                                        let text = $(this).text();
                                                        summaryText = `* ${text}\n`;
                                                    });
                                                    toastr.warning(summaryText);
                                                }
                                            })
                                            .fail(function(response) {

                                            });
                                    });
                                //#endregion ajax. post
                                });
                                //#endregion update`



             * Refresh


                                 //#region refresh load data
                                 function refreshData() {
                                 $.ajax({
                                     type: 'GET',
                                     url: 'Category/Refresh',
                                     contentType: 'application/json',
                                     beforeSend: function () {
                                         $('#entitiesDataTable').hide();
                                         $('.spinner-border').show(1000);
                                     },
                                     success: function (response) {
                                         const data = response;
                                         console.log(data);
                                         if (data.resultStatus === 0) {
                                             let tableBody = '';
                                             $.each(data.entities,
                                                 function (index, entity) {
                                                     tableBody += createNewRowStringTemplate(entity);
                                                    
                                                 });

                                             $('#entitiesDataTable > tbody').replaceWith(tableBody);
                                             $('.spinner-border').hide();
                                             $('#entitiesDataTable').fadeIn(1400);
                                         } else {
                                             toastr.error(data.message, 'Fail!');
                                         }
                                     },
                                     error: function (error) {
                                         console.log(error);
                                         $('.spinner-border').hide();
                                         $('#entitiesDataTable').fadeIn(1000);
                                         toastr.error(error.responseText, 'Fail!');
                                     }
                                 });
                                 }
                                 //#endregion refresh load data


             * Delete
             


                        
                                 //#region deleted 
                                 $(document).on('click', '.btn-delete',
                                 function () {
                                     event.preventDefault();
                                     const id = $(this).attr('data-id');
                                     const tableRow = $(`[name=${id}]`);
                                     Swal.fire({
                                         title: 'Are you sure?',
                                         text: "You won't be able to revert this!",
                                         icon: 'warning',
                                         showCancelButton: true,
                                         confirmButtonColor: '#3085d6',
                                         cancelButtonColor: '#d33',
                                         confirmButtonText: 'Yes, delete it!'
                                     }).then((result) => {
                                         if (result.isConfirmed) {
                                             $.ajax({
                                                 type: 'POST',
                                                 dataType: 'json',
                                                 data: { id: id },
                                                 url: 'Category/Delete',
                                                 success: function (response) {
                                                     if (response.resultStatus === 0) {
                                                         Swal.fire(
                                                             'Deleted!',
                                                             `${response.message}`,
                                                             'success'
                                                         );
                                                         tableRow.fadeOut(3000);
                                                     } else {
                                                         Swal.fire({
                                                             icon: 'error',
                                                             title: 'Error!',
                                                             text: `${response.message}`
                                                         });
                                                     }
                                                 },
                                                 error: function (error) {
                                                     console.log(error);

                                                 }
                                             });

                                         }
                                     });
                                 });
                                 //#endregion

            
                                   
            * helper method
                            
                        
                                 //#region helper
                                 function createNewRowStringTemplate(entity)
                                 {
                                   const newTableRowString = `<tr name="${entity.id}">
                                                                                      <td>
                                                                                           <a class="btn text-primary btn-sm btn-update" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
                                                                                           <a class="btn text-danger btn-sm btn-delete" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
                                                                                      </td>
                                                                                      <td>${entity.id}</td>
                                                                                      <td>${entity.name}</td>
                                                                                      <td>${entity.description}</td>
                                                                                      <td>${convertFirstLetterToUpperCase(entity.isDeleted.toString())}</td>
                                                                                      <td>${convertFirstLetterToUpperCase(entity.isActive.toString())}</td>
                                                                                      <td>${convertToShortDate(entity.createdDate)}</td>
                                                                                      <td>${entity.createdByName}</td>
                                                                                      <td>${convertToShortDate(entity.modifiedDate)}</td>
                                                                                      <td>${entity.modifiedByName}</td>
                                                                                  </tr>`;
                                   return newTableRowString;
                                 }
                                 //#endregion helper


