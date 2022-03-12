CREATE PROCEDURE [dbo].[spProducts_Get]
	@Id int = NULL,
	@Name varchar(100) = NULL
AS
	SET NOCOUNT ON;
	SELECT
		p.Id,
		p.[Name],
		p.Price,
		p.[Description],
		p.CategoryId,
		c.Id,
		c.[Name]
	FROM Products p
	INNER JOIN Categories c
	ON p.CategoryId = c.Id
	WHERE 
		(p.Id = @Id OR @Id IS NULL) AND 
		(p.[Name] LIKE '%' + @Name + '%' OR @Name IS NULL)
GO
