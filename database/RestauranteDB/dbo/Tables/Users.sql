﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Role] INT NOT NULL, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(60) NULL,
    [Email] VARCHAR(100) NOT NULL UNIQUE,
    [Phone] VARCHAR(20) NULL ,
    [Document] VARCHAR(60) NULL ,
    [Token] VARCHAR(450) NOT NULL UNIQUE,
    [BirthDate] DATETIME NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT FK_UsersRoles_Role FOREIGN KEY ([Role]) REFERENCES Roles(Id)
)