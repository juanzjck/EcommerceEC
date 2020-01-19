create database EcommerceECDB;
go
use EcommerceECDB;
go

-- Tablas
create table User_(idUsuario int primary key identity, userName varchar(40), firstName varchar(50), lastName varchar(50),email varchar(50), passwordUser  varchar(50)  );
go
create table Editorial_(idEditorial int primary key identity);
go
create table Product_(idProduct int primary key identity, productName varchar(50),Sku varchar(40), stock int, productDescription varchar(70), productImage image, idEditorial int foreign key references Editorial_(idEditorial), price decimal);
go
create table Category_(idCategory int primary key identity, categoryName varchar(50), categoryDescripton varchar(70));
go
create table Product_Category_Detail(id int primary key identity, idCategory int foreign key references Category_(idCategory) , idProduct int foreign key references Product_(idProduct));
go

create table Customer_(idCustomer int primary key,userName varchar(40), firstName varchar(50), lastName varchar(50),email varchar(50));
go
create table Order_(idOrder int primary key identity, idCustomer int foreign key references Customer_(idCustomer) );
go
create table Order_Detail(id int primary key identity, idOrder int foreign key references Order_(idOrder), idProduct int foreign key references Product_(idProduct), quantity int);






