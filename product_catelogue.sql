-- =============================================
-- Create database for catelogue product
-- =============================================
USE master
GO

DECLARE @dbname nvarchar(128)
SET @dbname = N'product_catalogue'
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = @dbname
)
DROP DATABASE "@dbname"

CREATE DATABASE "@dbname"
USE @dbname
GO

-- Create Product table
IF OBJECT_ID("Product", 'U') IS NOT NULL
  DROP TABLE "Product"

CREATE TABLE Product (
    ProductID int NOT NULL PRIMARY KEY,
    ProductName varchar(128) NOT NULL,
	Price float,
	ProductDescription varchar(256),
    CatelogueID int FOREIGN KEY REFERENCES Catelogue (CatelogueID)
);
GO

-- Create Catelogue table
IF OBJECT_ID("Catelogue", 'U') IS NOT NULL
  DROP TABLE "Catelogue"

CREATE TABLE Catelogue (
    CatelogueID int NOT NULL PRIMARY KEY,
    CatelogueName varchar(128) NOT NULL,
    ParentCatelogueID int FOREIGN KEY REFERENCES Catelogue (CatelogueID)
);
GO

-- Create Manufacture table
IF OBJECT_ID("Manufacture", 'U') IS NOT NULL
  DROP TABLE "Manufacture"

CREATE TABLE Manufacture (
    ManufactureID int NOT NULL PRIMARY KEY,
    ManufactureName varchar(128) NOT NULL,
);
GO