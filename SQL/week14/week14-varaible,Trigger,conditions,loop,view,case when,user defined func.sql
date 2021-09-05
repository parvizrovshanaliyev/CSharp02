
/*
- view

View dediyimiz anlayis evvelceden yazilmis query-ni yadda saxlamaqdan basqa bir sey
deyil desek yanilmariq, relational db-lerde bir cox hallarda bir table
ucun query yazilmir ekseren elaqeli cedvellerden join-ler vasitesile data getirilmek-de
dir. Bele olan halda her defe tekrar tekra eyni query-leri yazmaq yerine 
yazilan query-lere uygun view-lar bir nov yeni bir cedvel yaradiriq,
lakin view ile table ortaq noqtesi select vasitesile cagrilib bir result 
dondermesidir, crud emeliyyatlarini view-da ede bilmirik hemcinin 
hazir func-larin istifadesi zamani result-da geri donen cloumn adlarini
vermek mecburiyyetindeyik

yeni p.Name as Name ve sair tipli yanasmalardan istifade edilir.

View Parametr ala bilmir.



*/
CREATE VIEW vw_LowStock AS SELECT
[Name],
Color,
SafetyStockLevel 
FROM Production.Product 
WHERE SafetyStockLevel < 50
-- 

select * from vw_LowStock


CREATE VIEW vw_PersonEmail AS SELECT
P.BusinessEntityID,p.FirstName,p.LastName,EA.EmailAddress 
FROM Person.Person AS P 
JOIN Person.EmailAddress AS EA 
ON P.BusinessEntityID=EA.BusinessEntityID

select * from vw_PersonEmail
---------------------------------------------------------------
/*
-variables

*/
--deyisen
declare @name nvarchar(50);
set @name='Resad'

declare @surname nvarchar(50)='Resad';
print @name  -- Console.WriteLine()

declare @rowCount int;
select @rowCount=count(*) from Person.Person
print @rowCount

-- cedvel
declare @Person table
(
Id int,
Name nvarchar(10),
Surname nvarchar(10)
)

insert into @Person values (1,'Resad','Resad');
insert into @Person values (2,'Elcan','Elcan');
insert into @Person values (3,'Fidan','Fidan');

select * from @Person

---------------------------------------------------------------
/*
-conditions
-- if else
-- case when
*/

declare @username nvarchar(50)='user1', @password nvarchar(50)='123User!';
declare @success nvarchar(50) = 'user login succeccful', @fail nvarchar(50)='user login failed'

if @username='user1' and @password='123User!'
begin
	print @success
end
else
begin
	print @fail
end

-- case when

--Production.Product cedveleninden color= black or yellow olanlari tercume etmelisiz .

--name as Mehsul
--color as Reng

select 
Name as Mehsul,
(

case p.Color
when 'Black' then 'Qara'
when 'Yellow' then 'Sari'
else 'Rengsiz'
end

) as Reng
from Production.Product as p
where Color='Black' or Color='Yellow' 
---------------------------------------------------------------
/*

- loop
- while condition
begin
-------tsql 
end
*/
declare @name1 nvarchar(20)='sql tutorial loop';

declare @counter int=0;

while @counter <= len(@name1)
begin
print substring(@name1,1,@counter)
set @counter=@counter+1
end
---------------------------------------------------------------
/*
- temp table
- local ve global olaraq teyin edile biler, bire-bir table
uzerindeki butun emeliyyatlari tetbiq ede bilirik, kecici olaraq yaradilan bu
cedveller connection close olarken silinirler ve bir basa bizim dbda deyil
system databases hissesinde tempDb -de yaradilir.
*/

-- local ancaq sizin connectioninzda gorunur
create table #PersonLocalTempTable  -- local temp table qarsisinda 1 eded # simvolu yazilir.
(
Id int,
Name nvarchar(50),
Surname nvarchar(50),
)

insert into #PersonLocalTempTable 
select p.BusinessEntityID,p.FirstName,p.LastName from Person.Person as p

select * from #PersonLocalTempTable


-- global butun connectionlarda gorunur
create table ##PersonGlobalTempTable  -- local temp table qarsisinda 2 eded ## simvolu yazilir.
(
Id int,
Name nvarchar(50),
Surname nvarchar(50),
)

-- local ve ya global tablelar connection close olduqdan sonra ozu silinir.
-- manual formada asagidaki kimi silinir.
use master
IF EXISTS(SELECT [name] FROM tempdb.sys.tables WHERE [name] like '#PersonLocalTempTable%') 
BEGIN
   DROP TABLE #PersonLocalTempTable;
END;
---------------------------------------------------------------
/*
- try catch
*/

begin try
insert into ##PersonGlobalTempTable (Id)
values('salam')
end try
begin catch
print 'Emeliyyatda xeta var'
end catch
---------------------------------------------------------------
/*
- user defined function

- scalar-valued bir tek deyer donderen 
- table-valued 
         - geriye query donderen
		 - geriye table deyiseni donderen 
*/
use AdventureWorks
-- scalar-valued bir tek deyer donderen 
create function GetByIdProductName
(@id int)
returns nvarchar(50)
as
begin

declare @entityName nvarchar(50);

if (exists(select * from Production.Product where ProductID=@id))
begin
select @entityName=Name from Production.Product where ProductID=@id
end
else
begin 
set @entityName='entitiy not found'
end
return @entityName
end

select dbo.GetByIdProductName(23121212)

--- table-valued 
--         - geriye query donderen
create function GetByIdProductTableValued(@id int)
returns table
as
return select * from Production.Product where ProductID=@id

select * from dbo.GetByIdProductTableValued(1)

--		   - geriye table deyiseni donderen 
alter function GetByIdProductTableValuedVar()
returns @Product table
(
Id int,
Name nvarchar(50)
)
as
begin
insert into @Product (Id,Name) values (1,'Bag')
return	
end

select * from dbo.GetByIdProductTableValuedVar()


---------------------------------------------------------------
/*
- trigger

----for|after|instead of     insert|update|delete
*/

alter trigger AddPerson_trigger1
on Person
after insert
as
begin
print 'new record added'
end

insert into Person(Id,Name,Surname) values (1,'Salam','Salamzade') 
-------------------------------------
alter trigger UpdatePerson_Trigger
on Person
after update
as
begin
print 'record updated'
end

select * from Person
update Person
set Name='aleykum Salam'
---------------------------------

alter trigger DeletePerson_Trigger
on Person
after delete
as
begin
print 'record removed'
end

delete Person
where Id=1


-- inserted
alter trigger AddPerson_Trigger
on Person
after insert 
as 
begin
select * from inserted
end
insert into Person(Id,Name,Surname) values (3,'Salam','Salamzade') 

-- deleted
alter trigger AddPerson_Trigger
on Person
after delete 
as 
begin
select * from deleted
end

delete Person
where Id=3

alter trigger UpdatePerson_Trigger
on Person
after update 
as 
begin
select * from inserted
select * from deleted
end
select * from Person

update Person
set Name='Agil',Surname='Qafarov'
where Id=3
---------------------------------------------------------------
/*

*/
create trigger CheckAge
on Customer
for insert
as
begin
if exists(select * from inserted where Age < 20)
begin
raiserror('Age 20-den kicik ola bilmez',1,1) -- arashdirmalisiz
rollback transaction -- arashdirmalisiz
return
end

end

insert into Customer values(3,'Resad','Fidan','Elcan',23)
insert into Customer values(4,'Resad','Fidan','Elcan',19)
---------------------------------------------------------------


