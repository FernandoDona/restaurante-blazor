CREATE PROCEDURE [dbo].[spCategories_GetAll]
AS
	SET NOCOUNT ON;
	SELECT 
		Id,
		[Name]
	FROM Categories
GO
