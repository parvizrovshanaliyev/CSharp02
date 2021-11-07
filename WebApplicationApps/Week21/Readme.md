# Week21-7/11/21

* Heplers
-UrlHelper
    - Action
        Url.Action("index","Home",null | new{id=5}) // home/index/5
    - ActionLink
        Url.ActionLink("index","Home",null | new{id=5}) // https://localhost:5000/home/index/5
    - Content
        Url.Content("~/main.css")
    - RouteUrl
        Url.RouteUrl("Default")
    - prop: ActionContext
        Url.ActionContext property-si vasitesile gelen requeste aid melumatlari elde ede bilerik.
-HtmlHelper
    methods:
    - Html.Partial
        @Html.Partial("~/Views/Product/Index.cshtml") 
        Her hansisa view icerisinde basqa bir view render edile bilmekde ve icerisine
        controllerden parent view-a gelen model gonderile bilmekdedir.
        Esasen tekrar istifade edilecek hisseleri bu sekilde component mentiqi ile yazmaq
        elave kod tekrarininda qarsini almaqdadir.
        Yaradilacaq Partial view Views/Product/Partials/CurrentPartialName.cshtml 

        Html.Partial() methodu geriye string deyer qaytarir.
    - Html.RenderPartial
        @{Html.RenderPartial("~/Views/Product/Index.cshtml");} 

        current View-da TextWriter istifade ederek Http response yazilir, ve Partial()
        methodundan daha suretli isleyir.
        Html.RenderPartial() : void 
    - Html.ActionLink
        @Html.ActionLink("Products","Index","Product")
    - Html Form
        @Html.BeginForm()
        @Html.CheckBox("checkBox")
        @Html.TextBox("textBox")
        @Html.Display("display")
        @Html.Password("password")
        @Html.TextArea("area")
        @Html.ValidationMessage("validationMessage")

    arashdirma : Custom HtmlHelper
    properties:
    - ViewContext
    - TemData
    - ViewData
    - ViewBag
-TagHelper
    TagHelper ile HtmlHelper bir nov eyni isi kimi gorunur ve buradan sual yarana bilerki niye 
    daha cox TagHelper stifadesine ustunluk verilir? 
    Bunun cavabi olaraq deye bilerik ki , oncelikle HtmlHelpers Core texnologiyasindan da evvel 
    MVC arxitekturasinda istifade edilmeye baslayib  mahiyyet etibari ile isi Html elementleri 
    yaratmaqdir , lakin burada nezere alinmali esas mesele hal hazirda TagHelper-lerden sonra
    permormansdir deye bilerik , TagHelper istifade demek olarki bir basa pure html yazmaga benzeyir ,
    kod oxunaqliligi baximindan hemcinin html tag-lerinin elave olaraq  backend terefinden create edilmemesinden
    HtmlTagHelper-den ustun tutulur performanslidir.

    @addTagHelper * ,Microsoft.AspNetCore.MVC.TagHelpers

    -asp-action
    -asp-controller
    -asp-for
    -asp-append-version="true"
    -partial
        <partial name="~/Views/Product/Partials/ListPartial.cshtml"/>

    arashdirma : Custom TagHelpers

*Model Binding

Model Binding dediyimiz anlayis view-dan ve ya her hansisa bir apiden gelen datanin 
geldiyi route-a uygun yeni home/index ve sair controllerdeki action-da model binder mexanizmi
vasitesile bizim yazdigimiz modellere cevrilmesidir. Net Core texnologiyasi bunu arxa terefde 
gelen data tipine ve gonderilen data icerisindeki property name-e gore basa duserek cevirmekdedir, xususi
hallarda gelen data uzerinde xususi validation ve sair le birlikde cevrilmeni temin etmek ucun custom model binder
yaza bilerik.

-Form
-QueryString
    Request.QueryString
    Request.Query
-Route
    Request.RouteValues
    Tag Helper : asp-route
-Header
    Request.Headers
-Ajax



https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio
https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0
