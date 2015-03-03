-- termcontext - add ID
-- context - ontoname to AntologyID
-- Version - second foreignKey is CreatorUserName
-- Lexon - add field LexonID
-- Version - ontoname to OntologyID
-- Version - creatorUsername to UserAccountID
-- Antology - add AntologyID
-- UserAccount - add UserAccountID




-- Create userAccount Table
CREATE table userAccount(
	Id int not null primary key identity(1,1),
	Name nvarchar(50) not null,
	Email nvarchar(50),
	Password nvarchar(50) not null,
	IsAdministrator bit not null,
	Affiliation nvarchar(50)
)
-- Create Concept Table
CREATE table Concept(
	Id int not null primary key identity(1,1),
	SourceName nvarchar(50) not null,
	ConceptKey nvarchar(50) not null,
	Value nvarchar(50) not null
)
-- Create Ontology Table
CREATE table Ontology(
	Id int not null primary key identity(1,1),
	ContributorUserName nvarchar(50) not null,
	OwnerUserName nvarchar(50) not null,
	Status nvarchar(50) not null,
	Documentation nvarchar(50) not null
)
-- Create Version Table
CREATE table Version(
	Id int not null primary key identity(1,1),
	OntologyID int not null foreign key references Ontology(Id),
	CreatedDate datetime not null,
	Documentation nvarchar(50) not null,
	UserAccountID int not null foreign key references UserAccount(Id),
	VersionLabel nvarchar(50) not null,
)

-- Create TermContext Table
CREATE table TermContext(
	Id int not null primary key identity(1,1),
	TermLabel nvarchar(50) not null,
	ConceptID int not null foreign key references Concept(Id)
)

-- Create Context Table
CREATE table Context(
	Id int not null primary key identity(1,1),
	TermLabel int not null foreign key references TermContext(Id),
	OntologyId int foreign key references Ontology(Id)
)



-- Create Lexon Table
CREATE table Lexon(
	Id int not null primary key identity(1,1)
)