--�������� ������������ � ����� ������� �� ������� �� ���.
--select Press.Name, SUM(Books.Pages)
--from Books, Press
--where Books.Id_Press = Press.Id
--group by(Press.Name)

--�������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.
--select count(S_Cards.Id)
--from Students, S_Cards, Groups, Faculties
--where S_Cards.Id_Student = Students.Id
--and Students.Id_Group = Groups.Id 
--and (Groups.Id_Faculty = Faculties.Id and Faculties.Name = '����������������')


--������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.
--select Press.Name, count(Books.Id) , sum(Books.Pages)
--from Books, Press
--where Books.Id_Press = Press.Id
--and Press.Name like '�����' or Press.Name like '�����' or Press.Name like '�����-�����' 
--group by Press.Name

--������� ���������� � ����� �� ���������������� � ���������� ����������� �������.
select min(Books.Pages)
from Books, Themes
where Books.Id_Category = Themes.Id
and Themes.Name = '����������� ������'


--������� �� ����� ���-�� ������ ���� �� ������ �� ������.


--�������� ������������ � ����� ������ ����� ��� ������� �� ���.


--�������� �����, ������� ����� � ������������� � �������� (��������� ����������).


--�������� �������� ����� � ������������ ���-��� ������� �� ������� �� �����������.(� ������ ����� �������� �� �������������, ����� ���� ������� ���� ������ ������ ������ �� ������)