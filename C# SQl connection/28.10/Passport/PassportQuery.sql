use Practice

create table passport
(
  Passport_No int primary key,
  C_Name nvarchar(30),
  Exp_date date,
  validity int,
  channel varchar(30)
)

create or Alter procedure passport_data @p_no int , @name nvarchar(30), @e_date date, @vali int, @channel varchar(30)
as
insert into passport values( @p_no,  @name , @e_date, @vali , @channel )

exec passport_data
 select * from passport
