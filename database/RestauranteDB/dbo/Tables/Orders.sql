CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL IDENTITY(1,1) UNIQUE, 
    [UserId] INT NOT NULL,
    [AddressId] INT NULL,
    [Status] INT NOT NULL DEFAULT 0, 
    [TotalPrice] DECIMAL(18, 2) NULL, 
    [ClosedAt] DATETIME NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT PK_Orders PRIMARY KEY (Id, UserId)
    CONSTRAINT FK_OrdersOrderStatus_Status FOREIGN KEY ([Status]) REFERENCES OrderStatus(Id)
    CONSTRAINT FK_OrdersUsers_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
    CONSTRAINT FK_OdersAdresses_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)
