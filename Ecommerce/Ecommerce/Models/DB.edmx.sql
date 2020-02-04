
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/03/2020 18:14:39
-- Generated from EDMX file: C:\Users\LENOVO\Documents\GitHub\EcommerceEC\Ecommerce\Ecommerce\Models\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EcommerceECDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Order___idCustom__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_] DROP CONSTRAINT [FK__Order___idCustom__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__Order_Det__idOrd__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_Detail] DROP CONSTRAINT [FK__Order_Det__idOrd__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__Order_Det__idPro__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_Detail] DROP CONSTRAINT [FK__Order_Det__idPro__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__Order_pre__idPro__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_preorder] DROP CONSTRAINT [FK__Order_pre__idPro__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__Product___idEdit__3B75D760]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_] DROP CONSTRAINT [FK__Product___idEdit__3B75D760];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_C__idCat__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Category_Detail] DROP CONSTRAINT [FK__Product_C__idCat__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_C__idPro__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Category_Detail] DROP CONSTRAINT [FK__Product_C__idPro__412EB0B6];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category_];
GO
IF OBJECT_ID(N'[dbo].[Customer_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer_];
GO
IF OBJECT_ID(N'[dbo].[Editorial_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editorial_];
GO
IF OBJECT_ID(N'[dbo].[Order_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_];
GO
IF OBJECT_ID(N'[dbo].[Order_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_Detail];
GO
IF OBJECT_ID(N'[dbo].[Order_preorder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_preorder];
GO
IF OBJECT_ID(N'[dbo].[Product_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_];
GO
IF OBJECT_ID(N'[dbo].[Product_Category_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Category_Detail];
GO
IF OBJECT_ID(N'[dbo].[User_]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Category_'
CREATE TABLE [dbo].[Category_] (
    [idCategory] int IDENTITY(1,1) NOT NULL,
    [categoryName] varchar(50)  NULL,
    [categoryDescripton] varchar(70)  NULL
);
GO

-- Creating table 'Customer_'
CREATE TABLE [dbo].[Customer_] (
    [idCustomer] int  NOT NULL,
    [userName] varchar(40)  NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [email] varchar(50)  NULL
);
GO

-- Creating table 'Editorial_'
CREATE TABLE [dbo].[Editorial_] (
    [idEditorial] int IDENTITY(1,1) NOT NULL,
    [EditorialName] varchar(70)  NULL
);
GO

-- Creating table 'Order_'
CREATE TABLE [dbo].[Order_] (
    [idOrder] int IDENTITY(1,1) NOT NULL,
    [idCustomer] int  NULL
);
GO

-- Creating table 'Order_Detail'
CREATE TABLE [dbo].[Order_Detail] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idOrder] int  NULL,
    [idProduct] int  NULL,
    [quantity] int  NULL
);
GO

-- Creating table 'Product_'
CREATE TABLE [dbo].[Product_] (
    [idProduct] int IDENTITY(1,1) NOT NULL,
    [productName] varchar(50)  NULL,
    [Sku] varchar(40)  NULL,
    [stock] int  NULL,
    [productDescription] varchar(70)  NULL,
    [idEditorial] int  NULL,
    [price] decimal(18,0)  NULL,
    [productImage] varchar(70)  NULL
);
GO

-- Creating table 'Product_Category_Detail'
CREATE TABLE [dbo].[Product_Category_Detail] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idCategory] int  NULL,
    [idProduct] int  NULL
);
GO

-- Creating table 'User_'
CREATE TABLE [dbo].[User_] (
    [idUsuario] int IDENTITY(1,1) NOT NULL,
    [userName] varchar(40)  NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [email] varchar(50)  NULL,
    [passwordUser] varchar(50)  NULL,
    [tipo] int  NULL
);
GO

-- Creating table 'Order_preorder'
CREATE TABLE [dbo].[Order_preorder] (
    [idOrder_preorder] int  NOT NULL,
    [idProduct] int  NULL,
    [quantity] int  NULL,
    [idUser] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idCategory] in table 'Category_'
ALTER TABLE [dbo].[Category_]
ADD CONSTRAINT [PK_Category_]
    PRIMARY KEY CLUSTERED ([idCategory] ASC);
GO

-- Creating primary key on [idCustomer] in table 'Customer_'
ALTER TABLE [dbo].[Customer_]
ADD CONSTRAINT [PK_Customer_]
    PRIMARY KEY CLUSTERED ([idCustomer] ASC);
GO

-- Creating primary key on [idEditorial] in table 'Editorial_'
ALTER TABLE [dbo].[Editorial_]
ADD CONSTRAINT [PK_Editorial_]
    PRIMARY KEY CLUSTERED ([idEditorial] ASC);
GO

-- Creating primary key on [idOrder] in table 'Order_'
ALTER TABLE [dbo].[Order_]
ADD CONSTRAINT [PK_Order_]
    PRIMARY KEY CLUSTERED ([idOrder] ASC);
GO

-- Creating primary key on [id] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [PK_Order_Detail]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idProduct] in table 'Product_'
ALTER TABLE [dbo].[Product_]
ADD CONSTRAINT [PK_Product_]
    PRIMARY KEY CLUSTERED ([idProduct] ASC);
GO

-- Creating primary key on [id] in table 'Product_Category_Detail'
ALTER TABLE [dbo].[Product_Category_Detail]
ADD CONSTRAINT [PK_Product_Category_Detail]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idUsuario] in table 'User_'
ALTER TABLE [dbo].[User_]
ADD CONSTRAINT [PK_User_]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [idOrder_preorder] in table 'Order_preorder'
ALTER TABLE [dbo].[Order_preorder]
ADD CONSTRAINT [PK_Order_preorder]
    PRIMARY KEY CLUSTERED ([idOrder_preorder] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idCategory] in table 'Product_Category_Detail'
ALTER TABLE [dbo].[Product_Category_Detail]
ADD CONSTRAINT [FK__Product_C__idCat__403A8C7D]
    FOREIGN KEY ([idCategory])
    REFERENCES [dbo].[Category_]
        ([idCategory])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_C__idCat__403A8C7D'
CREATE INDEX [IX_FK__Product_C__idCat__403A8C7D]
ON [dbo].[Product_Category_Detail]
    ([idCategory]);
GO

-- Creating foreign key on [idCustomer] in table 'Order_'
ALTER TABLE [dbo].[Order_]
ADD CONSTRAINT [FK__Order___idCustom__45F365D3]
    FOREIGN KEY ([idCustomer])
    REFERENCES [dbo].[Customer_]
        ([idCustomer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order___idCustom__45F365D3'
CREATE INDEX [IX_FK__Order___idCustom__45F365D3]
ON [dbo].[Order_]
    ([idCustomer]);
GO

-- Creating foreign key on [idEditorial] in table 'Product_'
ALTER TABLE [dbo].[Product_]
ADD CONSTRAINT [FK__Product___idEdit__3B75D760]
    FOREIGN KEY ([idEditorial])
    REFERENCES [dbo].[Editorial_]
        ([idEditorial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product___idEdit__3B75D760'
CREATE INDEX [IX_FK__Product___idEdit__3B75D760]
ON [dbo].[Product_]
    ([idEditorial]);
GO

-- Creating foreign key on [idOrder] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [FK__Order_Det__idOrd__48CFD27E]
    FOREIGN KEY ([idOrder])
    REFERENCES [dbo].[Order_]
        ([idOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order_Det__idOrd__48CFD27E'
CREATE INDEX [IX_FK__Order_Det__idOrd__48CFD27E]
ON [dbo].[Order_Detail]
    ([idOrder]);
GO

-- Creating foreign key on [idProduct] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [FK__Order_Det__idPro__49C3F6B7]
    FOREIGN KEY ([idProduct])
    REFERENCES [dbo].[Product_]
        ([idProduct])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order_Det__idPro__49C3F6B7'
CREATE INDEX [IX_FK__Order_Det__idPro__49C3F6B7]
ON [dbo].[Order_Detail]
    ([idProduct]);
GO

-- Creating foreign key on [idProduct] in table 'Product_Category_Detail'
ALTER TABLE [dbo].[Product_Category_Detail]
ADD CONSTRAINT [FK__Product_C__idPro__412EB0B6]
    FOREIGN KEY ([idProduct])
    REFERENCES [dbo].[Product_]
        ([idProduct])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_C__idPro__412EB0B6'
CREATE INDEX [IX_FK__Product_C__idPro__412EB0B6]
ON [dbo].[Product_Category_Detail]
    ([idProduct]);
GO

-- Creating foreign key on [idProduct] in table 'Order_preorder'
ALTER TABLE [dbo].[Order_preorder]
ADD CONSTRAINT [FK__Order_pre__idPro__5CD6CB2B]
    FOREIGN KEY ([idProduct])
    REFERENCES [dbo].[Product_]
        ([idProduct])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order_pre__idPro__5CD6CB2B'
CREATE INDEX [IX_FK__Order_pre__idPro__5CD6CB2B]
ON [dbo].[Order_preorder]
    ([idProduct]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------