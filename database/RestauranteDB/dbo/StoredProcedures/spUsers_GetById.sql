CREATE PROCEDURE [dbo].[spUsers_GetById]
	@Id int
AS
	SET NOCOUNT ON;
	SELECT 
		u.Id,
		u.[Role],
		u.FirstName,
		u.LastName,
		u.Email,
		u.Phone,
		u.Document,
		u.Token,
		u.BirthDate,
		a.UserId,
		a.Id,
		a.Street,
		a.Number,
		a.Neighborhood,
		a.Complement,
		a.City,
		a.[State],
		a.Zipcode,
		a.MainAddress,
		sc.OrderId,
		sc.Id,
		sc.UserId,
		sc.IsActive
	FROM Users u
	INNER JOIN Addresses a
	ON u.Id = a.UserId
	INNER JOIN ShoppingCarts sc
	ON u.Id = sc.UserId
	WHERE 
		u.Id = @Id AND 
		a.MainAddress = 1;
GO
