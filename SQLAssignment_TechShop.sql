--Task:1. Database Design:

--1. Create the database named "TechShop"
create database Techshop

--2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables
--based on the provided schema.
--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity.
create table Customers(
CustomerID int identity (1,1) primary key,
FirstName varchar(40) ,
LastName varchar(50) ,
Email varchar(50) ,
Phone int,
Address varchar(150))

create table Products(
ProductID int primary key,
ProductName varchar(100) ,
ProdDescription varchar(250) ,
Price int,
)
create table Orders(
OrderID int primary key,
CustomerID int,foreign key(CustomerID) references Customers(CustomerID),
OrderDate date ,
TotalAmount int,
)
create table OrderDetails(
OrderDetailID int primary key,
OrderID int , foreign key(OrderID) references Orders(OrderID),
ProductID int, foreign key(ProductID) references Products(ProductID),
Quantity int,
)
create table Inventory(
InventoryID int primary key,
ProductID int , foreign key(ProductID) references Products(ProductID),
QuantityInStock int ,
LastStockUpdate datetime,
)
create table categories(
CategoryID int primary key,
ProductID int, foreign key(ProductID) references Products(ProductID),
CategoryName varchar(26),
)

--5. Insert at least 10 sample records into each of the following tables.
insert into categories values(1,1,'SmartPhone'),(2,7,'SmartPhone'),(3,9,'SmartPhone'),(4,12,'SmartPhone')
,(5,2,'TV'),(6,3,'Laptop'),(7,6,'Laptop'),(8,4,'Mixer'),(9,5,'HeadPhone'),(10,11,'Speaker'),(11,10,'Camera'),(12,8,'Oven')

select * from categories
Insert into Customers values('Nina','Mehati','nina@gmmail.com',90997686,'45,sector B, raipura'),
('Chitra','Amate','chira@gmail.com',80806750,'65,rudra vihar,bhopal'),
('Mehek','Sharma','sharma@gmail.com',81834865,'61,akshar vihar,bhojpur'),
('Ramu','Nigam','nigam@gmail.com',84534784,'65,sudama nagar,khargone'),
('Sarika','Maheshwari','sarikaa@gmail.com',85605678,'11,kanha nagar,indore'),
('Muskan','Sri','shrima@gmail.com',81837575,'57,akash vihar,bhori'),
('Shyam','Dshore','shyamu@gmail.com',84534254,'33,vaisthi colony,hyderabad'),
('Sonia','Kajve','soniaa@gmail.com',85605438,'11,kashi nagar,pachmari'),
('Manasvi','Dangi','manasvi@gmail.com',97453654,'34,smriti colony,muradaabad'),
('Megha','Kishori','megha@gmail.com',83305478,'14,ahilya nagar,dhar'),
('Karishma','Bamniya','karishma@gmail.com',8325478,'18,trupti nagar,dhamnod')

select * from Customers

Insert into Products values
(1, 'Samsung Galaxy S23', 'Latest Samsung flagship smartphone with 5G support', 74999),
(2, 'Mi Smart TV 4A', '43-inch Full HD Android smart TV with Dolby Audio', 24999),
(3, 'HP Pavilion Gaming Laptop', 'Intel Core i7, 16GB RAM, 1TB SSD, NVIDIA GTX 1650', 70000),
(4, 'Bajaj Mixer Grinder', '500W mixer grinder with 3 stainless steel jars', 3199),
(5, 'Sony WH-1000XM4 Headphones', 'Wireless noise-cancelling over-ear headphones', 24990),
(6, 'Apple MacBook Air M2', '13-inch laptop with Apple M2 chip, 8GB RAM, 256GB SSD', 114900),
(7, 'Redmi Note 12', '6.5-inch display, 128GB storage, 5000mAh battery', 16999),
(8, 'Samsung Microwave Oven', '28L convection microwave oven with auto-cook menu', 14499),
(9, 'Asus ROG Phone 7', 'Gaming smartphone with Snapdragon 8 Gen 2 and 6000mAh battery', 84999),
(10, 'Canon EOS 1500D', 'DSLR camera with 24.1MP resolution, Wi-Fi and NFC support', 35999),
(11, 'Boat Stone 1500 Speaker', '40W Bluetooth speaker with deep bass and water resistance', 6499);

select * from Products
Insert into Orders values
(1, 3, '2024-09-01', 3000),
(2, 2, '2024-09-02', 1500),
(3, 3, '2024-09-03', 75000),
(4, 10, '2024-09-05', 250000),
(5, 4, '2024-09-06', 460),
(6, 2, '2024-09-07', 5500),
(7, 5, '2024-09-08', 892),
(8, 6, '2024-09-10', 24760),
(9, 3, '2024-09-12', 6660),
(10, 11, '2024-09-15', 79990),
(11, 4, '2024-09-18', 4500)

select * from Orders

insert into OrderDetails values
(1, 3, 2, 2),
(2, 4, 3, 1),
(3, 2, 1, 1),
(4, 10,4, 3),
(5, 6, 9, 1),
(6, 6, 10, 4),
(7, 5,7, 2),
(8, 1,6, 1),
(9, 8, 5, 5),
(10,7, 2, 2),
(11,9, 3, 3)

select * from OrderDetails
insert into Inventory values
(1, 1, 20, '2024-09-01'),
(2, 5, 35, '2024-08-02'),
(3, 3, 11, '2024-08-01'),
(4, 10,40, '2024-07-03'),
(5, 6, 9, '2024-09-06'),
(6, 6, 100, '2024-09-01'),
(7, 2,70, '2024-07-01'),
(8, 1,68, '2024-09-08'),
(9, 8, 50, '2024-09-03'),
(10,7, 25, '2024-08-05'),
(11,9, 30, '2024-05-01')

select * from Inventory

--Task 2
--1. Write an SQL query to retrieve the names and emails of all customers.
select FirstName,LastName,Email from Customers

--2. Write an SQL query to list all orders with their order dates and corresponding customer
--names.
select o.OrderID,o.OrderDate,c.FirstName,c.LastName from Orders o Join Customers c on o.CustomerID=c.CustomerID

--3. Write an SQL query to insert a new customer record into the "Customers" table. Include
--customer information such as name, email, and address.
insert into Customers values('Vrinda','Dashore','vrinda@gmail.com',78967500,'78,mahaveer nagar,khargone')

--4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by
--increasing them by 10%.
update Products set Price=Price*0.1+Price

--5. Write an SQL query to delete a specific order and its associated order details from the
--"Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.
declare @orderID int
set @orderID=1
delete from Orders where OrderID=@orderID

--6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID,
--order date, and any other necessary information.
Insert into Orders values
(1, 3, '2024-07-04', 3050)

--7. Write an SQL query to update the contact information (e.g., email and address) of a specific
--customer in the "Customers" table. Allow users to input the customer ID and new contact
--information.
declare @Customerid1 int
declare @email1 varchar(50)
declare @address1 varchar(150)
set @Customerid1=4
set @email1='samuel@gmail.com'
set @address1='35,narmad vihar,jhabua'
update Customers set Email=@email1 ,[Address]=@address1 where CustomerID=@Customerid1;

--8. Write an SQL query to recalculate and update the total cost of each order in the "Orders"
--table based on the prices and quantities in the "OrderDetails" table.
update Orders set TotalAmount=o.TotalAmount*od.Quantity
from Orders o JOIN OrderDetails od on o.OrderID=od.OrderID 

--9. Write an SQL query to delete all orders and their associated order details for a specific
--customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID
--as a parameter.
declare @customerID2 int
set @customerID2=5
delete from Orders where CustomerID=@customerID2

--10. Write an SQL query to insert a new electronic gadget product into the "Products" table,
--including product name, category, price, and any other relevant details
insert into Products values(12,'Realme 5 pro','72 W fast charging, 64MP camera, 8GB RAM,64 GB Storage',13500)

--11]Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from
--"Pending" to "Shipped"). Allow users to input the order ID and the new status
alter table Orders add OrderStatus varchar(20) 
select * from Orders
update Orders set OrderStatus='Confirmed' where OrderID is not null
declare @orderID3 int,@newStatus varchar(20)
set @orderID3=8
set @newStatus='Being packed'
update Orders set OrderStatus=@newStatus where OrderID=@orderID3

--12]Write an SQL query to calculate and update the number of orders placed by each customer
--in the "Customers" table based on the data in the "Orders" table.
select c.CustomerID,c.FirstName,c.LastName,count(o.CustomerID) as NoOfOrders
from customers c left join orders o
on o.CustomerID=c.CustomerID
group by c.CustomerID ,c.FirstName,c.LastName


--Task 3
--1]Write an SQL query to retrieve a list of all orders along with customer information (e.g.,
--customer name) for each order
select c.FirstName,c.LastName,o.OrderID
from orders o left join Customers c on c.CustomerID=o.CustomerID

--2. Write an SQL query to find the total revenue generated by each electronic gadget product.
--Include the product name and the total revenue.
select p.ProductName,od.Quantity*p.Price as Revenue from Products p
left join OrderDetails od on p.ProductID=od.ProductID

--3. Write an SQL query to list all customers who have made at least one purchase. Include their
--names and contact information.
select DISTINCT CONCAT(FirstName,' ',LastName) as Name,Email,Phone from Customers
join Orders on Customers.CustomerID=Orders.CustomerID

--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest
--total quantity ordered. Include the product name and the total quantity ordered.
select TOP 1 ProductName,MAX(Quantity) as TotalQuantity from Products join OrderDetails on 
Products.ProductID=OrderDetails.ProductID
group by ProductName
order by TotalQuantity desc 

--5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding
--categories.
select p.ProductName,c.CategoryName from Products p join categories c on p.ProductID=c.ProductID

--6. Write an SQL query to calculate the average order value for each customer. Include the
--customer's name and their average order value.
select DISTINCT CONCAT(c.FirstName,' ',c.LastName) as FullName, avg(o.TotalAmount) 
over(partition by c.CustomerID ) as Average from
Orders o join Customers c on o.CustomerID=c.CustomerID

--7. Write an SQL query to find the order with the highest total revenue. Include the order ID,
--customer information, and the total revenue.
select top 1 o.OrderID,o.TotalAmount as TotalRevenue,concat(c.FirstName,' ',c.LastName) as FullName,c.Email from
Customers c join Orders o on c.CustomerID=o.CustomerID 
order by TotalAmount desc

--8. Write an SQL query to list electronic gadgets and the number of times each product has been
--ordered.
select p.ProductName,p.ProductID,count(od.ProductID) as NoOfTimes from Products p left join OrderDetails od 
on p.ProductID=od.ProductID group by p.ProductName,p.ProductID

--9. Write an SQL query to find customers who have purchased a specific electronic gadget product.
--Allow users to input the product name as a parameter.
declare @productName1 varchar(100)
set @productName1='Redmi Note 12'
select c.customerid,c.FirstName,c.LastName,o.orderid from Customers c join Orders o on c.CustomerID=o.CustomerID
join OrderDetails od on od.OrderID=o.OrderID join Products p on p.ProductID=od.ProductID 
where p.ProductName=@productName1
select * from orders

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a
--specific time period. Allow users to input the start and end dates as parameters.
declare @startDate date
declare @endDate date
set @startDate='2024-09-02'
set @endDate='2024-09-07'
select sum(TotalAmount) as TotalRevenue from orders where OrderDate between @startDate and @endDate

--Task 4. Subquery and its type:
--1. Write an SQL query to find out which customers have not placed any orders.
select customerID,FirstName,lastname from Customers where
CustomerID not in(select CustomerID from Orders)

--2. Write an SQL query to find the total number of products available for sale.
select count(Productid) as NoOfProducts from Products where Productid in
(select ProductID from OrderDetails where Quantity>0)

--3. Write an SQL query to calculate the total revenue generated by TechShop.
 select sum(TotalAmount) as TotalRevenue from Orders
 
--4. Write an SQL query to calculate the average quantity ordered for products in a specific category.
--Allow users to input the category name as a parameter.
declare @categoryname2 varchar(26)
set @categoryname2='SmartPhone'
select AVG(Quantity) as AvgQuantity from OrderDetails where ProductID in
(select ProductID from categories where CategoryName=@categoryname2 )

--5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users
--to input the customer ID as a parameter.
select * from Orders
declare @customerid3 int
set @customerid3=4
select sum(TotalAmount) as Revenue from Orders where CustomerID=@customerid3

--6. Write an SQL query to find the customers who have placed the most orders. List their names
--and the number of orders they've placed.
select c.FirstName, c.LastName, o.NoOfOrders
from customers c join (
   select CustomerID, COUNT(CustomerID) as NoOfOrders
    from orders
    group by CustomerID
    having COUNT(CustomerID) > 0
) o on c.CustomerID = o.CustomerID
order by o.NoOfOrders desc

--7. Write an SQL query to find the most popular product category, which is the one with the highest
--total quantity ordered across all orders.
select top 1 c.categoryname ,od.quantity from categories c join (select ProductID from Products) p
 on c.ProductID=p.ProductID join OrderDetails od on od.ProductID=p.ProductID
group by c.CategoryName,od.Quantity order by od.Quantity desc
select * from Orders

--8. Write an SQL query to find the customer who has spent the most money (highest total revenue)
--on electronic gadgets. List their name and total spending.
select concat(c.firstname,' ',c.lastname) as fullname, o.totalAmount from Orders o join
customers c on o.customerid=c.customerid where 
o.totalAmount=(select max(TotalAmount) from Orders) 

--9. Write an SQL query to calculate the average order value (total revenue divided by the number of
--orders) for all customers.
select concat(c.firstname,' ',c.lastname) as fullname,c.CustomerID,sum(o.totalamount)/count(o.customerid) 
 as NoOfOrders  from Customers c left join (select customerid,TotalAmount from Orders) o on c.CustomerID=o.CustomerID
group by c.CustomerID,c.FirstName,c.LastName

--10. Write an SQL query to find the total number of orders placed by each customer and list their
--names along with the order count.
select concat(c.firstname,' ',c.lastname) as fullname, count(o.customerid) as NoOFOrders
from Customers c left join (select customerid from Orders) o on c.CustomerID=o.CustomerID
group by c.FirstName,c.LastName
