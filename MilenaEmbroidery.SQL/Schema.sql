
USE master;
GO

IF DB_ID('MilenaEmbroidery') IS NOT NULL
DROP DATABASE [MilenaEmbroidery];
GO

CREATE DATABASE [MilenaEmbroidery];
GO

USE [MilenaEmbroidery];
GO

CREATE SCHEMA [Shop];
GO

CREATE SCHEMA [General];
GO

CREATE TABLE [General].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(150) NOT NULL,
	[LastName] NVARCHAR(150) NOT NULL,
	[Email] NVARCHAR(150) NOT NULL,
	[Country] NVARCHAR(150) NOT NULL,
	[City] NVARCHAR(150),
	[Street] NVARCHAR(150),
	[PlotNo] NVARCHAR(25),
	[ApartmentNo] NVARCHAR(25),
	[IsAdmin] BIT NOT NULL
)

CREATE TABLE [Shop].[Products]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(250) NOT NULL,
	[IsLimited] BIT NOT NULL DEFAULT 0,
	[IsShown] BIT NOT NULL DEFAULT 1,
	[CountLimited] NUMERIC(8,2),
	[DateAdded] DATETIME2 NOT NULL,
	[Price] MONEY NOT NULL,
	[PictureLink] NVARCHAR(1000)
);

CREATE TABLE [Shop].[OrderStatus]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Code] NVARCHAR(8) NOT NULL
);

CREATE TABLE [Shop].[Orders]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [General].[Users]([Id]),
	[OrderStatusId] INT NOT NULL FOREIGN KEY REFERENCES [Shop].[OrderStatus]([Id])
);

CREATE TABLE [Shop].[OrderLists]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [OrderId] INT NOT NULL FOREIGN KEY REFERENCES [Shop].[Orders]([Id]),
    [ProductId] INT NOT NULL FOREIGN KEY REFERENCES [Shop].[Products]([Id]),
	[Quantity] INT NOT NULL
);