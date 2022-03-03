CREATE PROCEDURE [dbo].[spOrders_GetAll_Json]
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
		JSON_QUERY((SELECT
			oi.Quantity,
			oi.OrderId,
			oi.Subtotal,
			JSON_QUERY((SELECT
				p.Id,
				p.[Name],
				p.Price,
				p.[Description],
				JSON_QUERY((SELECT
					c.[Name],
					c.Id
				FROM Categories c
				WHERE p.CategoryId = c.Id
				FOR JSON PATH)) 
				AS Category
			FROM Products p
			WHERE oi.ProductId = p.Id
			FOR JSON PATH)) 
			AS Product
		FROM OrderItem oi
		WHERE o.Id = oi.OrderId
		FOR JSON PATH)) 
		AS Items,
		JSON_QUERY((SELECT
			a.Street,
			a.Number,
			a.Neighborhood,
			a.Complement,
			a.City,
			a.[State],
			a.Zipcode,
			a.Id,
			a.MainAddress
		FROM Addresses a
		WHERE o.AddressId = a.Id
		FOR JSON PATH))
		AS [Address]
	FROM Orders o
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
GO