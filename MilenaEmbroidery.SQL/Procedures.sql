CREATE OR ALTER PROCEDURE [Shop].[up_CreateProduct]
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

    INSERT INTO
		[Shop].[Products]
	OUTPUT
		INSERTED.[Id]
	VALUES(
		@Name,
		@IsLimited,
		@IsShown,
		@CountLimited,
		@DateAdded,
		@Price,
		@PictureLink);
		
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
