--use library
--go
--Create Trigger Show_Upd_Amm

--On Books

--For Update

--As 
--	raiserror('Было изменено %d записей',0,1,@@rowcount)


--Update books

--Set books.quantity=books.quantity+5

--From press

--Where books.id_press=press.id

--and press.name like '%BHV%'

--//////////////////////////////////////////

--use Shop
--go

--Create Trigger Check_Date_trigger

--On Product

--for insert

--as
 
--Declare @InsDate date

----inserted -> temporary database
--Select @InsDate=UDB from inserted/*получаем дату товара, который добавляется
--(date_in - поле таблицы shop, в которую производится вставка данных)*/

--if (@InsDate<=getdate()-30)	/*Проверяем, не прошло ли 30 дней*/

--Begin

--	raiserror('Это слишком старый товар',0,1)
--	raiserror('Данные о товаре сохранены не будут',0,1)

--	Rollback transaction

--end

--else

--Begin
--	Print('Insert Ok!!!')
--end




--create trigger Check_cd_delete

--on cd

--for delete

--as

--Declare @SellAmm int,
--@cd_name varchar(25),
--@best_cd varchar(25)

--Select @cd_name=deleted.name from deleted/*Получаем название удаляемого диска.*/

--Declare @Svodka table (imya varchar(25), kolv int)

--insert @Svodka/*Вычитываем информацию о названиях дисков и о их популярности*/

--	select cd.name,count(id_cd) from selling,cd
--	where selling.id_cd=cd.id
--	group by cd.name


--Select @best_cd=s.imya from @Svodka s/*Находим название самого популярного диска по продажам*/
--where s.kolv=(Select max(kolv) from @Svodka)

--if(@best_cd=@cd_name)/*Проверяем совпадение названий.*/
--begin
--	raiserror('You can not delete this cd!!!',0,1)
--	rollback transaction
--end

--else

--begin
--	print ('deleting query was successfull!!')
--end


---------------------------------------
--Create Trigger Not_BHV

--On books

--Instead of Delete

--As

--Declare @BHV_id int

--Select @BHV_id=id from press where press.name ='BHV Киев'/*
--Получаем идентификатор издательства BHV Киев*/

--if (exists (select * from deleted where id_press=@BHV_id))/*Проверяем, есть ли такой идентификатор
--в удаляемых книгах.*/

--raiserror ('You can not delete BHV Киев!!!',0,1)

--else 

--commit transaction

----------------------------------------
--create trigger People_copy

--on People

--after insert

--as

--insert into copypeople 
--select * from inserted


--Написать такие триггера:
--Чтобы при взятии определенной книги, ее кол-во уменьшалось на 1.
Create trigger book_s_moving
on S_Cards
For insert
as 
Declare @id int
Select @id = Id_Book from inserted

Update Books 
set Quantity = Quantity - 1
where Books.Id = @id
-------------------------------------------
Create trigger book_t_moving
on T_Cards
For insert
as 
Declare @id int
Select @id = Id_Book from inserted

Update Books 
set Quantity = Quantity - 1
where Books.Id = @id


--Чтобы при возврате определенной книги, ее кол-во увеличивалось на 1.
alter trigger book_back
on S_Cards
For insert
as 
Declare @id int
Declare @datein date
Select @id = Id_Book from inserted
Select @datein = DateIn from inserted

if @datein is not null
	Update Books 
	set Quantity = Quantity + 1
	where Books.Id = @id

Create trigger book_t_back
on T_Cards
For insert
as 
Declare @id int
Declare @datein date
Select @id = Id_Book from inserted
Select @datein = DateIn from inserted

if @datein is not null
	Update Books 
	set Quantity = Quantity + 1
	where Books.Id = @id

--Чтобы нельзя было выдать книгу, которой уже нет в библиотеке (по кол-ву).
Create trigger book_s_check
on S_Cards
For insert
as 
Declare @id int
Declare @amount int
Select @id = Id_Book from inserted

Select @amount = Quantity from Books
where Books.Id = @id

if @amount > 0
	Update Books 
	set Quantity = Quantity - 1
	where Books.Id = @id
else
	raiserror('we dont have this book anymore',0,1)

--------------------
Create trigger book_t_check
on T_Cards
For insert
as 
Declare @id int
Declare @amount int
Select @id = Id_Book from inserted

Select @amount = Quantity from Books
where Books.Id = @id

if @amount > 0
	Update Books 
	set Quantity = Quantity - 1
	where Books.Id = @id
else
	raiserror('we dont have this book anymore',0,1)

--Чтобы нельзя было выдать более трех книг одному студенту.
Create trigger student_check
on S_Cards
For insert
as 
Declare @studentId int
Declare @amount int

Select @studentId = Id_Student from inserted
set  @amount = (Select count(Id) from S_Cards
where S_Cards.Id_Student = @studentId)

if @amount > 3
	raiserror('too many books for one student',0,1)


--Чтобы при удалении книги, данные о ней копировались в таблицу Удаленные.
create trigger book_delete
on Books
after delete
as
insert into RemovedBooks
select * from deleted

--Если книга добавляется в базу, она должна быть удалена из таблицы Удаленные.
Create trigger book_undeleting
on Books
For insert
as 
Declare @id int
Select @id = Id from inserted

delete from RemovedBooks
where Id = @id