Use Practice

create table customers(
    cust_ID int identity(101,1) primary key,
    cust_Name nvarchar(50),
    cust_Address nvarchar(50),
    tel_num bigint,
    email_ID nvarchar(30)
)



insert into customers values('PRANAV','Chennai,India',9784566345,'pranav@gmail.com')
insert into customers values('Aks','Bangalore,India',9783566377,'akshita@gmail.com')
insert into customers values('Priya','Chennai,India',7594561245,'priya@gmail.com')
insert into customers values('Madhu','Hyderabad,India',9884339345,'madhu@gmail.com')
insert into customers values('Gayu','Chennai,India',6594346785,'gayathri@gmail.com')

select * from customers




create table items(
    item_id int identity primary key,
    name nvarchar(30),
    price float
)

insert into items values('Rice',45)
insert into items values('Dal',100)
insert into items values('Oil',600)
insert into items values('Ghee',300)
insert into items values('Milk',50)

select * from items


create table orders(
    order_id int identity(1001,1) primary key,
    customer_id int,
    date_time datetime,
    foreign key(customer_id) references customers(cust_ID)
)

insert into orders values(101,'2022-07-21 12:20:33')
insert into orders values(102,'2022-07-23 15:44:10')
insert into orders values(105,'2022-08-01 18:24:29')
insert into orders values(104,'2022-08-11 08:05:02')
insert into orders values(102,'2022-09-15 05:55:43')


select * from orders

create table order_item(
    orderitem_id int identity primary key,
    order_id int,
    item_id int,
    product_quantity_in_kgs int,
    foreign key (item_id) references items(item_id),
    foreign key (order_id) references orders(order_id)
)



insert into order_item values(1008,3,3)
insert into order_item values(1009,1,2)
insert into order_item values(1007,5,1)
insert into order_item values(1006,4,5)
insert into order_item values(1007,4,1)


select * from order_item

