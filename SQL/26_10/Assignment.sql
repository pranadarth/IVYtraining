--Write a query to fetch the first name and last name of a person from a table and display it together as "FULL NAME"
create table person(
    firstname nvarchar(30),
    lastname nvarchar(30)
)
select * from person

insert into person values('Kishore','kumar')
insert into person values('lakki','reddy')
insert into person values('Akshaya','Lakshmi')
insert into person values('Priya','Dharshini')

select CONCAT(firstname,' ',lastname) "Fullname"
from person


--Write a query to find all the people from a given country. (Say, If 5 people are from Delhi, 3 are from Mumbai, it should list all the 8 people) . The city, country information should be in a different table, use joins.

create table country(
    country_id int primary key,
    country_name nvarchar(30)
)

insert into country values(91,'India')
insert into country values(112,'Malaysia')

--drop table city

create table city(
    person_name nvarchar(25),
    city_name nvarchar(30),
    country_id int,
    foreign key (country_id) references country(country_id)
)
select * from city
select * from country

insert into city values('Raju','Chennai',91)
insert into city values('Pranav','Bangalore',91)
insert into city values('Rishi','Hyderabad',91)
insert into city values('Akash','Pune',91)
insert into city values('Krishnan','Mumbai',112)
insert into city values('Madhu','salem',112)
insert into city values('Shafana','coimbatore',112)

select a.person_name, b.country_name
from country b , city a where b.country_id = a.country_id
and country_name = 'India'
delete from city where city_name in('salem','coimbatore')

--Write a sql query to fetch only the first 3 letters of the city from the city table

select * from city
select SUBSTRING(city_name,1,3) as first_three_letters
from city

--Write a query to print the names of the employees and departments from the employee table with name ascending and department descending.

create table emp(
    emp_id int primary key,
    emp_name nvarchar(30),
    dept_name nvarchar(25),
    salary int
)
--drop table emp

insert into emp values(1,'Pranav','Sales',60000)
insert into emp values(2,'Raju','Accounting',50000)
insert into emp values(3,'Madhan','Marketing',60000)
insert into emp values(4,'Gayu','Human Resource',75000)
insert into emp values(5,'Akshya','Finance',80000)
insert into emp values(6,'Akash','Sales',40000)
insert into emp values(7,'Amal','Marketing',35000)
insert into emp values(8,'Amal','Sales',37000)
insert into emp values(9,'Amal','Human Resource',47000)


select * from emp

select emp_name,dept_name from emp
order by emp_name , dept_name desc


--Write a query to fetch the employee names who have salaries more than 50000 and less than 80000


select emp_name, salary
from emp
--where salary between 50000 and 80000
where salary > 50000 and salary < 80000


--Write a sql query to fetch the list of employees who draw the same salary.

select count(*),salary
from emp
group by salary

select emp_name,salary
from emp
where salary = 60000



--Write a query to fetch all students from the student table who do not study Maths and Physics

create table student(
   student_id int primary key,
   student_name nvarchar(25),
   course_name nvarchar(15),
   doj date
)
--drop table student



insert into student values (1,'Raju', 'Physics' , '8/22/2022')
insert into student values (2, 'Rahul', 'Chemistry', '2/2/2022')
insert into student values (3,'Amal', 'Maths', '11/11/2022')
insert into student values (4,'priya', 'Biology', '11/11/2022')
insert into student values (5,'Pranav', 'Physics', '8/8/2022')
insert into student values (6,'Amol', 'Physics', '10/7/2022')
insert into student values (7,'Geetha', 'Physics', '7/8/2022')
insert into student values (10,'Akshya', 'Maths','10/5/2022')
insert into student values (11,'Akshya', 'Maths','10/5/2019')
insert into student values (12,'Fatima', 'Chemistry','10/9/2022')
insert into student values (13,'Fatima', 'Chemistry','10/9/2019')


select student_name,course_name
from student
where course_name not in ('Physics','Maths')


--Write a query to fetch all students who joined after Feb 2020

select student_name,doj
from student
where doj > '2/28/2020'

--From an orders table, fetch the maximum purchase amount a salesman has made in the last 6 months.

create table orders_salesman(
    order_id int identity primary key,
    salesman_id int,
    amount int,
    sales_date date
)


insert into orders_salesman values (4,40000,'10/24/2022')
insert into orders_salesman values (5,45000,'8/20/2022')
insert into orders_salesman values (2,75000,'5/12/2022')
insert into orders_salesman values (5,25000,'4/5/2022')
insert into orders_salesman values (1,30000,'5/12/2022')
insert into orders_salesman values (1,40000,'6/22/2022')
insert into orders_salesman values (3,35000,'7/10/2022')
insert into orders_salesman values (2,32000,'8/1/2022')
insert into orders_salesman values (2,50000,'3/2/2022')
insert into orders_salesman values (3,70000,'5/9/2022')
insert into orders_salesman values (3,80000,'9/12/2022')
insert into orders_salesman values (4,20000,'7/29/2022')

--delete from orders_salesman
--where salesman_id = 5
--and amount = 40000

select * from orders_salesman

select salesman_id, amount
from orders_salesman
where sales_date > '5/1/2022'
and amount = any (select max(amount) from orders_salesman group by salesman_id)
order by salesman_id