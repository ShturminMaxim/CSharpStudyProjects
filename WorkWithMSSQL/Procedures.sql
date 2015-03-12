use library
go

--creating procedure
--create procedure MyFirstprocedure 
--as
--select *
--from Books

----for changing procedure
--alter procedure MyFirstprocedure 
---- for securing request -> with encryption
--as
--select *
--from Books


--procedure with parameters


--alter procedure MyFirstprocedure 
----parameter "name"
--@name nvarchar(50),
--as
--select @id = id
--from Books
--where Name like @name

----exec with parameter
--exec MyFirstprocedure '%матем%'

----------------------------
--alter procedure MyFirstprocedure 
----parameter "name"
--@name nvarchar(50),
--@id int output
--as
--select @id = id
--from Books
--where Name like @name

----declare variable, set value for it
--declare @id int
--set @id = 0
----execute Procedure and save output value in variable @id
--exec MyFirstprocedure '%матем%', @id output
--select @id

-----------------------------
--alter procedure MyFirstprocedure 
----parameter "name" input and output
--@name nvarchar(50) output,
--@id int output
--as
--select @id = id, @name = Name
--from Books
--where Name like @name

----declare variable, set value for it
--declare @id int, @name varchar(50)
--set @id = 0
--set @name = '%матем%'
----execute Procedure and save output value in variable @id
--exec MyFirstprocedure @name output, @id output
--select @id, @name

---------------------
--alter procedure Summ
--@fNum int,
--@sNum int
--as
--declare @res int
--set @res = @fnum + @sNum
--return @res

--declare @res int
--set @res = 0
--exec @res = Summ 10, 20
--select @res

---------------------
--create procedure nFact
--@n int
--as
--	if @n = 1 or @n=0
--	begin
--		return 1
--	end
--	else
--	begin
--		return @n
--	end

--------------------------------------
--alter procedure Fact
--@n int
--as
--Declare @res int
--set @res =1
---- while cycle
--	while @n != 1
--	begin
--		set @res = @res*@n
--		set @n = @n - 1
--	end
--	return @res

--declare @res int
--exec @res = Fact 5
--select @res

--------------------------------------
--Functions
--alter function func
--(
--	@n int
--)
--returns nvarchar(50)
--as
--begin
--declare @res nvarchar(50)
--	if @n = 0
--		set @res = 'ноль'
--	else
--		if @n%2 = 1
--			set @res =  'нечетное'
--		else
--			set @res =  'четное'
--return @res
--end

---first Execute variant
--declare @result nvarchar(50)
--exec @result = func 2
--select @result

----second execution variant
--select dbo.func(2)

--create function cBooks(@name nvarchar(50))
--returns int
--as
--begin
--	declare @c int
--	set @c = 0
--	select @c = count(Books.Id)
--	from Books inner join Categories on Books.Id_Category = Categories.Id
--	where Categories.Name = @name

--	return @c
--end

--select dbo.cBooks('Visual Basic')


--function with multiple requests
--create function Test()
--returns @tbAuthor table ( name1 nvarchar(50), count1 int)
--as
--begin

--declare @temp table (name2 nvarchar(50), count2 int ) 

--insert @temp
--select Authors.FirstName + ' ' + Authors.LastName , count(Books.Id)
--from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join T_Cards on T_Cards.Id_Book = Books.Id
--group by Authors.FirstName, Authors.LastName

--insert @temp
--select Authors.FirstName + ' ' + Authors.LastName, count(Books.Id)
--from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join S_Cards on S_Cards.Id_Book = Books.Id
--group by Authors.FirstName, Authors.LastName

--insert @tbAuthor
--select t.name2, sum(t.count2)
--from @temp as t
--group by t.name2

--return 
--end

--select *
--from dbo.Test()