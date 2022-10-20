use Practice

--Write a sql query to fetch the unique cities the employees of an organization belong to.

create Table employee_info(
 emp_ID int primary key,
 emp_name nvarchar(50),
 place nvarchar(50) not null
)

insert into employee_info values(101, 'Arjun', 'Chennai')
insert into employee_info values(102, 'pranav', 'chennai')
insert into employee_info values(103, 'jyo', 'andra')
insert into  employee_info values(104, 'aksh', 'trichy')
insert into employee_info values(107,'Akash','Hyderabad')
insert into employee_info values(108,'Raj','Chennai')
insert into employee_info values(109,'Lakshmi','Bangalore')

select * from employee_info

select distinct place from employee_info

--Create a cricket player table where the country name and the person name are together the primary key

create table cricket_player(
    player_id int ,
    person_name nvarchar(30) not null,
    country_name nvarchar(20) not null
)
drop table cricket_player

select * from cricket_player

alter table cricket_player add constraint pk_cricket primary key(person_name, country_name)

--Write a sql query to display all the students who have joined the Physics course after the month of July.

create table student_info(
 student_id int primary key,
 student_name nvarchar(50) not null,
 s_doj date not null,
 course nvarchar(20) not null)

 drop table student_info

 insert  into student_info values(101, 'pranav', '08/08/2022', 'Maths')
 insert  into student_info values(102, 'priya', '08/27/2022', 'physics')
 insert  into student_info values(103, 'jyo', '07/08/2022', 'Physics')
 insert  into student_info values(104, 'arjun', '10/18/2022', 'Physics')
 insert  into student_info values(105, 'aks', '06/08/2022', 'Maths')
 insert  into student_info values(106, 'abi', '08/08/2022', 'english')

 select * from student_info where course = 'physics' and month(s_doj) >7

 --Create 2 similar tables (Students in 2 colleges) and show only the students who are aged over 21 and are studying Mathematics
  
create table class1(
 student_id int primary key,
 student_name nvarchar(50) not null,
 dept nvarchar(20) not null,
 age int not null
)
create table class2(
 student_id int primary key,
 student_name nvarchar(50) not null,
 dept nvarchar(20) not null,
 age int not null
)

--drop table class1, class2

insert into class1 values(101,'pranav','maths',20)
insert into class1 values(102,'praveen','english',22)
insert into class1 values(103,'priya','physics',21)
insert into class1 values(104,'praneet','computer',20)
insert into class1 values(105,'pranya','maths',22)
insert into class1 values(106,'arjun','maths',22)

insert into class2 values(101,'pranav','maths',21)
insert into class2 values(102,'praveen','english',20)
insert into class2 values(103,'priya','physics',21)
insert into class2 values(104,'praneet','computer',22)
insert into class2 values(105,'pranya','maths',21)
insert into class2 values(106,'arjun','maths',22)

select * from class1 where dept='maths' and age >= 21
union
select * from class2 where dept='maths' and age >= 21