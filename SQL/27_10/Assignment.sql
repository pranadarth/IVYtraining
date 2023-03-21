--Create a Stored Procedure to show only the Employees working on C# in the base location of Bangalore. Display the result set with Employee ID, Name, Working Language and Base Location.

select * from employee_info
alter table employee_info add project nvarchar(30) 
update employee_info set emp_name = 'Akash' where emp_name = 'akash'
insert into employee_info values(110 ,'Sanjay', 'Hyderabad', 'java')

create procedure emp_c# 
as
select * from employee_info where project = 'C#' and place = 'bangalore'

exec emp_C#

--Create a Stored Procedure to calculate total marks and display ranks of students accordingly. Have atleast 10 students in the result set.
--Total marks should include marks from Maths, Economics, Commerce, English and Computer Science.

select * from students
alter table students add Maths int, Economics int, Commerce int, English int, Computer int
update students set Maths = 90, Economics = 87, Commerce = 93, English = 98, Computer = 90 where student_id =5
insert into  students values( 10, 'Akash', 77, 96,84, 88, 93)

create or alter procedure students_mark
as
exec student_mark

exec students_mark

create or alter procedure student_mark
as
declare @total1 table(Name nvarchar(30), Total int)
insert into @total1 select name, Maths+Economics+Commerce+English+Computer from students
select *,DENSE_RANK() over(order by Total desc)  as 'Rank' from @total1

exec student_mark

--Display students information (Name, Age, Sex, Course, Year of Study, etc). Give the Year of study as an input parameter and display only those students (If the input is 1, only show first year students.)
--Use Stored Procedure for:
--Creating a table with all the information,
--Displaying all the information,
--Showing the year of study students according to the input parameter.

select * from student_info
alter table student_info add Year int, Age int, Sex varchar(10) 
update student_info set student_name ='Abi', Year = 3 ,Age = 20, Sex = 'Female' where student_id = 106
insert into  student_info values( 110, 'Lakshmi','2022/10/21','Maths' ,1, 19, 'Female' )

create procedure student_year @year int
as
select * from student_info where year = @year

exec student_year 4

--Create a user defined function where you can calculate interest on a savings account with the formula pnr/100. If it is a checking account, calculate the interest as 5% on principal amount.

create table bank_deposite
(
 deposite_ID int identity(1001,1) primary key,
 Principle float,
 year float,
 Interest_rate float
)

Alter table bank_deposite RENAME column deposite_ID to Deposite_ID;
sp_rename 'bank_deposite.year','Period','COLUMN';
select * from bank_deposite

insert into bank_deposite values(20000, 4, 8)
insert into bank_deposite values(100000, 2, 6)
insert into bank_deposite values(50000, 5, 6)
insert into bank_deposite values(70000, 1, 10)
insert into bank_deposite values(50000, 3, 5)

create or alter function interest() 
returns @res table(ID int,Interest float) as
begin
insert into @res select Deposite_id, (principle*Period*Interest_rate/100 from bank_deposite
return 
end

select * from interest() 


--Create a table that has time from various time zones (US, UK, Dubai, Singapore, etc) Create a UDF where you set the alarm clock to 5 am if the time zone is Dubai, 6 am if it is UK and 7 am if it is any other time zone.