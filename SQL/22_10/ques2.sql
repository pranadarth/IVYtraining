use Practice

create table courses(
    course_id int primary key,
    course_name nvarchar(25)
)

insert into courses values(1,'Maths')
insert into courses values(2,'Chemisty')
insert into courses values(3,'Physics')
insert into courses values(4,'English')
insert into courses values(5,'Biology')

create table students(
    student_id int primary key,
    name nvarchar(25)
)

insert into students values(1,'Pranav')
insert into students values(2,'Priya')
insert into students values(3,'Akshaya')
insert into students values(4,'Gayu')
insert into students values(5,'Arjun')

create table Marks(
    student_id int,
    course_id int,
    mark int,
    foreign key (student_id) references students(student_id),
    foreign key (course_id) references courses(course_id)
)

insert into marks values(1,1,80)
insert into marks values(1,2,90)
insert into marks values(1,3,75)
insert into marks values(1,4,82)
insert into marks values(1,5,95)
insert into marks values(2,1,79)
insert into marks values(2,2,92)
insert into marks values(2,3,85)
insert into marks values(2,4,88)
insert into marks values(2,5,89)
insert into marks values(3,1,56)
insert into marks values(3,2,68)
insert into marks values(3,3,66)
insert into marks values(3,4,75)
insert into marks values(3,5,59)
insert into marks values(4,1,80)
insert into marks values(4,2,98)
insert into marks values(4,3,89)
insert into marks values(4,4,87)
insert into marks values(4,5,95)
insert into marks values(5,1,77)
insert into marks values(5,2,78)
insert into marks values(5,3,64)
insert into marks values(5,4,76)
insert into marks values(5,5,85)

select * from Marks 

select course_id, max(mark) as Highest_Marks
from Marks 
select a.name, b.course_name, c.mark from students a,courses b, Marks c where a.student_id = c.student_id 
and b.course_id = c.course_id and c.mark > 70

SELECT * FROM Marks  WHERE mark = any (SELECT MAX(mark) FROM Marks GROUP BY course_id) order by course_id

update Marks set mark = 89 where student_id=2 and course_id=5