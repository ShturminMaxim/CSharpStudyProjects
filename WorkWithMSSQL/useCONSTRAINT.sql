CREATE table People
(
	Id int not null identity(1,1),
	Name nvarchar(50) not null,
	Age int,
	CONSTRAINT cstUniq unique(Name),
	CONSTRAINT PK_People primary key (Id),
	CONSTRAINT checkAge check(Age > 16)
)
go

CREATE table Country (
	Id int not null primary key identity(1,1),
	Name nvarchar(50) not null
)


ALTER table People
ADD IdCountry int not null

go

ALTER table People
ADD CONSTRAINT FKPeopleCountry foreign key(IdCountry) references Country(Id)
