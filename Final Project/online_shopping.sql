Use OnlineShopping


create table customers
(
 Cust_ID int identity(101,1) primary key,
 UserName nvarchar(30),
 PhoneNumber bigint,
 EmailId nvarchar(50) unique,
 PassWord nvarchar(30)
)


--drop table customers
select * from customers
insert into  customers values('Pranav',8189980381,'pranav@gmail.com','pranav@11')



create or alter procedure UserLogin @e_id nvarchar(50)
as
select PassWord from customers where EmailId = @e_id

create or alter procedure UserData @e_id nvarchar(50)
as
select UserName,PhoneNumber,PassWord from customers where EmailId = @e_id

EditCustomer  'pranav@gmail.com' , 0, 'pranav@11'

create or alter procedure EditCustomer @e_id nvarchar(50),@phone bigint,@pass nvarchar(50)
as
update customers set PhoneNumber=@phone, PassWord=@pass where EmailId=@e_id



create or alter procedure Register @name nvarchar(30),@phone bigint, @e_id nvarchar(50),@pass nvarchar(30)
as
insert into  customers values(@name ,@phone ,@e_id ,@pass )

exec UserLogin 'pranav@gmail.com'
exec Register 'Priya',9394678990,'priya@gmail.com','priya@11'

create table products
(
 prod_Id int identity primary key,
 prod_name nvarchar(50) unique,
 category nvarchar(50),
 price int,
 prod_count int,
 meta_data1 nvarchar(50),
 meta_data2 nvarchar(50),
 sale_count int default 0
)
drop table products
insert into products values('Redmi Note 5 pro','Mobile',15000,10, '6GB-Ram 64GB-Storage','Qualcomm SD636','')
select * from products

create or alter procedure addProd @name nvarchar(30), @cat nvarchar(30),@price int,@count int, @meta1 nvarchar(50), @meta2 nvarchar(50), @sale int = '0'
as
insert into  products values(@name, @cat, @price, @count, @meta1, @meta2, @sale)

exec addProd 'Realme','Mobile',10000,20, '4GB-Ram 64GB-Storage', 'Mediatek p60'
exec addProd 'Onelplus','Mobile',60000,20, '8GB-Ram 128GB-Storage', 'Mediatek D9000'
exec addProd 'Motorola','Mobile',25000,20, '6GB-Ram 128GB-Storage', 'Qualcomm SD 7+gen 1'

create or alter procedure editProd @p_id int,@price int,@count int
as
update products set price=@price, prod_count=@count where prod_id=@p_id

exec editProd 2,14000,16

create or alter procedure updateStock @p_name nvarchar(30),@stock int,@sale int
as
update products set prod_count= @stock, sale_count = @sale where prod_name = @p_name

exec updateStock 'Oneplus 9', 10, 0

create or alter procedure deleteProd @p_id int
as
delete  from products where prod_Id = @p_id

exec deleteProd 2


drop table MyCart
create table MyCart
(
 Customer_Email nvarchar(50) FOREIGN KEY REFERENCES customers(EmailId),
 ProductName nvarchar(50) ,
 Price int,
 meta_data nvarchar(50),
)

Create or alter procedure Cart @c_Eid nvarchar(30), @p_name nvarchar(50), @price int, @meta nvarchar(50)
as
insert into MyCart values(@c_Eid, @p_name, @price, @meta)

select * from MyCart
select * from MyCart where customer_Email = 'pranav@gmail.com' order by ProductName


select count(*) from MyCart where ProductName = 'OnePlus 9' and Customer_Email = 'pranav@gmail.com'

create or alter procedure deleteCart @p_name nvarchar(50),@c_email nvarchar(50)
as
delete  from MyCart where ProductName = @p_name and Customer_Email = @c_email