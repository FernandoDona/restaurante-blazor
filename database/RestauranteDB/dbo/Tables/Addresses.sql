CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [Street] VARCHAR(200) NOT NULL,
    [Number] VARCHAR(10) NOT NULL, 
    [Neighborhood] VARCHAR(70) NULL, 
    [Complement] VARCHAR(200) NULL, 
    [City] VARCHAR(30) NOT NULL, 
    [State] VARCHAR(2) NOT NULL, 
    [Zipcode] VARCHAR(15) NOT NULL,
    [MainAddress] BIT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT FK_UsersAddresses_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
)
