use [BooksForNet14-2]
go

--1.�������� �������� ���������, ������� ���������� �� ������������� 'BHV', � ����� ������� >= 3000 �����������.
-- 503
--Select Books.Name
--FROM Books, Press 
--where (Books.IdPress = Press.Id and Press.Name not LIKE '%BHV%')
--and Books.Pressrun >= 3000

--2.�������� ��� �����-�������, ���� ������� ���� 30�.
--18
--Select Books.Name
--From Books
--WHERE Books.Price < 30
--and Books.New = 'True'

--and (Books.IdCategory = Category.Id or Books.IdCategory is null) 
--and Books.IdPress = Press.Id 
--and Books.IdTheme = Theme.Id

--3.�������� ��� �����, � ������� � ����� ����� ������� ����.
--540-- my 546
Select Books.Name
From Books
WHERE len(Books.Name)-len(replace(Books.Name,' ',''))>3;

--4.�������� �����, � ��������� ������� ���� ����� Microsoft, �� ��� ����� Windows
--26
--SELECT Books.Name
--FROM Books
--WHERE Books.Name LIKE '%Microsoft%' 
--AND Books.Name not LIKE '%Windows%';

--5.�������� �����, � ������� ���� ����� �������� ������ 10 ������.
--SELECT Books.Name
--FROM Books
--WHERE Books.Pages > 0 
--AND Books.Price/Books.Pages < 0.10

--6.�������� ����� � ���� � �.�. ��� ���� ���� �������.
--25
--Select Books.Name, Books.Price
--From Books
--WHERE Books.New = 'True'

--7.�������� ��� �����, ��� ������� � ������� 2000, � ���� >30.
--SELECT Books.Name
--FROM Books
--WHERE YEAR(Books.Date) = 2000
--AND Books.Price > 30

--8.�������� ��� ������������, ������� ������ ������� � ����� >40�.
--SELECT Press.Name
--FROM Press, Books
--WHERE Books.New = 'True'
--AND Books.Price > 40
--AND Books.IdPress = Press.Id

--9.�������� ��� ��������, � ������� �� ������� ���������, ��� ���� �� ���������� ��������� ����������.
--SELECT DISTINCT Theme.Name
--FROM Theme, Books
--WHERE Books.IdCategory is null
--AND Books.IdTheme = Theme.Id

--10.�������� �������� ���������, ������� ���������� ������������� 'BHV', � ������ ����� �������� ��������� � ��������� �� � �� �.
--Select Books.Name
--FROM Books, Press,Category, Theme
--where (Books.IdPress = Press.Id and Press.Name LIKE '%BHV%')
--and  (Books.IdCategory = Category.Id and Category.Name = '��������')
--and (Books.IdTheme = Theme.Id and Theme.Name LIKE '[�-�]%')

--11.�������� �������� ���������, � �������� ����������� ������� ����� 3 ����.
--Select Books.Name
--FROM Books, Press,Category, Theme
--where (Books.IdPress = Press.Id and len(Press.Name)-len(replace(Press.Name,' ',''))>2)
--and  (Books.IdCategory = Category.Id and Category.Name = '��������')

--12.�������� �������� ���������, � �������� ����������� ������� ����� 3 �����.
--6
--Select DISTINCT Books.Id, Books.Name, Press.Name
--FROM Books, Press, Category
--where (Books.IdPress = Press.Id and len(Press.Name)-len(replace(Press.Name,' ',''))=2)
--and (Books.IdCategory = Category.Id and Category.Name = '��������')