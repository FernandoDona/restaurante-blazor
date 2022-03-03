CREATE PROCEDURE [dbo].[spProducts_GetAll]
AS
	SET NOCOUNT ON;
	SELECT
		p.*,
		c.*
	FROM Products p
	INNER JOIN Categories c
	ON p.CategoryId = c.Id
GO
