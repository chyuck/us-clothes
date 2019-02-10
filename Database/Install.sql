SET NOCOUNT ON
GO

PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Start creating database'

USE [master]
GO

IF DB_ID(N'USClothesShop') IS NOT NULL
BEGIN
	DROP DATABASE [USClothesShop]
	PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Database was dropped'
END
GO

:On Error exit

:r CreateDatabase.sql
PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Database schema was created'
GO

:r CreateInitialData.sql
PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Database initial data was created'
GO

:r Patch_1.0.1.sql
PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Patch 1.0.1 was applied'
GO

:r Patch_1.0.2.sql
PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Patch 1.0.2 was applied'
GO

PRINT CAST(SYSDATETIME() AS NVARCHAR) + N' - Database creating was completed'
GO