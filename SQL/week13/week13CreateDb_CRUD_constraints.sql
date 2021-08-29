/*
week 13
*/
use master

-- create database
create database SqlTutorialDatabaseExample

-- drop db
drop database [SqlTutorialDatabaseExample]

use [SqlTutorialDatabaseExample]

-- create table
 create table [Users]
 (
 Id int,
 FirstName varchar(25),
 LastName varchar(25)
 )
 -- drop table tableName

-- alter table ---------------
----  add column
      alter table [Users]
      add RecordedDate datetime

----  drop column
      alter table [Users]
      drop column RecordedDate
----- alter column
      alter table [Users]
	  alter column FirstName varchar(30)
----------- constraints
-- yaradilan cedvelllerde mueyyen qaydalar emel edilmelidir bunlardan id column her zaman unique olmasi,
-- lazim olan column-larin not null yeni required olmasi ,
-- mueyyen column-larda string bir deyer qebul edirse min ve max limit olmasi

------ not null

create table [Users]
 (
 Id int not null,
 FirstName varchar(25) not null,
 LastName varchar(25) not null
 )

 ------ unique
 /*
 -- Cedvelde olan Id deyeri ve yaxud usere aid her hansisa bir spesifik column Fin, Seriya Nomresi ve sair 
 -- database-de unique olacaq sekilde saxlanilmalidir.
 */
 create table [Users]
 (
 Id int not null unique,
 FirstName varchar(25) not null,
 LastName varchar(25) not null,
 Email varchar(25)not null unique,
 Fin varchar(7) not null unique
 )

  ------ primary key
  /*
  -- relational cedvellerde istifade edilir Primary key 
  */
  create table [Users]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) not null,
 LastName varchar(25) not null,
 Email varchar(25)not null unique,
 Fin varchar(7) not null unique
 )

 ------ foreign key
  /*
  -- relational cedvellerde istifade edilir Primary key 
  */
  

 create table [Customers]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) not null,
 LastName varchar(25) not null
 )

 create table [CustomerInfo]
 (
 Id int primary key, --not null unique,
 CustomerId int,
 ContactType tinyint not null, --1.Mobil 2.Stasionar Tel
 Number nvarchar(25) not null,
 constraint FK_CustomerInfo foreign key(CustomerId) references [Customers](Id)
 )
 ------ check
  create table [Users]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) not null,
 LastName varchar(25) not null,
 Email varchar(25)not null unique,
 Fin varchar(7) not null unique,
 Age int not null check(Age>=18)
 )

 ------ default
  create table [Users]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) default 'ad daxil edilmeyib',
 LastName varchar(25) default 'soyad daxil edilmeyib',
 Email varchar(25)not null unique,
 Fin varchar(7) not null unique,
 Age int not null check(Age>=18),
 RecordDate datetime default getdate()
 )

 ----------------------------------------------------------------------------------
 -- insert
  create table [Students]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) default 'ad daxil edilmeyib',
 LastName varchar(25) default 'soyad daxil edilmeyib',
 Email varchar(25)not null unique,
 Fin varchar(7) not null unique,
 Age int not null check(Age>=18),
 RecordDate datetime default getdate()
 )
 /*
 insert into table_name (column1,column2...) values ('',''.....)
 insert into table_name values ('',''.....)
 */
 insert into Students 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (1,'Hesen','Imanov','Hesen@gmail.com','1234567',26)

 -- update
 /*
 update table_name
 set column1='',column2=''
 where condition
 */

 update Students
 set FirstName='Hasan'
 where Id=1

 -- delete

 /*
 delete table_name
 where Id=1
 */

 delete Students
 where Id=1
