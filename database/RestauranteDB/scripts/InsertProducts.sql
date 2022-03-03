USE [RestauranteDB]
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[Description]
           ,[CategoryId])
     VALUES
           ('Carne'
           ,3.45
           ,'Barata'
           ,1),
		   ('Queijo'
           ,4.50
           ,'Gordurosa'
           ,1),
		   ('Frango'
           ,4.98
           ,'Digna'
           ,1),
		   ('Chocolate'
           ,6.43
           ,'Cremosa'
           ,2),
		   ('Romeu e Julietat'
           ,6
           ,'Boaa'
           ,2),
		   ('X-Bacon'
           ,15.25
           ,'Saboroso'
           ,3),
		   ('X-Salada'
           ,13.50
           ,'Honesto'
           ,3),
		   ('Coca'
           ,4.80
           ,'Gelada'
           ,4),
		   ('Suco de Laranja'
           ,3
           ,'Natural'
           ,4),
		   ('Kibe de Carne'
           ,8
           ,'Arabe'
           ,4)
GO


