use MaximTest
go

ALTER table Instruments 
ALTER column Name nvarchar(20) not null

go

ALTER table Instruments
ADD SurName nvarchar(50) not null default('empty')