CREATE PROCEDURE [dbo].[spOrders_GetAll]
AS
	SET NOCOUNT ON;
	SELECT 
		o.Id,
		o.UserId,
		o.AddressId,
		o.[Status],
		o.TotalPrice,
		o.CreatedAt,
		o.ClosedAt,
		oi.Quantity,
		oi.OrderId,
		oi.ProductId,
		oi.Subtotal,
		p.[Description],
		p.Id,
		p.[Name],
		p.Price,
		p.CategoryId,
		c.[Name],
		c.Id,
		a.Street,
		a.Number,
		a.Neighborhood,
		a.Complement,
		a.City,
		a.[State],
		a.Zipcode,
		a.Id,
		a.MainAddress
	FROM Orders o
	LEFT JOIN Addresses a
	ON o.AddressId = a.Id
	INNER JOIN Users u
	ON o.UserId = u.Id
	LEFT JOIN OrderItem oi
	ON o.Id = oi.OrderId
	INNER JOIN Products p
	ON oi.ProductId = p.Id
	INNER JOIN Categories c
	ON p.CategoryId = c.Id
GO