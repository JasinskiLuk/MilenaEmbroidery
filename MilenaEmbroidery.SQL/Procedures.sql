
CREATE PROCEDURE [Shop].[up_CreateProduct]
	@Name NVARCHAR(250),
	@IsLimited BIT,
	@CountLimited NUMERIC(8,2),
	@DateAdded DATETIME2,
	@Price MONEY,
	@PictureLink NVARCHAR(1000)
AS

    SET NOCOUNT ON

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
		@PictureLink);

GO


CREATE PROCEDURE [Shop].[up_UpdateProduct]
    @Id INT,
	@Name NVARCHAR(250),
	@IsLimited BIT,
	@CountLimited NUMERIC(8,2),
	@DateAdded DATETIME2,
	@Price MONEY,
	@PictureLink NVARCHAR(1000)
AS

    SET NOCOUNT ON

    UPDATE
		[Shop].[Products]
	SET
		[Name] = @Name,
		[IsLimited] = @IsLimited,
		[CountLimited] = @CountLimited,
		[DateAdded] = @DateAdded,
		[Price] = @Price,
		[PictureLink] = @PictureLink
	OUTPUT
		INSERTED.[Id]
	WHERE
		[Id] = @Id;

GO


CREATE PROCEDURE [Shop].[up_DeleteProduct]
    @Id INT
AS

    SET NOCOUNT ON

    DELETE
		[Shop].[Products]
	OUTPUT
		DELETED.[Id]
    WHERE
		[Id] = @Id;

GO


CREATE PROCEDURE [Shop].[up_GetProduct]
    @Id INT
AS

    SET NOCOUNT ON

    SELECT
		[Id],
		[Name],
		[IsLimited],
		[CountLimited],
		[DateAdded],
		[Price],
		[PictureLink]
    FROM
		[Shop].[Products]
    WHERE
		[Id] = @Id;

GO


CREATE PROCEDURE [Shop].[up_GetProducts]
AS

    SET NOCOUNT ON

    SELECT
		[Id],
		[Name],
		[IsLimited],
		[CountLimited],
		[DateAdded],
		[Price],
		[PictureLink]
    FROM
		[Shop].[Products];

GO


CREATE PROCEDURE [Shop].[up_CheckIfProductExist]
    @Id INT
AS

    SET NOCOUNT ON

    SELECT
		COUNT(1)
    FROM
		[Shop].[Products]
    WHERE
		[Id] = @Id;

GO
