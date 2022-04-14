USE [RestauranteDB]
GO

CREATE PROCEDURE [dbo].[spAddress_Update]
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
	
	UPDATE [dbo].[Addresses]
		SET	    
			[UserId] = @UserId
			,[Street] = @Street
			,[Number] = @Number
			,[Neighborhood] = @Neighborhood
			,[Complement] = @Complement
			,[City] = @City
			,[State] = @State
			,[Zipcode] = @Zipcode
			,[MainAddress] = @MainAddress
			,[UpdatedAt] = GETDATE()
		WHERE
			Id = @Id
GO