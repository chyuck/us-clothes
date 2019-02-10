:On Error exit

USE [USClothesShop]
GO

-- Order Table --
ALTER TABLE [dbo].[Order] ALTER COLUMN [CustomerPhoneNumber] [varchar](20) NULL;
GO

ALTER TABLE [dbo].[Order] ALTER COLUMN [CustomerEmail] [varchar](50) NULL;
GO
