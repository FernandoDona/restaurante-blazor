CREATE TABLE [dbo].[ShoppingCarts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [UserId] INT NOT NULL,
    [OrderId] INT NULL, 
    [IsActive] BIT NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT FK_ShoppingCartsUsers_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
    CONSTRAINT FK_ShoppingCartsOrders_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(Id)
)
