use Practice

create table telephone_directory(
    id int identity primary key,
    name nvarchar(30),
    tel_number bigint unique,
    address nvarchar(30),
    profession nvarchar(25)
)

insert into telephone_directory values('pranav',9784566340,'Chennai,India','Lawyer')
insert into telephone_directory values('Arjun',9443764561,'Bangalore,India','Student')
insert into telephone_directory values('Priyanka',7514561345,'Chennai,India','Teacher')
insert into telephone_directory values('Madhan',9884039355,'Hyderabad,India','Doctor')
insert into telephone_directory values('Gayu',6594346885,'Chennai,India','Student')
insert into telephone_directory values('Akshaya',9784566345,'Chennai,India','Lawyer')
insert into telephone_directory values('Akshita',9443564567,'Bangalore,India','Student')
insert into telephone_directory values('Priya',7594561245,'Chennai,India','Teacher')
insert into telephone_directory values('Madhu',9884339345,'Hyderabad,India','Doctor')
insert into telephone_directory values('Gayathri',6594346785,'Chennai,India','Student')
insert into telephone_directory values('pranadarth',8189980381,'Chennai,India','engineer')
insert into telephone_directory values('saravanan',9441964561,'Bangalore,India','mechanic')
insert into telephone_directory values('prakash',7514528345,'Chennai,India','electritian')
insert into telephone_directory values('mohan',9884039125,'Hyderabad,India','musician')
insert into telephone_directory values('gowtham',6594156885,'Chennai,India','Student')
insert into telephone_directory values('ratha',9784566535,'Chennai,India','Lawyer')
insert into telephone_directory values('Akshara',9443543567,'Bangalore,India','Student')
insert into telephone_directory values('revathi',7594421245,'Chennai,India','Teacher')
insert into telephone_directory values('swathi',9884339435,'Hyderabad,India','scientist')
insert into telephone_directory values('kavin',6594346709,'Chennai,India','plumber')

select * from telephone_directory
select COUNT(profession) from telephone_directory

select distinct Profession from telephone_directory
order by profession desc

select * from telephone_directory where profession = 'student'
select * from telephone_directory where not profession = 'student'

select count(profession) as no_of_students from telephone_directory where profession = 'student'
select count(profession) as no_of_professionals from telephone_directory where not profession = 'student'

