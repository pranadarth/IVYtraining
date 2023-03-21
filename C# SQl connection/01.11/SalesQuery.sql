CREATE TABLE sales(
    id int identity primary key,
    name varchar(20),
    amount int,
    city varchar(20)
)

insert into sales values('Pranav',3000,'Chennai')
insert into sales values('Krishnan',5000,'Chennai')
insert into sales values('Priya',8000,'Bangalore')
insert into sales values('Akashya',5000,'Hyderabad')
insert into sales values('santhosh',4000,'Hyderabad')

SELECT * FROM sales


create or alter function sales_location (@location nvarchar(20))
returns table as
return
select amount,city from sales where city = @location

select * from sales_location('Chennai')

create or alter function average(@loc varchar(20))
returns @location table (average int) as
begin
declare @res table (amount int,city varchar(20))
insert into @res select * from sales_location(@loc)
insert into @location select avg(amount) from @res
return 
end

select * from average('Chennai')