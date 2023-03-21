Use Practice

Create Table officeData
(
 EmpId bigInt unique,
 EName nvarchar(30),
 Designation nvarchar(30),
)
drop table OfficeData

select * from officeData order by EName

insert into officeData values(100123,'Pranav','Trainee')
insert into officeData values(100324,'Koushik','Lead')
insert into officeData values(100941,'Akshya','Software Engineer')
insert into officeData values(100681,'Bala','Architech')
insert into officeData values(100542,'Nivi','Software Engineer')

create or alter procedure EditOfficeData @eId BigInt, @name nvarchar(30), @Desig nvarchar(30)
as
update officeData set Designation = @Desig, EName = @name where EmpId = @eId

create or alter procedure DeleteOfficeData @eId BigInt
as
Delete officeData  where EmpId = @eId

exec EditOfficeData  100131, 'Pranadarth', 'Trainee'
exec DeleteOfficeData 100344
