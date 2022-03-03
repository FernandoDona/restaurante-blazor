USE [RestauranteDB]
GO

INSERT INTO [dbo].[OrderItem]
           ([OrderId]
           ,[ProductId]
           ,[Quantity])
     VALUES
           (1
           ,1
           ,3),
		   (1
           ,2
           ,1),
		   (1
           ,4
           ,1),
		   (2
           ,6
           ,1),
		   (2
           ,7
           ,1),
		   (2
           ,8
           ,1),
		   (2
           ,9
           ,1)
GO


select * from Orders
select * from Products