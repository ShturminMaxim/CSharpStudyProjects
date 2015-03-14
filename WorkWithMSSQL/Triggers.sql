use [library]
go

Create trigger ShowMessage
on Books
for UPDATE
as 
	raiserror('изменено %d', 0, 1, @@rowcount)
