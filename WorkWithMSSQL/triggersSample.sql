--use library
--go
--Create Trigger Show_Upd_Amm

--On Books

--For Update

--As 
--	raiserror('���� �������� %d �������',0,1,@@rowcount)


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
--Select @InsDate=UDB from inserted/*�������� ���� ������, ������� �����������
--(date_in - ���� ������� shop, � ������� ������������ ������� ������)*/

--if (@InsDate<=getdate()-30)	/*���������, �� ������ �� 30 ����*/

--Begin

--	raiserror('��� ������� ������ �����',0,1)
--	raiserror('������ � ������ ��������� �� �����',0,1)

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

--Select @cd_name=deleted.name from deleted/*�������� �������� ���������� �����.*/

--Declare @Svodka table (imya varchar(25), kolv int)

--insert @Svodka/*���������� ���������� � ��������� ������ � � �� ������������*/

--	select cd.name,count(id_cd) from selling,cd
--	where selling.id_cd=cd.id
--	group by cd.name


--Select @best_cd=s.imya from @Svodka s/*������� �������� ������ ����������� ����� �� ��������*/
--where s.kolv=(Select max(kolv) from @Svodka)

--if(@best_cd=@cd_name)/*��������� ���������� ��������.*/
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

--Select @BHV_id=id from press where press.name ='BHV ����'/*
--�������� ������������� ������������ BHV ����*/

--if (exists (select * from deleted where id_press=@BHV_id))/*���������, ���� �� ����� �������������
--� ��������� ������.*/

--raiserror ('You can not delete BHV ����!!!',0,1)

--else 

--commit transaction

----------------------------------------
--create trigger People_copy

--on People

--after insert

--as

--insert into copypeople 
--select * from inserted


--�������� ����� ��������:
--����� ��� ������ ������������ �����, �� ���-�� ����������� �� 1.
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


--����� ��� �������� ������������ �����, �� ���-�� ������������� �� 1.
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

--����� ������ ���� ������ �����, ������� ��� ��� � ���������� (�� ���-��).
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

--����� ������ ���� ������ ����� ���� ���� ������ ��������.
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


--����� ��� �������� �����, ������ � ��� ������������ � ������� ���������.
create trigger book_delete
on Books
after delete
as
insert into RemovedBooks
select * from deleted

--���� ����� ����������� � ����, ��� ������ ���� ������� �� ������� ���������.
Create trigger book_undeleting
on Books
For insert
as 
Declare @id int
Select @id = Id from inserted

delete from RemovedBooks
where Id = @id