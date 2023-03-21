--Write a simple stored procedure to get the total of a particular student 
--and call another stored procedure to list all the students with marks below than that student.
--Input: Student ID
--Output: Student Total (From first SP) Student2, Student3, etc (From Second SP)



select * from marks
select * from courses

create or alter procedure total_marks @id int as
begin
declare @total as int
select @total = sum(mark) from marks
where student_id = @id
exec total_marks1 @total
end

select sum(mark) from marks
where student_id = 5

create or alter procedure total_marks1 @sum int as
begin
select student_id,sum(mark) as max_marks
from marks
group by student_id having sum(mark) <= @sum 
order by sum(mark) desc
end
