--Create a table where there are the following fields: event id, events(anniversary, conference, 
--seminar, party,etc), event date, organizer, location, total cost, etc Create a Stored Procedure to fetch 
--all the events happening in the month of (get the input from the user).Display the results on screen.
--Example: If the user inputs September, display all the events that happened in September.
--Create a UDF to calculate the events that cost the maximum money.
--Create a Stored Procedure and display on screen, the events that happened in a particular location. 
--(Get the location as input from the user)

create table event(
    event_id int identity primary key,
	event_name nvarchar(20),
	event_date nvarchar(20),
	organizer nvarchar(25),
	location nvarchar(25),
	total_cost int
)


insert into event values('Anniversary','October','Praveen','Chennai',150000)
insert into event values('Conference','September','Priya','Chennai',100000)
insert into event values('Seminar','July','Gayathri','Bangalore',50000)
insert into event values('Birthday','September','Madhu','Hyderabad',200000)
insert into event values('Anniversary','November','Akash','Hyderabad',200000)

select * from event

create or alter procedure event_month @month nvarchar(20) as
select * from event where event_date = @month
exec event_month 'September'

create or alter function event_money()
returns table  as
return
select  max(total_cost) as MaxCost from event 

create or alter procedure max_amount @amount int as
select * from event where total_cost = @amount


select * from event_money();


create or alter procedure event_location @location nvarchar(20) as
select * from event where location = @location
exec event_location 'Chennai'