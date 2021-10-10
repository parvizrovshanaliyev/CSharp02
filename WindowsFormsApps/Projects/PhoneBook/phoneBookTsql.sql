create database PhoneBook
go
use PhoneBook
go

create table [User]
(
Id uniqueidentifier primary key,
Username nvarchar(50) unique,
Password nvarchar(50) not null
)

insert into [User](Id,Username,Password) values(newId(),'admin123','admin123!')
select * from [User]

create table Contact(
Id uniqueidentifier primary key,
[Name] nvarchar(50) not null,
Surname nvarchar(50) not null,
Number1 nvarchar(50) not null,
Number2 nvarchar(50),
Number3 nvarchar(50),
[Address] nvarchar(50),
Email nvarchar(50),
Website nvarchar(50),
[Description] nvarchar(50)
)

go

create proc CreateContactProc(
@Id uniqueidentifier,
@Name nvarchar(50),
@Surname nvarchar(50),
@Number1 nvarchar(50),
@Number2 nvarchar(50),
@Number3 nvarchar(50),
@Address nvarchar(50),
@Email nvarchar(50),
@Website nvarchar(50),
@Description nvarchar(50)
)
as
begin
insert into Contact
(
Id ,
[Name],
Surname,
Number1,
Number2,
Number3,
[Address],
Email,
Website,
[Description]
)
values
(
@Id ,
@Name ,
@Surname ,
@Number1 ,
@Number2 ,
@Number3 ,
@Address ,
@Email ,
@Website ,
@Description 
)
end


create proc UpdateContactProc(
@Id uniqueidentifier,
@Name nvarchar(50),
@Surname nvarchar(50),
@Number1 nvarchar(50),
@Number2 nvarchar(50),
@Number3 nvarchar(50),
@Address nvarchar(50),
@Email nvarchar(50),
@Website nvarchar(50),
@Description nvarchar(50)
)
as
begin
update Contact set
[Name]=@Name,
Surname=@Surname,
Number1=@Number1,
Number2=@Number2,
Number3=@Number3,
[Address]=@Address,
Email=@Email,
Website=@Website,
[Description]=@Description
where Id=@Id
end


create proc DeleteContactProc(
@Id uniqueidentifier
)
as
begin
delete Contact
where Id=@Id
end


create proc GetAllContactProc
as
begin
select * from Contact
end

create proc GetByIdContactProc(
@Id uniqueidentifier
)
as
begin
select * from Contact
where Id=@Id
end


insert into Contact
(Id ,[Name],Surname,Number1,Number2,Number3,[Address],Email,[Description])
values
(@Id ,@Name ,@Surname ,@Number1 ,@Number2 ,@Number3 ,@Address ,@Email ,@Description )