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
	Id int not null primary key identity(1,1)
)
-- Create Concept Table
CREATE table Concept(
	Id int not null primary key identity(1,1)
)
-- Create Ontology Table
CREATE table Ontology(
	Id int not null primary key identity(1,1)
)
-- Create Version Table
CREATE table Version(
	Id int not null primary key identity(1,1)
)
-- Create TermContext Table
CREATE table TermContext(
	Id int not null primary key identity(1,1)
)
-- Create Context Table
CREATE table Context(
	Id int not null primary key identity(1,1)
)
-- Create Lexon Table
CREATE table Lexon(
	Id int not null primary key identity(1,1)
)