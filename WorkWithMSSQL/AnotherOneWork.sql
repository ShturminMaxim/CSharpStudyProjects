use [library]
go

-- SAME RESULT
--select Students.FirstName+' '+ Students.LastName
--from Students
--where exists((
--select *
--from S_Cards
--where Students.Id = S_Cards.Id_Student))

-- SAME RESULT
--select Students.FirstName+' '+ Students.LastName
--from Students
--where Students.id = ANY((
--select Id_Student
--from S_Cards))

-- SAME RESULT
--select Students.FirstName+' '+ Students.LastName
--from Students
--where Students.id = SOME((
--select Id_Student
--from S_Cards))

-- SAME RESULT
--select Students.FirstName+' '+ Students.LastName
--from Students
--where Students.id IN((
--select Id_Student
--from S_Cards))

--select Students.FirstName+' '+ Students.LastName
--from Students
--where Students.id IN((
--select Id_Student
--from S_Cards))

----Select All Authors, which wrote Books with more Pages than Any Book published by "издательство Питер"
--select Authors.FirstName +' ' + Authors.LastName
--from Authors, Books
--where Books.Id_Author = Authors.Id
--and Books.Pages > ALL(select Books.Pages
--from Books, Press
--where Books.Id_Press = Press.Id
--and Press.Name = 'Питер')

----SAME RESULT
--select Authors.FirstName +' ' + Authors.LastName
--from Authors, Books
--where Books.Id_Author = Authors.Id
--and Books.Pages > (select max(Books.Pages)
--from Books, Press
--where Books.Id_Press = Press.Id
--and Press.Name = 'Питер')


-- TASKS
-- 1. 