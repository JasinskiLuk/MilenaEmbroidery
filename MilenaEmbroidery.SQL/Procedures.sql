
/* Product Procedures */

CREATE OR ALTER PROCEDURE [Shop].[up_CreateProduct]
	@Name NVARCHAR(250),
	@IsLimited BIT,
	@CountLimited NUMERIC(8,2),
	@DateAdded DATETIME2,
	@Price MONEY,
	@PictureLink NVARCHAR(1000),
	@IsShown BIT
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO
		[Shop].[Products]
	OUTPUT
		INSERTED.[Id]
	VALUES(
		@Name,
		@IsLimited,
		@CountLimited,
		@DateAdded,
		@Price,
		@PictureLink,
		@IsShown);
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_UpdateProduct]
    @Id INT,
	@Name NVARCHAR(250),
	@IsLimited BIT,
	@IsShown BIT,
	@CountLimited NUMERIC(8,2),
	@DateAdded DATETIME2,
	@Price MONEY,
	@PictureLink NVARCHAR(1000)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE
		[Shop].[Products]
	SET
		[Name] = @Name,
		[IsLimited] = @IsLimited,
		[IsShown] = @IsShown,
		[CountLimited] = @CountLimited,
		[DateAdded] = @DateAdded,
		[Price] = @Price,
		[PictureLink] = @PictureLink
	OUTPUT
		INSERTED.[Id]
	WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_DeleteProduct]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE
		[Shop].[Products]
	OUTPUT
		DELETED.[Id]
    WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetProduct]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[Name],
		[IsLimited],
		[IsShown],
		[CountLimited],
		[DateAdded],
		[Price],
		[PictureLink]
    FROM
		[Shop].[Products]
    WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetProducts]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[Name],
		[IsLimited],
		[IsShown],
		[CountLimited],
		[DateAdded],
		[Price],
		[PictureLink]
    FROM
		[Shop].[Products];
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_CheckIfProductExist]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		COUNT(1)
    FROM
		[Shop].[Products]
    WHERE
		[Id] = @Id;

END
GO


/* Order Procedures */

CREATE OR ALTER PROCEDURE [Shop].[up_CreateOrder]
	@UserId INT,
	@OrderStatusId INT
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO
		[Shop].[Orders]
	OUTPUT
		INSERTED.[Id]
	VALUES(
		@UserId,
		@OrderStatusId);
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_UpdateOrder]
    @Id INT,
	@UserId INT,
	@OrderStatusId INT
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE
		[Shop].[Orders]
	SET
		[UserId] = @UserId,
		[OrderStatusId] = @OrderStatusId
	OUTPUT
		INSERTED.[Id]
	WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_DeleteOrder]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE
		[Shop].[Orders]
	OUTPUT
		DELETED.[Id]
    WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetOrder]
    @UserId INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[UserId],
		[OrderStatusId]
    FROM
		[Shop].[Orders]
    WHERE
		[UserId] = @UserId;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetOrders]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[UserId],
		[OrderStatusId]
    FROM
		[Shop].[Orders];
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_CheckIfOrderExist]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		COUNT(1)
    FROM
		[Shop].[Orders]
    WHERE
		[Id] = @Id;

END
GO


/* OrderList Procedures */

CREATE OR ALTER PROCEDURE [Shop].[up_CreateOrderList]
	@OrderId INT,
	@ProductId INT,
	@Quantity INT
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO
		[Shop].[OrderLists]
	OUTPUT
		INSERTED.[Id]
	VALUES(
		@OrderId,
		@ProductId,
		@Quantity);
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_UpdateOrderList]
    @Id INT,
	@OrderId INT,
	@ProductId INT,
	@Quantity INT
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE
		[Shop].[OrderLists]
	SET
		[OrderId] = @OrderId,
		[ProductId] = @ProductId,
		[Quantity] = @Quantity
	OUTPUT
		INSERTED.[Id]
	WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_DeleteOrderList]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE
		[Shop].[OrderLists]
	OUTPUT
		DELETED.[Id]
    WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetOrderList]
    @OrderId INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[OrderId],
		[ProductId],
		[Quantity]
    FROM
		[Shop].[OrderLists]
    WHERE
		[OrderId] = @OrderId;
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_GetOrderLists]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[OrderId],
		[ProductId],
		[Quantity]
    FROM
		[Shop].[OrderLists];
		
END
GO


CREATE OR ALTER PROCEDURE [Shop].[up_CheckIfOrderListExist]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		COUNT(1)
    FROM
		[Shop].[OrderLists]
    WHERE
		[Id] = @Id;

END
GO


/* User Procedures */

CREATE OR ALTER PROCEDURE [General].[up_CreateUser]
	@FirstName NVARCHAR(150),
	@LastName NVARCHAR(150),
	@Email NVARCHAR(150),
	@Country NVARCHAR(150),
	@City NVARCHAR(150),
	@Street NVARCHAR(150),
	@PlotNo NVARCHAR(25),
	@ApartmentNo NVARCHAR(25),
	@IsAdmin BIT
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO
		[General].[Users]
	OUTPUT
		INSERTED.[Id]
	VALUES(
		@FirstName,
		@LastName,
		@Email,
		@Country,
		@City,
		@Street,
		@PlotNo,
		@ApartmentNo,
		@IsAdmin);
		
END
GO


CREATE OR ALTER PROCEDURE [General].[up_UpdateUser]
    @Id INT,
	@FirstName NVARCHAR(150),
	@LastName NVARCHAR(150),
	@Email NVARCHAR(150),
	@Country NVARCHAR(150),
	@City NVARCHAR(150),
	@Street NVARCHAR(150),
	@PlotNo NVARCHAR(25),
	@ApartmentNo NVARCHAR(25),
	@IsAdmin BIT
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE
		[General].[Users]
	SET
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Email] = @Email,
		[Country] = @Country,
		[City] = @City,
		[Street] = @Street,
		[PlotNo] = @PlotNo,
		[ApartmentNo] = @ApartmentNo,
		[IsAdmin] = @IsAdmin
	OUTPUT
		INSERTED.[Id]
	WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [General].[up_GetUser]
    @Id INT
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[FirstName],
		[LastName],
		[Email],
		[Country],
		[City],
		[Street],
		[PlotNo],
		[ApartmentNo],
		[IsAdmin]
    FROM
		[General].[Users]
    WHERE
		[Id] = @Id;
		
END
GO


CREATE OR ALTER PROCEDURE [General].[up_GetUsers]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[FirstName],
		[LastName],
		[Email],
		[Country],
		[City],
		[Street],
		[PlotNo],
		[ApartmentNo],
		[IsAdmin]
    FROM
		[General].[Users];
		
END
GO


CREATE OR ALTER PROCEDURE [General].[up_LoginUser]
    @FirstName NVARCHAR(150),
	@LastName NVARCHAR(150)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
		[Id],
		[FirstName],
		[LastName],
		[IsAdmin]
    FROM
		[General].[Users]
    WHERE
		[FirstName] = @FirstName
		AND [LastName] = @LastName;

END
GO