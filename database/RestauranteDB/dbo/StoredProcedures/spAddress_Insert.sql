USE [RestauranteDB]
GO

CREATE PROCEDURE [dbo].[spAddress_Insert]
		 @Id int		
		,@UserId int
        ,@Street varchar(200)
        ,@Number varchar(10)
        ,@Neighborhood varchar(70)
        ,@Complement varchar(200)
        ,@City varchar(30)
        ,@State varchar(2)
        ,@Zipcode varchar(15)
        ,@MainAddress bit
AS
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Addresses]
			   ([UserId]
			   ,[Street]
			   ,[Number]
			   ,[Neighborhood]
			   ,[Complement]
			   ,[City]
			   ,[State]
			   ,[Zipcode]
			   ,[MainAddress]
			   ,[CreatedAt]
			   ,[UpdatedAt])
		 VALUES
			   (@UserId,
				@Street,
				@Number,
				@Neighborhood,
				@Complement,
				@City,
				@State,
				@Zipcode,
				@MainAddress,
				GETDATE(),
				GETDATE())
GO


