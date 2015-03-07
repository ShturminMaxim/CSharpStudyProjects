--1
--������� ���������� ��������� ���������� �� ������ ������ ���������. 
--select Groups.Name, count(S_Cards.Id)
--from S_Cards, Students, Groups
--where Students.Id_Group = Groups.Id
--and S_Cards.Id_Student = Students.Id
--group by(Groups.Name)

--2
--������� ���������� ����, ������ � ���������� �������������� �� ��������� "����������������" � "���� ������", � ����� ������� � ���� ������. 
--select count(Books.Id) as 'Books quantity'
--from S_Cards, Books, Students, Themes, Groups, Faculties
--where S_Cards.Id_Student = Students.Id
--and Students.Id_Group = Groups.Id
--and Groups.Id_Faculty = Faculties.Id
--and Faculties.Name = '����������������'
--and Books.Id_Themes = Themes.Id
--and (Themes.Name = '����������������' or Themes.Name = '���� ������') 

--3
--������� ���������� � ����� � ���������� ����������� �������. 
--select max(Books.Pages)
--from Books

--4
--������� ���������� � ����� �� ���������������� � ���������� ����������� �������. 
--select max(Books.Pages)
--from Books, Themes
--where Books.Id_Themes = Themes.Id
--and (Themes.Name = '����������������' or Themes.Name = '���� ������') 


--5
--��������, ��� ������� ����� ����� ������� ����� � ���� ���� ������ 1 �����, � 
--�� ������ ������ ����� ���� �� ������ "���������" ���������� ������������ ����� (������ ����������) ���������� (������� ������� 0.5 �) �������� ����. 
--���������� ������� ������� ������ ������ ������ �������, � ����� ��������� ���������� ������ ����. 
--�������� ����� ������ ����������� � ������� �������, �� ���� ��������� ����� ������ ������ ���� �����. (��� ���������� ����� ������������ ������� ). 



--���� ������� ����� ���������� ���� � ���������� �� 100%, �� ���������� ���������� ������� ���� (� ���������� ���������) ���� ������ ���������. 
--select facult.Name, allBooks.ct as Main, facult.ct as Facultity
--from (select count(*) as ct from Books) as allBooks, 
--(select Faculties.Name,  count(S_Cards.Id) as ct 
--from S_Cards, Students, Groups, Faculties
--where Students.Id_Group = Groups.Id
--and S_Cards.Id_Student = Students.Id
--and Groups.Id_Faculty = Faculties.Id
--group by(Faculties.Name)) as facult

--������� ������ ����������� ������(��) ����� ���������. 
--select res.summCounter, res.FirstName, res.LastName
--from (select max(res.summCounter) as maximal
--	from (select count(Authors.Id) as summCounter, Authors.FirstName, Authors.LastName
--		from Books, Authors, Students, S_Cards
--		where S_Cards.Id_Student = Students.Id
--		and S_Cards.Id_Book = Books.Id
--		and Books.Id_Author = Authors.Id
--		group by Authors.FirstName, Authors.LastName) as res
--	) as result
--,(select count(Authors.Id) as summCounter, Authors.FirstName, Authors.LastName
--	from Books, Authors, Students, S_Cards
--	where S_Cards.Id_Student = Students.Id
--	and S_Cards.Id_Book = Books.Id
--	and Books.Id_Author = Authors.Id
--	group by Authors.FirstName, Authors.LastName) as res
--where res.summCounter = result.maximal
--group by res.summCounter, res.FirstName, res.LastName


--������� ������ ����������� ������(��) ����� �������������� � ���������� ���� ����� ������, ������ � ����������. 

--Not working
select res.summCounter, res.FirstName, res.LastName, count(Books.Id)
from Books, Authors, (select max(res.summCounter) as maximal
	from (select count(Authors.Id) as summCounter, Authors.Id, Authors.FirstName, Authors.LastName
		from Books, Authors, Teachers, T_Cards
		where T_Cards.Id_Teacher= Teachers.Id
		and T_Cards.Id_Book = Books.Id
		and Books.Id_Author = Authors.Id
		group by Authors.FirstName, Authors.LastName, Authors.Id) as res
	) as result
,(select count(Authors.Id) as summCounter, Authors.FirstName, Authors.LastName,  Authors.Id
	from Books, Authors, Teachers, T_Cards
	where T_Cards.Id_Teacher = Teachers.Id
	and T_Cards.Id_Book = Books.Id
	and Books.Id_Author = Authors.Id
	group by Authors.FirstName, Authors.LastName,  Authors.Id) as res
where res.summCounter = result.maximal
and Books.Id_Author = res.Id
group by res.summCounter, res.FirstName, res.LastName

--������� ������ ����������(��) ��������(�) ����� ��������� � ��������������. 

