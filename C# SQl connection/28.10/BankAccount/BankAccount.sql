--Write a C# program to display Account details and Customer information of users 
--(Account number, Customer name, Aadhar number, Account opened date, date of last transaction, etc) 
--whose account balance is greater than 200000. Pull information from 2 tables,
--Use UDF and display information on screen.

create table account(
    acc_no int identity(234567,1) primary key,
	acc_name nvarchar(40),
	aadhar_no bigint unique
)

insert into account values('Pranav',45678924583)
insert into account values('Priya',45677724583)
insert into account values('Akash',45678924883)
insert into account values('Shayam',456980924583)
insert into account values('Madhu',42345924583)

select * from account

create table acc_details(
    acc_no int,
	acc_opened_date date,
	last_transaction date,
	balance bigint
	foreign key(acc_no) references account(acc_no)
)

insert into acc_details values(234567,'10/10/2020','10/21/2022',250000)
insert into acc_details values(234568,'5/9/2020','10/31/2022',190000)
insert into acc_details values(234569,'1/23/2020','9/21/2022',200000)
insert into acc_details values(234570,'4/15/2020','9/29/2022',220000)
insert into acc_details values(234571,'12/25/2020','10/2/2022',200200)

select * from acc_details

create or alter function account_details(@balance bigint)
returns table as
return
select a.acc_no,a.acc_name,a.aadhar_no,ad.acc_opened_date,ad.last_transaction,ad.balance
from account a join acc_details ad on a.acc_no=ad.acc_no
where ad.balance > @balance

select * from account_details(200000) 