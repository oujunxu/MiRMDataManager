﻿CREATE TABLE [dbo].[SalesItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [RetailPrice] MONEY NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate()
)
