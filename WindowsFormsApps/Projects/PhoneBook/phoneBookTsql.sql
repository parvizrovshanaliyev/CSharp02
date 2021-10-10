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