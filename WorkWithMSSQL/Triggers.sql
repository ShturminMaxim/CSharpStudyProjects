use [library]
go

Create trigger ShowMessage
on Books
for UPDATE
as 
	raiserror('�������� %d', 0, 1, @@rowcount)
