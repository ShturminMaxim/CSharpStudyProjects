--select count(*)
--from Books

--select sum(Price)/count(id)
--from Books

--select avg(Price)
--from Books

--select min(Price)
--from Books

--select max(Price)
--from Books

--select min(Price), max(Price)
--from Books

--select Name, Price
--from Books
--where Price = (select min(Price) from Books)

--select Name, Price
--from Books, (select Price as priceColumn from Books) as tempTable
--where Price = tempTable.priceColumn

--select tre.Name, tre.c
--from (select Category.Name, count(Books.Id) as c
--	from Category, Books
--	where Category.Id = Books.IdCategory
--	group by Category.Name) as tre
--where tre.c < 5

--select Name, min(Price)
--from Books
--where IdCategory = 6
--group by Name
--having MIN(Price)>40
