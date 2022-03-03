CREATE TABLE [dbo].[OrderItem]
(
	[OrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Quantity] INT,
	[Subtotal] DECIMAL(18,2),
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

	CONSTRAINT PK_OrderDetails PRIMARY KEY (OrderId, ProductId)
	CONSTRAINT FK_OrderDetailsOrders_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(Id)
	CONSTRAINT FK_OrderDetailsProducts_ProductId FOREIGN KEY (ProductId) REFERENCES Products(Id)
)
