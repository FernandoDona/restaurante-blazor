CREATE PROCEDURE [dbo].[spProducts_GetAll]
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
	ORDER BY p.CategoryId
GO
