--SQL is a standard language for storing, manipulating and retrieving data in databases.
--Our SQL tutorial will teach you how to use SQL in: MySQL, SQL Server, MS Access, Oracle, Sybase, Informix, Postgres, and other database systems.


--1. Sql Serverin install olunmasi 
--https://go.microsoft.com/fwlink/?linkid=866658

--2. Sql Server Sample DataBase
--https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2016.bak
--https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2017.bak

--3. use sonra dataBase name yazilmasi vasitesile query yazilacaq db-ya kecid ede bilerik
use [AdventureWorks]

--+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
-- Select vasitesile DB da movcud olan her hansi bir cedvelden datalari oxuya bilirik.
--SELECT column1, column2, ...
--FROM table_name;
/*
 Select ifadesinden sonra * cedvelin butun sutunlarini,
 Select Name xususi ile qeyd edilen sutun adi spesifik datalari getirmek ucun istifade eduilir.

 FROM keywordu emeliyyati query-ni hansi cedvelde aparacigimizi bildirmek ucun istifade edilir.
 Tsql de yazilan * yeni cedvelin butun datalarinin getirilmesi zaman olaraq gecikmelere sebeb ola biler 
 onun ucun C# da istifade eden zaman Dtolar vasitesile spesifik datalari getirmeliyik.
*/
select * from Person.Person
select FirstName from Person.Person

/*
Task:
Production.Product 
--ProductId
--Name
--ProductNumber
--Color
*/
select [ProductId],[Name],[ProductNumber],[Color] from Production.Product
----------------------------------------------------
/*
Sutunlarin yeniden adlandirilmasi, birlesdirilmesi  ve as keyword

*/
select Title,Firstname,LastName from Person.Person
select Title,Firstname+' '+LastName from Person.Person
select Title,Firstname+' '+LastName as Fullname from Person.Person
------------------------------------------------------------------
/*
Querylerimizde Top keyword-un istifade edilmesi
*/

select * from HumanResources.Employee

select top(10) * from HumanResources.Employee

-------------------------------------------------------------------
/*
Querylerimizde where condition keyword-un istifade edilmesi
*/
-- Cedvelde PersonType deyeri== 'EM'
select * from Person.Person

-- conditions
select * from Person.Person
where PersonType='EM'

-- && , || operatorlari
-- and , or
select * from Production.Product
where Color='Black' and SafetyStockLevel=500

-- <
-- >
-- >=
-- <=
-- !=

/* Task
--Color deyeri Black ve ya Yellow olan ilk 10 datani getiren sql query yazin
--Colo deyeri Multi olan datalarin StandartCost deyeri 6-dan boyuk olanlarin 
  Id,Color,Name,	 ve ProductNumber deyerlerini birlesdirirek getiren sql query yazin
-- ListPrice deyeri 0-dan boyuk olan datalarin toplam sayinin 10% ne beraber gelen datalari getiren sql query yazin.
*/

select top(10) 
* 
from Production.Product
where 
Color='Black' or Color='Yellow'

select 
ProductID as Id,
Color +', '+ [Name]+', '+ ProductNumber as [ Color Name ProductNumber] 
from Production.Product
where 
Color = 'Multi' and StandardCost>6

select top(10) percent 
ProductID as Id,
Color +', '+ [Name]+', '+ ProductNumber as [ Color Name ProductNumber] 
from Production.Product
where 
ListPrice > 0

-----------------------------------------------------------------------
/*
--Like keyword
-- bu keyword vasitesile daha advance searc ede bilerik meselen A ile baslayanlari getir ,
-- icerisinde 129 olanlari getir yeni where sertinde biz yuxaridaki oyrendiklerimize esasen 
-- esasen sabit deyerlerle isleyirdik like vasitesile sabit olmayan melumatlar esasinda condition qura bilerik.

 Name='%a' bu Name sutunundaki deyerlerin evvelini onemsemeden icerisinde 'a' olanlari getirecek
 Name='a%' bu Name sutunundaki deyerlerin evveli 'a'  olanlari getirecek
 Name='%a%' bu Name sutunundaki deyerlerin icerisinde  'a'  olanlari getirecek
 Name='_a' bu Name sutunundaki deyerlerin ilk xarakteri ne olur olsun ikinci  'a'  olanlari getirecek
*/

select 
* 
from Production.Product
where 
ProductNumber like '%1'

/*Task like
-- HumanResource.Employee
-- NationalIDNumber sutunu icerisinde 96 olan
-- JobTitle deyeri ReSearch ile baslayan
-- Gender M olan 
-- iscilerin getirilmesi.

-- Sales.SalesOrderDetail 
-- ProductID deyeri 100-den boyuk 1000-den kicik
-- CarrierTrackingNumber son iki deyeri 'AE'
-- sifaris detallarinin getirilmesi.
*/

-----------------------------------------------------------------------
/*
-- In (daxil) | Not In(xaric)
*/

select * from Production.Product
where ProductNumber
in (
'BA-8327',
'AR-5381',
'BA-8327',
'BE-2349',
'BE-2908',
'BL-2036',
'CA-5965')

select * from Production.Product
where ProductNumber
not in (
'BA-8327',
'AR-5381',
'BA-8327',
'BE-2349',
'BE-2908',
'BL-2036',
'CA-5965')

-----------------------------------------------------------------------
/*
-- oder by
*/

select * from Production.Product
where ProductNumber
in (
'BA-8327',
'AR-5381',
'BA-8327',
'BE-2349',
'BE-2908',
'BL-2036',
'CA-5965')
order by ProductNumber asc

select * from Production.Product
where ProductNumber
in (
'BA-8327',
'AR-5381',
'BA-8327',
'BE-2349',
'BE-2908',
'BL-2036',
'CA-5965')
order by ProductNumber desc

-----------------------------------------------------------------------
/*
-- group by
*/
select * from Production.Product
where Color is not null


select Color,Sum(SafetyStockLevel),AVG(ListPrice) from Production.Product
where Color is not null
group by Color
/*
-- group by having
*/
select Color,Sum(SafetyStockLevel),AVG(ListPrice) from Production.Product
group by Color
having Color is not null

select Color,Sum(SafetyStockLevel),AVG(ListPrice) from Production.Product
where Color is not null
group by Color
having Color != 'Black'

-----------------------------------------------------------------------
/*
-- distinct
*/

select * from Production.Product

select distinct Color from Production.Product

-- SalesOrderDetail cedvelinden productIdlerinin tekrarsiz sekilde getirilmesi 
-- ve Product cedvelinden hemin id deyerlerine beraber datalarin getirilmesi
select * from Sales.SalesOrderDetail

select distinct ProductID from Sales.SalesOrderDetail

select * from	Production.Product
where 
ProductID 
in (select distinct ProductID from Sales.SalesOrderDetail)

-----------------------------------------------------------------------
/*
-- between
*/

select * from	Production.Product
where 
ProductID >=1 and ProductID<=500

select * from	Production.Product
where ProductID between 1 and 500

-----------------------------------------------------------------------
/*
-- Relational DB 
*/

/*
-- Inner Join
-- Relational cedvellerimizde uygun sutunlara gore cedvellerimizi birlesdirmeye yarayir her iki cedvelded eyni deyer olmalidir.
*/
--SELECT column_name(s)
--FROM table1
--INNER JOIN table2
--ON table1.column_name = table2.column_name;

select * from Person.Person
select * from HumanResources.Employee

select person.FirstName, employee.Gender from Person.Person as person
inner join HumanResources.Employee as employee
on person.BusinessEntityID = employee.BusinessEntityID

/*
-- Left Join
-- Relational cedvellerimizde uygun sutunlara gore cedvellerimizi birlesdirmeye yarayir,
   eyni deyer iki cedvelde olmasa bele yeni null olarsa bele datani getire bilerik.
*/

select person.FirstName, employee.Gender from Person.Person as person
left join HumanResources.Employee as employee
on person.BusinessEntityID = employee.BusinessEntityID

/*
Task 
Production.Product , Sales.SalesOrderDetail cedvellerinden istifade ederek Color-a gore qruplasdirilmis 
Productlarin ve onlarin UnitPrice-larinin cemini getiren query yazin. 
*/

select p.Color,sum(p.ProductID) as ProductCount, sum(s.UnitPrice) as Unitprice from Production.Product as p
left join Sales.SalesOrderDetail as s on p.ProductID=s.ProductID
group by p.Color

/*
-- Right Join
-- Relational cedvellerimizde uygun sutunlara gore cedvellerimizi birlesdirmeye yarayir,
   eyni deyer iki cedvelde olmasa bele yeni null olarsa bele datani getire bilerik.
*/

select * from Sales.SalesPerson sp
right join Person.Person p
on sp.BusinessEntityID=p.BusinessEntityID

/*
-- subQuery
*/

select * from Person.Person p
inner join HumanResources.Employee e on p.BusinessEntityID=e.BusinessEntityID


select 
p.BusinessEntityID,
p.FirstName,
(select BirthDate from HumanResources.Employee e where e.BusinessEntityID=p.BusinessEntityID) BirthDate
from Person.Person p

/*
-- fullJoin
*/


/*
-- Task 
Production.Product,
Production.ProductSubcategory,
Production.ProductCategory    

cedvellerinden istifade ederek  asagidaki kimi resultin getirilmesi ucun query yazin
-- ProductId
-- Name
-- CategoryName
-- SubCategoryName
-- ListPrice  
*/

select 
p.ProductID,
p.Name as productname,
c.Name as category,
sub.Name as subcategory,
p.ListPrice
from Production.Product p
inner join Production.ProductSubcategory sub on p.ProductSubcategoryID=sub.ProductSubcategoryID
inner join Production.ProductCategory c on c.ProductCategoryID=sub.ProductCategoryID

select 
p.Name ,
c.Name as category,
sub.Name as subcategory,
Sum(p.ProductID),
sum(p.ListPrice)
from Production.Product p
inner join Production.ProductSubcategory sub on p.ProductSubcategoryID=sub.ProductSubcategoryID
inner join Production.ProductCategory c on c.ProductCategoryID=sub.ProductCategoryID
group by c.Name, sub.Name


select 
productname,
category,
subcategory,
Sum(ProductID),
sum(ListPrice)
from(select 
p.ProductID,
p.Name as productname,
c.Name as category,
sub.Name as subcategory,
p.ListPrice
from Production.Product p
left join Production.ProductSubcategory sub on p.ProductSubcategoryID=sub.ProductSubcategoryID
left join Production.ProductCategory c on c.ProductCategoryID=sub.ProductCategoryID) ResultTable
group by productname, category, subcategory
having category is not null
order by category, subcategory