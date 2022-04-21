USE [RestauranteDB]
GO

CREATE PROCEDURE [dbo].[spOrderItem_Insert]
    @OrderId int,
    @ProductId int,
    @Quantity int,
    @Subtotal decimal(18,2)
AS

    SET NOCOUNT ON;
    INSERT INTO [dbo].[OrderItem]
            ([OrderId]
            ,[ProductId]
            ,[Quantity]
            ,[Subtotal]
            ,[CreatedAt]
            ,[UpdatedAt])
        VALUES
            (@OrderId
            ,@ProductId
            ,@Quantity
            ,@Subtotal
            ,GETDATE()
            ,GETDATE())

GO