CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(150) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [Description] VARCHAR(500) NULL, 
    [CategoryId] INT NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT FK_CategoriesProducts_CategoryId FOREIGN KEY (CategoryId) 
    REFERENCES Categories(Id)
)
