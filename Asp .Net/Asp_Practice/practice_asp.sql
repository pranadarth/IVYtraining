exec sale

create or alter procedure sale
as
select * from sales where amount < 5000