# Week20-31/10/21


# Controller : Action Types

    -Controller daxilinde olan Action-lar ucun evvelceden teyin edilmis geri donus tipleri vardir.
    Custom yaradilan Controller-imiz Controller class-dan inheritenca alaraq bu geri donus tiplerini 
    istifade ede bilmekdedir.
    Geri donsu tiplerini ferqlendirmeyin sebebi Bezi yerlerde View yeni .cshtml bezi yerlerde ehtiyaca gore
    saf data donderile bilmekdedir bunun ucunde ferqli ActionType-larla isleye bilme ehtiyaci yaranmaqdadir.
               

    -IActionResult
    -ViewResult
    -PartialViewResult
    -JsonResult
    -EmptyResult
    -ContentResult

  -PartialViewResult
    - .cshtml donderir esas istifade meqsedi UI-da mueyyen hissesin render olunmasidir,
    Normal ViewResult geri donerken UI -da umumi render prosesi bas verir ve sehife reload/refresh olunur.
    Partial View umumi olmadigindan sehifenin mueyyen hissesi , modal, popUP, Card ve sair oldugundan
    geri donen deyer ajax vasitesile sadece hemin hissesinin renderine sebeb olur ve anliq deyisiklikleri
    umumi sehife refresh olmadan gore bilirik.
  


# NonAction & NonController Attribute
  
Bu attr-ler vasitesile Conttrolle ve Action-a requestin qarshisini ala bilirik.
   

# View Data Migration
  
    -ViewBag
    -ViewData
    -TempData
    -Tuple
    -ViewModel

Umumilikde .cshtml Asp.Net-e aid olub sadece bu texnologiya vasitesile render edile bilmekdedir,
yeni bizim bildiyimiz enenevi css, html , js file-lari butun browser-lerde eyni qaydada render edilirdise,
programlasdirma dili ferq etmeden .cshtml Asp.net mexsus Razor view-lar sadece Asp.net le render edilmekdedir ve 
netice olaraq browserin basa duseceyi formada html-a cevrilir, Razor texnologiyasi vasitesile biz html kodlari 
daxilinde @ istifade ederek c# kodu inject ede bilirik , buda bize imkan verir ki, elimizdeki data-ni viewda istediyimiz kimi
manipulasya edek .

Controller daxilinde action-lara gore ayri ayri Razor view .csshtml file-lari Views Folderinde cari Controller 
adina sahib Folder daxilinde cari action adina uygun yaradilmaqdadir. MVC pattern Controller Action adina baxaraq basa duse
bilirki car view hansi Controllerin action-na aiddir ve gelen request handle edilerken uygun gelen View Render edilib ,
UI gonderilir .

Umumilikde Razor View ve Controller arasinda data transfer ede bilmenin bir nece yolu var .

-ViewBag Dynamic tip ile isleyir :Controller -den inheritance alindigindan 
oz controllerimiz daxilinde Her hansisa actiondan ViewBag-le datani view-a gondere bilerik.

-ViewData ile data view boxing edilerek objecte cevrilerek gonderilir.

-TempData ile data view boxing edilerek objecte cevrilerek gonderilir.
ViewData ile arasindaki ferq TemData cookie istifade etdiyinden dolayi bir Actiondan digerine yonledirme ederken,
hemin datani istifade ede bilirik yeni cookie-ye ummumiyyetle melumat yazilmasi global olaraq istifade edile biler demekdir.

-TemData ile dasinan data complex type data olarsa elave olaraq serialize edilmelidir.
- Tuple obyetinin view-a gonderilmesi
- ViewModel hazirlanmasi

# Razor

        - @ operatoru
        - Deyisnlerin yaradilmasi, oxunmasi
        - Scope mentiqi 
        - Ternary
        - If statement
        - Loop
   

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio

https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0
