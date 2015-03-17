-- 1. �������� ��, �������� �����, ������� ��������,
-- 2. ������� � ��������� ��

-- * ������� �� � ������� �������. 2 �������, ��� ����������� �������� �� ����������
--Department (id, name)
--Employer (id, departmentId, name, salary, chiefID)
-- 7-10 �������.
-- 5 ��������
-- 1 ������� ������ ����������, ������ �������� �� ������� ��� � ������������,
-- 2 ������� ������ �����������, ���������� ������������ �������� � ����� ������.
-- 3 ������� ������ ID �������. ���-�� ����������� ������ �� �������� 3 ���.
-- 4 ������� ������ �����������, �� ������� ������������ ������������, ���������� � ��� �� ������ .
-- 5 ������� ������ Id ������� � ������������ ��������� �� �����������.

-----------------------------
-- Create DB
-----------------------------
--CREATE database company
--on (
--name = company,
--filename = 'D:\company.mdf',
--size = 7MB,
--maxsize = 199MB,
--filegrowth = 2MB
--)
--log on (
--	name = company_Log,
--	filename = 'D:\company.ldf',
--	size = 7MB,
--	maxsize = 199MB,
--	filegrowth = 10%
--)

--go

--use company

--go

--CREATE table Department (
--	Id int not null primary key identity(1,1),
--	Name nvarchar(50) not null
--)

--go 

--INSERT into Department(Name) values ('Engineering Team');
--INSERT into Department(Name) values ('Designers Team');
--INSERT into Department(Name) values ('Admin Team');
--INSERT into Department(Name) values ('Service Team');
--INSERT into Department(Name) values ('Support Team');
--INSERT into Department(Name) values ('Cleaner Team');

--go 

--CREATE table Employer (
--	Id int not null primary key identity(1,1),
--	departmentId int not null foreign key references Department(Id),
--	Name nvarchar(50) not null,
--	salary int,
--	chiefID int foreign key references Employer(Id)
--)

--INSERT into Employer(departmentId, Name, salary, chiefID) values (1,'Max', 2500, 1);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (1,'Dou', 1500, 1);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (1,'Johns', 1500, 1);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (1,'John', 1500, 1);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (1,'Lennon', 1500, 1);

--INSERT into Employer(departmentId, Name, salary, chiefID) values (2,'Roman', 500, 6);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (2,'Alex', 1000, 6);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (2,'Ludmila', 1000, 6);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (2,'Helen', 1000, 6);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (2,'Alina', 1500, 6);

--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Sarah', 2000, 11);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Lui', 2500, 11);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Sam', 1000, 11);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Rob', 1000, null);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Ken', 1000, null);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Ben', 100, 11);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (3,'Rok', 100, 11);

--INSERT into Employer(departmentId, Name, salary, chiefID) values (4,'Bob', 400, 16);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (4,'Lui', 1000, 16);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (4,'Sam', 600, 16);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (4,'Rob', 400, 16);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (4,'Ken', 200, 16);

--INSERT into Employer(departmentId, Name, salary, chiefID) values (5,'Kate', 200, 21);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (5,'Zoi', 200, 21);
--INSERT into Employer(departmentId, Name, salary, chiefID) values (5,'Frank', 200, 21);


-------------------------
-- Select from DB
-------------------------

use company

go

-- 1 ������� ������ �����������, ������� �������� �� ������� ��� � ������������,
select Department.Name as departmentName, Employer.Name, Employer.Salary
from Employer, Department
where Employer.departmentId = Department.id
and Employer.Salary > (
					select Employer.Salary
					from Employer
					where Employer.departmentId = Department.Id
					and Employer.chiefID = Employer.Id
				)

-- 2 ������� ������ �����������, ���������� ������������ �������� � ����� ������.
select Department.Name as departmentName, Employer.Name, Employer.Salary
from Employer, Department
where Employer.departmentId = Department.id
and Employer.Salary = (
				select max(Employer.Salary)
				from Employer
				where Employer.departmentId = Department.id
			)

-- 3 ������� ������ ID �������. ���-�� ����������� ������ �� �������� 3 ���.
select distinct Department.Name as departmentName
from Employer, Department
where Employer.departmentId = Department.id
and (
		select count(Employer.Id)
		from Employer
		where Employer.departmentId = Department.id
	) < 4


-- 4 ������� ������ �����������, �� ������� ������������ ������������, ���������� � ��� �� ������.
select Department.Name as departmentName, Employer.Name
from Employer, Department
where Employer.departmentId = Department.id
and Employer.chiefId is null


-- 5 ������� ������ Id ������� � ������������ ��������� �� �����������.
select sumTable.depiD
from (select Department.Id as depiD, sum(Employer.Salary) as summa
from Employer, Department
where Employer.departmentId = Department.id
group by Department.Id, Employer.departmentId) as sumTable
where sumTable.summa = (
			select max(summ.count1)
			from (select sum(Employer.Salary) as count1
					from Employer, Department
					where Employer.departmentId = Department.id
					group by Department.Id, Employer.departmentId
				) as summ
			)