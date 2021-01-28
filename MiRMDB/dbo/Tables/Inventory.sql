﻿CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [PurchasePrice] INT NOT NULL, 
    [PurchaseDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
)
