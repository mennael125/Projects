create database CharityManeger
use CharityManeger
create table userLogin
(
[user_ID] int not null identity(1,1) primary key,
username nvarchar(15),
[password] nvarchar(15)
)
insert into userLogin(username,password) values ('hr','2000');
insert into userLogin(username,password) values ('vol','6600');
insert into userLogin(username,password) values ('mang','70');
create table HR
(
HR_ID int not null Primary key,
F_Name nvarchar(10),
L_Name nvarchar(30),
Phone nvarchar(15)
);
create table Volunteer
(
Vol_ID int not null identity(1,1) primary key,
F_Name nvarchar(10) not null,
L_Name nvarchar(30) not null,
Phone nvarchar(15) not null,
Degree nvarchar(50) not null,
 HR_ID int not null foreign key references HR(HR_ID)
 );
 insert into HR(HR_ID,F_Name,L_Name,Phone) values(10,'Moahmed','Ahmed','01012345678')
 insert into HR(HR_ID,F_Name,L_Name,Phone) values(20,'Asmaa','Adel','01016545678')
 insert into HR(HR_ID,F_Name,L_Name,Phone) values(30,'Mahoumed','Elsayed','01212356789')

create table Doner
(
Doner_ID int not null identity(1,1) Primary Key ,
F_Name nvarchar(10) ,
L_Name nvarchar(30) ,
Donation int not null,
Phone nvarchar(15) ,
Vol_ID int  foreign key references Volunteer(Vol_ID)
);

 create table Case_data
(
Case_ID int not null identity(1,1) primary key,
F_Name nvarchar(20) not null,
L_Name nvarchar(50) not null,
National_ID nvarchar(14) not null,
Age int not null,
Phone nvarchar(12) not null,
Adress nvarchar(100) not null,
Gander nvarchar(10) not null,
Learning nvarchar(20) not null,
Child_Number int not null,
Work_Name nvarchar(50) not null,
Work_Type nvarchar(50) not null,
Income int not null,
Expness int not null,
Debts int not null,
Vol_ID int foreign key references Volunteer(Vol_ID) not null
);
create table Case_Mang
(
CaseMang_ID int not null identity(1,1) primary key,
Vol_ID int not null foreign key references Volunteer(Vol_ID)
);
 insert into Case_Mang (Vol_ID) values (2)
 insert into Case_Mang (Vol_ID) values (3)
 insert into Case_Mang (Vol_ID) values (1)

Create table Case_Situation
( Case_SituationID int not null identity(1,1) primary key,
Case_ID int not null foreign key references Case_data(Case_ID),
Wating nvarchar(15) default null,
Accepted nvarchar(15) default null,
Refuse nvarchar(15) default null,
);

select SUM(Donation) as Total from Doner
select *from Case_data
Insert into Doner(Donation) values (-1);

Select * From Case_Situation , Case_data where Case_Situation.Case_ID=Case_data.Case_ID 

SELECT  *
FROM Case_data
INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Wating = 'Wating';

SELECT  * FROM Case_data INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Accepted = 'Accepted';
 SELECT  * FROM Case_data INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Refuse = 'Refuse'
