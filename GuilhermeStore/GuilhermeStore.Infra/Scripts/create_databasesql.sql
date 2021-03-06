CREATE DATABASE GuilhermeStore;

CREATE TABLE [GuilhermeStore].[Customer](
 Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,FirstName VARCHAR(40) NOT NULL
,LastName VARCHAR(40) NOT NULL
,Document CHAR(11) NOT NULL
,Email VARCHAR(160) NOT NULL
,Phone VARCHAR(13) NOT NULL
,IsDeleted BIT DEFAULT(0) 
,RegisterDate DATETIME NOT NULL
,AlterationDate DATETIME NOT NULL
);

CREATE TABLE [GuilhermeStore].[Address](
 Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,CustomerId UNIQUEIDENTIFIER NOT NULL
,Number VARCHAR(10) NOT NULL
,Complement VARCHAR(40) NOT NULL
,District VARCHAR(60) NOT NULL
,City VARCHAR(60) NOT NULL
,State CHAR(2) NOT NULL
,Country CHAR(2) NOT NULL
,ZipCode CHAR(8) NOT NULL
,RegisterDate DATETIME NOT NULL
,Type INT NOT NULL DEFAULT(1)
FOREIGN KEY(CustomerId) REFERENCES [GuilhermeStore].[Customer](Id)
);

CREATE TABLE [GuilhermeStore].[Product](
 Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,Title VARCHAR(255) NOT NULL
,Description TEXT NOT NULL
,Image VARCHAR(1024) NOT NULL
,Price MONEY NOT NULL
,QuantityOnHand DECIMAL(10,2) NOT NULL
,RegisterDate DATETIME NOT NULL
,AlterationDate DATETIME NOT NULL
);

CREATE TABLE [GuilhermeStore].[Order](
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,CustomerId UNIQUEIDENTIFIER not null
,CreateDate DATETIME NOT NULL DEFAULT(GETDATE())
,Status INT NOT NULL DEFAULT(1)
,RegisterDate DATETIME NOT NULL
,FOREIGN KEY(CustomerId) REFERENCES [GuilhermeStore].[Customer](Id)
);

CREATE TABLE [GuilhermeStore].[OrderItem](
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,OrderId UNIQUEIDENTIFIER NOT NULL
,ProductId UNIQUEIDENTIFIER NOT NULL
,Quantity DECIMAL (10,2) NOT NULL
,Price MONEY NOT NULL
,RegisterDate DATETIME NOT NULL
,FOREIGN KEY (OrderId) REFERENCES [GuilhermeStore].[Order](Id)
,FOREIGN KEY(ProductId) REFERENCES [GuilhermeStore].[Product](Id)
);

CREATE TABLE [GuilhermeStore].[Delivery](
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
,OrderId UNIQUEIDENTIFIER NOT NULL
,CreateDate DATETIME NOT NULL DEFAULT(GETDATE())
,EstimatedDeliveryDate DATETIME NOT NULL
,RegisterDate DATETIME NOT NULL
,Status INT NOT NULL DEFAULT(1)
,FOREIGN KEY(OrderId) REFERENCES [GuilhermeStore].[Order](Id)
);