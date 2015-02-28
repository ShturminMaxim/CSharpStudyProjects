use [BooksForNet14-2]
go


SELECT Name, Price, Books.Format, Pressrun 
FROM Books
--WHERE Pressrun >= 3000 and Pressrun <=5000 
--WHERE Pressrun BETWEEN 3000 and 5000 and IdCategory = 7
--WHERE IdCategory IN(3,7,5,11)
--WHERE IdCategory not IN(3,7,5,11)
--WHERE Name LIKE '%outlook%'
--WHERE Name LIKE '[ê-ÿ]%'

order by name DESC, Price ASC 

--SELECT Name, Price*Pressrun as "result"
--FROM Books

--SELECT Name, CONCAT(Price, '-'+ Books.Format) as "result"
--FROM Books

--SELECT Name as 'BookName', Price as 'BookPrice'
--FROM Books
--WHERE Price = 20.82
--GROUP by
--HAVING
--ORDER by
