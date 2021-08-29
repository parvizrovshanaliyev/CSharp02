--https://docs.microsoft.com/en-US/office/troubleshoot/access/database-normalization-description
--https://www.sqlservercentral.com/articles/database-normalization-in-sql-with-examples
/*
* Database-de normalization anlayisi umumilikde data tekrarini minimum decerecede azaltmagimiz ucun bir vasitedir.
  Tekrarlanan data elave yer demekdir ve duzgun qurulmamis database strukturu bize development zamani bir cox problem
  yarada bilerki bunlardan crud emeliyyatlari ve yaxud querylerimizi misal gostere bilerik.Normalization olan databasede
  yuxarida sadaladigimiz emeliyyatlarda daha asanlasmaqdadir.
  Ferqli menbelere gore muxtelif sayda qeyd edilsede temele olara esas 5 normalizasiya qaydasi var
  bunlarin hamisi tetbiq edilmese bele yeni ehtiyyaca gore mutleq sekilde tetbiq edilen zaman sirasina bir birinden ustunluk
  derecesine fikir verilmelidir.
*
* Normalizasiya olmadan bir cedvel uzerinden numnune getirsek data tekrarlanmasini aydin gore bilerik
*
* book -
*
* id  name      category1    category2
* 1   nutshell  programming  c#
*
* bu cedvelde category hissesinin bu sekilde olmasi data tekrarlanmasina yol aca bilir burdan da bu neticeye gelirik ki book cedveli icerisinde tekrarlanmanin qarshisi alina bilsin ve duzgun sekilde lazim olan kitaba uygun query yazila bilinsin deye category deye ayrica bir cedvelimiz olmali book ve category arasinda one-to-many relation qurmaliyiq
*
* category -
* id name
* 1  programming
* 2  sql
*
* book -
*
* id  name          categoryId    
* 1   nutshell      1
* 2   sql Tutorials 2
*
* Ilk once 1.ci normalizasiya qaydasinda data tekrarlanmasina baxdiq bes meseleni birazda qelizlesdirsek meselen
*
* book -
*
* id  name      category1    category2 userId  username 
* 1   nutshell  programming  c#             1  Parviz
*
* normalizasiya olunmamis yuxaridaki cedvelde crud emeliyyatlarinda problem yaranacaq
  her defe eyni usere gore yeni kitab elave edilecek
* user silinmesi zamani kitabda silinecek ve sair 1.ci normalizasiya qaydasina gore burada book user category
  cedvelleri arasinda one-to-many(1-in coxa ) relation olmalidir.
*
* 2.ci normalizasiya qaydasina esasen 1-de qeyd edildiyi uzre data tekrarinin qarshisinin alinmasi ucun bir biri ile
  elaqeli cedvellerde relation ortaq goturule bilecek sutun uzerinden qurulur yeni book cedvelinde olan id sutunun deyeri
  user table-da BookId deye saxlanilmalidir.
*
* 3.cu normalizasiya qaydasina esasen ise book ve category arasinda elaqe book table-da catgoryId saxlanaraq qurulmalidir
*
* 4.cu normalizasiya qaydasi ise 3.cu qaydada nezere almadigimiz problemin hell etmekdedir.lazim olanlari 
  3-e gore dizayn etdik bu halda biz
* her bir userin kitabi her bir kitabi kategoryasi olmalidir dedik olmalidir meselesi biz den teleb edilirse problem yoxdur lakin
* edilmirse dahada dinamik sekilde cedvellerimizi dizayn etmeliyik cunki her bir userin kitabinin olmasi mecburi deyil
  hetta olmazsa bi dizaynda  cedvelimiz null data ile dolacaq , bunun qarsini almaq ucun pivot table anlayisindan istifade etmeliyik
*
* user ve book table-ni userBook table ile many-to-many(coxun coxa )
*
*
*
*/