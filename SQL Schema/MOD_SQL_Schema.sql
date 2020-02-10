create database modDB
go

use modDB
go

/*skill table creation*/
create table [skill](
	[id] [bigint] IDENTITY(1,1) primary key NOT NULL,
	[name] [varchar](30) NOT NULL,
	[toc] [varchar](100) NOT NULL,
	[prerequistes] [varchar](100) NULL
)

/*user table creation*/
create table [user](
	[id] [bigint] IDENTITY(1,1) primary key NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[password][varchar] (100) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
    [last_name] [varchar](50) NOT NULL,
	[contact_number][bigint] NOT NULL,
	[reg_code] [varchar] (50) NULL,
	[role][varchar] (10) NOT NULL,
	[linkedin_url][varchar](200) NULL,
	[years_of_experience] [int] NOT NULL,
	[active][bit] NOT NULL,
	[reject][bit] NOT NULL,
	[comments][varchar](100)NULL
)

/*course table creation*/
create table [course](
	[id] [bigint] IDENTITY(1,1) primary key NOT NULL,
	[name] [varchar] (100) NOT NULL,
	[status] [bit] NOT NULL,
	[skill_id] [bigint] NOT NULL,
	[skill_name] [varchar] (30) NOT NULL,
	[mentor_id] [bigint] NOT NULL,
	[mentor_name] [varchar](50) NOT NULL,
	[mentor_years_of_exp] [int] NOT NULL,
	[fees] [float] NOT NULL,
	[commission_amount] [float] NOT NULL,
	[rating] [int] NOT NULL,
	[approved] [bit] NOT NULL,
	[duration] [int] NOT NULL 
)

/*training table creation*/
create table [training](
	[id] [bigint] IDENTITY(1,1) primary key NOT NULL,
	[course_id] [bigint] NOT NULL,
	[course_name] [varchar] (100) NOT NULL,
	[completed] [bit] NOT NULL,
	[progress] [int] NOT NULL,
	[skill_id] [bigint] NOT NULL,
	[skill_name] [varchar] (30) NOT NULL,
	[mentor_id] [bigint] NOT NULL,
	[mentor_name] [varchar](50) NOT NULL,
	[user_id] [bigint] NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[approved] [bit] NOT NULL,
	[rejected] [bit] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NULL,
	[part_one] [bit] NOT NULL,
	[part_two] [bit] NOT NULL,
	[part_three] [bit] NOT NULL,
	[part_four] [bit] NOT NULL,
	[rating] [int] NOT NULL,
	[payment_status] [bit] NOT NULL,
	[payment_id] [bigint] NULL,
	[amount_paid] [float] NULL,
	[fees] [float] NOT NULL,
	[commission_amount] [float] NOT NULL,
)

/*payment table creation*/
CREATE TABLE [payment](
    [id] [bigint] IDENTITY(12980,1) primary key NOT NULL,
    [user_id] [int] NOT NULL,
    [payment_method] [varchar](20) NULL,
    [amount_paid][float] NULL,
    [transaction_status][varchar](10) NOT NULL,
)

/*wallet table creation*/
CREATE TABLE [wallet](
	[id] [bigint] IDENTITY(23698,1) primary key NOT NULL,
	[user_id] [bigint] NOT NULL,
	[balance] [float] NOT NUll,
)

/*admin entry of user table*/
insert into [user] values 
('kaarthik.raghavan@gmail.com','kaarthik23','Kaarthikeyan','Raghavan',9884759549,808002,'admin',null,0,1,0,'')
/*admin entry of wallet table*/
insert into [wallet] values
(1,0)

/*skill add command*/
insert into skill values
('Angular','Components, Guard, Service','basic knowledge in typescript'),
('Flutter','Building layouts, Cross Platform','Basic Knowledge in Dart')

/*to view data*/
select * from [skill]
select * from [user]
select * from [course]
select * from [training]
select * from [payment]
select * from [wallet]

/*drop commands for emergency*/
--drop table [skill]
--drop table [user]
--drop table [course]
--drop table [training]
--drop table [payment]
--drop table [wallet]
--drop database modDB