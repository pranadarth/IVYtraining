--Write a C# program and display Movie information to customers, according to the genre they choose: 
--If they say, "horror" , atleast 5 horror movies must be displayed; 
--similarly if they choose 'kids' , animation and kids friendly movies should be displayed.
--Use UDF and display information on screen.

create table movies(
    movie_name nvarchar(50),
	movie_genre nvarchar(20)
)

select * from movies

insert into movies values('How to train your dragon','Kids')
insert into movies values('Frozen','Kids')
insert into movies values('Moana','Kids')
insert into movies values('Hotel Transylvania','Kids')
insert into movies values('Big Hero 6','Kids')
insert into movies values('The Conjuring','Horror')
insert into movies values('Veronica','Horror')
insert into movies values('Annabelle','Horror')
insert into movies values('Slender Man','Horror')
insert into movies values('Prey','Horror')

create or alter function movie_info(@genre nvarchar(20))
returns table as
return
select * from movies where movie_genre = @genre

select * from movie_info('Kids') 