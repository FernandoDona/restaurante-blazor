USE [RestauranteDB]
GO

CREATE PROCEDURE [dbo].[spOrders_Insert]
		 @Id int		
		,@UserId int
        ,@AddressId int
        ,@Status int
        ,@TotalPrice decimal(18,2)
        ,@CreatedAt datetime
        ,@ClosedAt datetime = null
AS
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Orders]
		([UserId]
        ,[AddressId]
        ,[Status]
        ,[TotalPrice]
        ,[CreatedAt]
        ,[ClosedAt]
        ,[UpdatedAt])
	OUTPUT inserted.Id
	VALUES
		(@UserId
		,@AddressId
		,@Status
		,@TotalPrice
		,@CreatedAt
		,@ClosedAt
		,@CreatedAt)
GO