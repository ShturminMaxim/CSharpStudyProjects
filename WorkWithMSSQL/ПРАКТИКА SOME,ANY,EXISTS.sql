/****** Script for SelectTopNRows command from SSMS  ******/
use Shop
go

--1.Получить информацию о всех поставщиках, товары которых продавались более 2-х раз.
--select Supplier.Name, count(Supplier.Name) as summ
--	from ProductListSale as sale, Delivery, Supplier
--	where sale.ProductID = Delivery.ProductID
--	and Delivery.SupplierID = Supplier.Id
--	group by Supplier.Name
--	having count(Supplier.Name) > 1


--2.Вывести самый популярный товар в магазине, то есть тот, который больше всего продавался.
--select Product.Name, count(ProductListSale.ProductID)
--from ProductListSale, Product
--where ProductListSale.ProductID = Product.Id
--group by Product.Name
--having count(ProductListSale.ProductID) > 0

--3.Если общее количество товаров всех категорий считать за 100%, то необходимо посчитать 
--сколько товаров каждой категории(в процентном соотношении) продавалось.



--4.Используя подзапросы вывести название всех товаров, которые поставлялись только 
--опеределнным поставщиком.


--5.Используя подзапрос вывести список товаров, их цены и категории, которые поставлялись 
--только одним поставщиком.


--6.Используя подзапросы вывести название поставщиков, которые не поставляли указанный товар.

--7.Используя подзапросы вывести на экран список производителей, которые находятся в той же 
--стране что и определенный поставщик.

--8.Написать запрос, который выводить на экран список поставщиков одной страны(например, Украины)


--9.Подсчитать количество поставщиков, товары которых поставлялись в период с ... по .... и не 
--были проданы. Используйте для этого EXISTS.
--select *
--from Delivery
--select *
--from ProductListSale
--where Delivery.DeliveryDate between '2013/12/25' and '2014/01/27'

--10.Выведите список производителей, которые находятся не в Украине. Отсортируйте выборку в 
--возрастающем порядке названий производителей. Для данного подзапроса не используйте объединения 
--таблиц, а только подзапросы и оператор EXISTS.
--select Supplier.Name
--from Supplier
--where exists(
--	select *
--	from Address, Country
--	where Supplier.AddressID = Address.Id
--	and Address.CountryID = Country.Id
--	and Country.Name != 'Ukraine'
--)
--order by Supplier.Name ASC


--11.Вывести на экран название товара, поставщика, который его поставлял, его полный адрес (в одном поле),
-- категория которых "Жесткие диски" и "Ноутбуки". Учитывать при выборке , только те товары которые поставлялись ЧП
--select Product.Name as 'Product Name', Supplier.Name as 'Supplier Name', (Address.Street + ' ,' + Address.Town + ' ,ZIP-' + Address.ZIP) as adres
--from Product, Category, Delivery, Supplier, Address
--where Product.CategoryID = Category.Id 
--and Category.Name IN('Жесткие диски','Ноутбуки')
--and Delivery.ProductID = Product.Id
--and Delivery.SupplierID = Supplier.Id
--and Supplier.AddressID = Address.Id
--and Supplier.Name LIKE '%ЧП%'


--12.Используя подзапрос найти поставщика, товаров которого нет в продаже. Используйте для поиска оперторы ANY или SOME.
--select Supplier.Name
--from Supplier
--where Supplier.Id = Any(
--	select Delivery.SupplierID
--	from Delivery
--)

-- понимать задачу.
-- что вівести?
-- что в подзапросе будет?
-- выбираем таблицы, из которых будем выбирать.
-- какие таблицы будут в подзапросе?
-- как связаны таблицы?
-- начинаем с подзапроса

----select Supplier.Name
----from Supplier
----where Supplier.Id = (
----	select Delivery.SupplierID
----	from Delivery, Product
----	where Delivery.ProductID = Product.Id
----	and Product.Amount = 0
----)


--13.Выберите всех производителей, товаров которых в наличии больше, чем любого другого производителя на выбор.
--select Producer.Name, sum(Product.Amount)
--from Product, Producer
--where Product.ProduceID = Producer.Id
--group by Producer.Name
--having sum(Product.Amount) >any (
--	select sum(Product.Amount)
--	from Product
--	where Product.ProduceID = 1
--)


--14.Вывести информацию о том, товары каких производителей в базе данных не существует.Для вывода полноценной
-- информации воспользуйтесь внешним объединением.


--15.Показать все товары, категорий "Материнские платы" и "Мониторы" и название поставщиков, которые 
--их поставляли. Использовать оператор UNION

--16.Получить информацию о количестве поставщиков 2-х стран, товары которых присутствуют в базе данных.
-- При этом вывести отдельно полученную информацию и общую сумму всех поставщиков товаров. Воспользуйтесь 
--для этого операторами UNION и UNION ALL.

