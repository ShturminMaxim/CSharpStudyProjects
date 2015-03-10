use Shop

go

--combine requests using UNION
--select Category.Name, sum(Product.Id)
--from Category, Product
--where Category.Id = Product.CategoryID
--group by Category.Name
--union
--select Supplier.Name, sum(Product.Id)
--from Supplier, Product, Delivery
--where Supplier.Id = Delivery.SupplierID
--and Delivery.ProductID = Product.Id
--group by Supplier.Name
-- order by applied only to last query

--the same result WITH INNER JOIN
--select Category.Name, sum(Product.Id)
--from Category inner join Product on Category.Id = Product.CategoryID
--group by Category.Name
--union
--select Supplier.Name, sum(Product.Id)
--from (Supplier inner join Delivery on Supplier.Id = Delivery.SupplierID)
--inner join Product on Delivery.ProductID = Product.Id
--group by Supplier.Name


--the same result WITH INNER JOIN
--select Category.Name, sum(Product.Id)
--from Category inner join Product on Category.Id = Product.CategoryID
--group by Category.Name
--union
--select 'Some Defaut Value', sum(Product.Id)
--from (Supplier inner join Delivery on Supplier.Id = Delivery.SupplierID)
--inner join Product on Delivery.ProductID = Product.Id
--group by Supplier.Name

--update Category
--set Name = 'Клавиатурки'
--where Name = 'Клавиатуры'

--update Product
--set Price = Price*2

--delete from Product
--where Amount = 687

--insert into Category
--values('NewCat')

--insert into Supplier(Name, AddressID)
--values('Maxim', 10)

--insert into Supplier(Name, AddressID)
--select Producer.Name, Producer.AddressID
--from Producer

--insert into Supplier(Name, AddressID)
--values('Roman', 10),('Konstantin', 10),('Dmitriy', 10)

insert into Supplier(Name, AddressID)
values('Maxim', 10)