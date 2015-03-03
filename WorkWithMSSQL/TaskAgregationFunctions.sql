--Показать издательства и сумму страниц по каждому из них.
--select Press.Name, SUM(Books.Pages)
--from Books, Press
--where Books.Id_Press = Press.Id
--group by(Press.Name)

--Показать общее кол-во книг, взятых студентами факультета 'Программирования'.
--select count(S_Cards.Id)
--from Students, S_Cards, Groups, Faculties
--where S_Cards.Id_Student = Students.Id
--and Students.Id_Group = Groups.Id 
--and (Groups.Id_Faculty = Faculties.Id and Faculties.Name = 'Программирования')


--Вывести кол-во книг и сумму страниц этих книг по каждому из издательств 'Питер','Наука' и 'Кудиц-Образ'.
--select Press.Name, count(Books.Id) , sum(Books.Pages)
--from Books, Press
--where Books.Id_Press = Press.Id
--and Press.Name like 'Питер' or Press.Name like 'Наука' or Press.Name like 'Кудиц-Образ' 
--group by Press.Name

--Вывести информацию о книге по программированию с наибольшим количеством страниц.
select min(Books.Pages)
from Books, Themes
where Books.Id_Category = Themes.Id
and Themes.Name = 'Графические пакеты'


--Вывести на экран кол-во взятых книг по каждой из кафедр.


--Показать издательства и самую старую книгу для каждого из них.


--Показать книги, которые брали и преподаватели и студенты (исключить повторения).


--Показать название книги с максимальным кол-вом страниц по каждому из издательств.(с начала найти максимум по издательствам, после чего вложить этот запрос внутрь поиска по книгам)