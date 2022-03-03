USE [RestauranteDB]
GO

INSERT INTO [dbo].[OrderStatus]
           ([Name])
     VALUES
           ('Created'),
		   ('Pending'),
		   ('OnTheWay'),
		   ('Paid'),
		   ('Closed'),
		   ('Canceled')
GO