CREATE database MaximTest

go

use MaximTest
go

CREATE table Instruments (
	Id int not null primary key identity(1,1),
	Name nvarchar(50) not null
)

go 

INSERT into Instruments(Name) values ('String')