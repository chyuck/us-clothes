:On Error exit

USE [USClothesShop]
GO

-- Size Table --
ALTER TABLE [dbo].[Size] ALTER COLUMN [Weight] [nvarchar](30) NULL;
GO

ALTER TABLE [dbo].[Size] ALTER COLUMN [Height] [nvarchar](30) NULL;
GO
