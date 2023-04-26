# Week19-24/10/21

 * Network nedir ?
 2 ve ya daha artiq device-in bir biri ile resource-larini
 paylasmaq meqsedile birbirine baglanmasidir.

 Device-lar arasinda network  Ethernet, Fiber ve ya Wireless vasitesile temin edile biler.

 
 * Network Protocol-u nedir ?

 yuxarida sadalanan device-lar arasinda elaqe vasitelerinden elave olaraq,
 birbirine baglanan devicelar hemcinin bir birini basa duse bilmelidir,
 bu ise network protocol/ standartlari vasitesile temin edilir.

 *  OSI - Open system interconnection
 

 * OSI referans modeli
 *
 * 7. Application layer
 * 6. Presentation layer
 * 5. Session layer
 * 4. Transport layer
 * 3. Network layer
 * 2. Datalink layer
 * 1. Physical layer
 

 * IP nedir ?

 umumilikde number bir deyerdir.
 OSI-de Network layerin protokoludur.
 Deyistirile bilir.
 Network device-larini mueyyenlesdirmek ucun istifade edilir.
 Bir networkde her bir device ayrica ip address-e sahib olmaqdadir.


 * DNS nedir ?

 Domain name system

 www.google.com : 172.217.17.164
 www.facebook.com : 185.60.216.35

 yuxarida gosterilen www.google.com addressi device-in basa duse bileceyi formaya
 yeni IP-ye ceviren protokol-dur.

 Ip address 2 yere bolunur network ve host

 host ip addressin sonuncu hissesine deyilir . 
  

 * Request,
 * Response,
 * Client,
 * User,
 * Server ,
   -IIS : Internet Information Services
   -Kestrel : Asp.net core daxilinde gelmektedir.
   -Ngnix : Ubuntu/Linux (Ngnix with Kestrel)
   -Apache : Linux (Apache with Kestrel)
   -Docker : Icerisine istenilen server yukleyib appi dockerde up ede bilirik.  

 *  Hosting,

 * Http Protocol
    - Get,                -Select
    - Post,               -Create
    - Put,                -Update
    - Delete,             -Delete
    - Head,
    - Trace,
    - Options,
    - Connect,
    - Patch               -Update


 * Asp.Net Core -un Asp.Net -den ferqleri 
 - Umumilikde her ikisi microsoftun mehsuludur , lakin Net.Core daha yeni texnologiya oldugundan
   normal olaraq arada structure ferqleri var , buna baxmayaraq programlasdirma dili c# her ikisindede istifade edilir.
 Ferqleri sadalasaq asagidakilara baxa bilerik:

     *Performance ,
     *Cross Platform,
     *Modular Structure,
     *Dependency Injection,
     *Asynchronous operations,
     *Easy Maintenance,
     *Razor Pages

* Asp.NET Core  - Project Creation and File Structure
-Program.cs
-Startup.cs
    -Service Container
    -PipeLine - middleware
    -appsettings.json
    -Properties
        -launchsettings.json
    -Dependencies

### Resources
- [Choose an ASP.NET Core web UI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-5.0)
- [Introduction to ASP.NET Core Framework](https://dotnettutorials.net/lesson/introduction-to-asp-net-core/)
- [ASP.NET Core Tutorial](https://www.tutorialspoint.com/asp.net_core/index.htm)

