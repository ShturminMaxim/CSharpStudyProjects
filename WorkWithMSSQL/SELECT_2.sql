use [BooksForNet14-2]
go


SELECT Books.Name, Category.Name, Press.Name, Theme.Name
FROM Books, Category, Press, Theme
WHERE Books.IdCategory = Category.Id 
and Books.IdPress = Press.Id 
and Books.IdTheme = Theme.Id




--SELECT * 
--from Books
--WHERE IdCategory is null