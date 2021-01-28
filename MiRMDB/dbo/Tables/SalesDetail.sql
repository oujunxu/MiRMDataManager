CREATE TABLE [dbo].[SalesDetail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SaleId] INT NOT NULL,     
    [productId] INT NOT NULL,
    [PurchasePrice] MONEY NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Tax] MONEY NOT NULL 

)
