/*
week 13
*/

/*
 -------- Store Procudure
 -- Store procudure Bizim c# -da oyrendiyimiz methodlar kimi basa duse bilerik 
 --- parametr qebul ede, qebul etmeye, deyer qaytara ve qaytarmaya biler.
 */
 --- create
   create table [Employee]
 (
 Id int primary key, --not null unique,
 FirstName varchar(25) default 'ad daxil edilmeyib',
 LastName varchar(25) default 'soyad daxil edilmeyib',
 Email varchar(25) unique,
 Fin varchar(7) unique,
 Age int check(Age>=18),
 IsDeleted bit,
 RecordDate datetime default getdate()
 )

  insert into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (1,'Hesen','Imanov','Hesen@gmail.com','1234567',26)


 /*
    Note:procudure adi db-da unique olmalidir.
    create proc procudure_name (
    ----- params
	@id int,
	@name nvarchar(50),
	@surname nvarchar(50)
	)   
	
	as
	begin
	-- procudure body TSql
	end
 */
 select * from Employee

 create proc AddEmployee(
 @id int,
 @firstName varchar(25),
 @lastName varchar(25),
 @email varchar(25),
 @fin varchar(7),
 @age int
 )
 as 
 begin
 insert into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (@id,@firstName,@lastName,@email,@fin,@age)
 end


 -- how to use
 exec AddEmployee
 @id=2,
 @firstName='Test',
 @lastName='Test',
 @email='Test',
 @fin='Test',
 @age=21
 ------ update
 alter proc AddEmployee
 (
 @id int,
 @firstName varchar(25),
 @lastName varchar(25),
 @email varchar(25),
 @fin varchar(7),
 @age int
 )
 as 
 begin
 insert into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (@id,@firstName,@lastName,@email,@fin,@age)
 end


 ---- drop

 --drop proc Procudure_Name

 -- Encryption
 create proc AddEmployee(
 @id int,
 @firstName varchar(25),
 @lastName varchar(25),
 @email varchar(25),
 @fin varchar(7),
 @age int
 )
 with encryption  ---- Encryption
 as 
 begin
 insert into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (@id,@firstName,@lastName,@email,@fin,@age)
 end

 ---- parametr almayan geriye deyer donderen proc

 -- esasen select-lerde istifade edilir

 create proc GetAllEmployee
 as
 begin
 select * from [Employee]
 end


 exec GetAllEmployee

 ----- parametr qebul eden (optinal)

 select * from HumanResources.Employee
 /*
  Yuxaridaki cedvelden istifade ederek Gender deyeri verilerse Gender deyerine uygun data verilmez ise umumi 
  data geri donen proc yaradin
 */

 create proc GetAllHumanResourcesEmployee (@Gender char(1)='M')
 as
 begin
 select * from HumanResources.Employee
 where Gender=@Gender
 end

 exec GetAllHumanResourcesEmployee @Gender='F'

 create proc AddEmployee2
 (
  @id int,
 @firstName varchar(25),
 @lastName varchar(25),
 @email varchar(25),
 @fin varchar(7),
 @age int)
 as
 begin
 insert 
 into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age)
 values
 (@id,@firstName,@lastName,@email,@fin,@age)
 end


  alter proc AddEmployee2
 (
  @id int,
 @firstName varchar(25),
 @lastName varchar(25),
 @email varchar(25),
 @fin varchar(7),
 @age int,
 @gender char(1)='M')
 as
 begin
 insert 
 into [Employee] 
 (Id,FirstName,LastName,Email,Fin,Age,Gender)
 values
 (@id,@firstName,@lastName,@email,@fin,@age,@gender)
 end