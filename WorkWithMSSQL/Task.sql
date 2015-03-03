use [BooksForNet14-2]
go

--1.¬ытащить название учебников, которые издавались не издательством 'BHV', и тираж которых >= 3000 экземпл€ров.
-- 503
--Select Books.Name
--FROM Books, Press 
--where (Books.IdPress = Press.Id and Press.Name not LIKE '%BHV%')
--and Books.Pressrun >= 3000

--2.¬ытащить все книги-новинки, цена которых ниже 30р.
--18
--Select Books.Name
--From Books
--WHERE Books.Price < 30
--and Books.New = 'True'

--and (Books.IdCategory = Category.Id or Books.IdCategory is null) 
--and Books.IdPress = Press.Id 
--and Books.IdTheme = Theme.Id

--3.¬ытащить все книги, у которых в имени белее четырех слов.
--540-- my 546
Select Books.Name
From Books
WHERE len(Books.Name)-len(replace(Books.Name,' ',''))>3;

--4.¬ытащить книги, в названи€х которых есть слово Microsoft, но нет слова Windows
--26
--SELECT Books.Name
--FROM Books
--WHERE Books.Name LIKE '%Microsoft%' 
--AND Books.Name not LIKE '%Windows%';

--5.¬ытащить книги, у которых цена одной страницы меньше 10 копеек.
--SELECT Books.Name
--FROM Books
--WHERE Books.Pages > 0 
--AND Books.Price/Books.Pages < 0.10

--6.¬ытащить книги и цену в у.е. дл€ всех книг новинок.
--25
--Select Books.Name, Books.Price
--From Books
--WHERE Books.New = 'True'

--7.¬ычитать все книги, год издани€ у которых 2000, а цена >30.
--SELECT Books.Name
--FROM Books
--WHERE YEAR(Books.Date) = 2000
--AND Books.Price > 30

--8.¬ычитать все издательства, которые издали новинки с ценой >40р.
--SELECT Press.Name
--FROM Press, Books
--WHERE Books.New = 'True'
--AND Books.Price > 40
--AND Books.IdPress = Press.Id

--9.¬ычитать все тематики, у которых не указана категори€, при этом из результата исключить повторени€.
--SELECT DISTINCT Theme.Name
--FROM Theme, Books
--WHERE Books.IdCategory is null
--AND Books.IdTheme = Theme.Id

--10.¬ытащить название учебников, которые издавались издательством 'BHV', а перва€ буква тематики находитс€ в диапазоне от ≈ до  .
--Select Books.Name
--FROM Books, Press,Category, Theme
--where (Books.IdPress = Press.Id and Press.Name LIKE '%BHV%')
--and  (Books.IdCategory = Category.Id and Category.Name = '”чебники')
--and (Books.IdTheme = Theme.Id and Theme.Name LIKE '[е-к]%')

--11.¬ычитать название учебников, в названии издательств которых более 3 слов.
--Select Books.Name
--FROM Books, Press,Category, Theme
--where (Books.IdPress = Press.Id and len(Press.Name)-len(replace(Press.Name,' ',''))>2)
--and  (Books.IdCategory = Category.Id and Category.Name = '”чебники')

--12.¬ычитать название учебников, в названии издательств которых ровно 3 слова.
--6
--Select DISTINCT Books.Id, Books.Name, Press.Name
--FROM Books, Press, Category
--where (Books.IdPress = Press.Id and len(Press.Name)-len(replace(Press.Name,' ',''))=2)
--and (Books.IdCategory = Category.Id and Category.Name = '”чебники')